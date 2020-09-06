using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS.Properties;

namespace WS
{
    public partial class WebhookSender : Form
    {
        #region Vars
        private static readonly HttpClient client = new HttpClient();
        string url;
        #endregion
        #region Custom Methods
        async void Check(string _url)
        {
            lb_hint.Text = "Please wait";
            Content.Visible = false;
            Username.Visible = false;
            Avatar.Visible = false;
            messagesend.Visible = false;
            Content.Enabled = false;
            Username.Enabled = false;
            Avatar.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            MenuSave.Enabled = false;
            webhookinput.Enabled = false;
            btwebhooklinkchecker.Enabled = false;
            Content.Enabled = false;
            Username.Enabled = false;
            Avatar.Enabled = false;
            try
            {
                string resss;
                WebRequest request = WebRequest.Create(_url);
                WebResponse response = await request.GetResponseAsync();
                Stream dataStream = response.GetResponseStream();
                using (var ress = new StreamReader(dataStream))
                {
                    resss = ress.ReadToEnd();
                }
                string webhookname = await GetWebhookName(_url) ?? "null";
                Text = $"{Text.Substring(0, 14)} - {webhookname}";
                string resp = ((HttpWebResponse)response).StatusDescription;
                if (resp == "OK")
                {
                    Content.Visible = true;
                    Username.Visible = true;
                    Avatar.Visible = true;
                    messagesend.Visible = true;
                    Content.Enabled = true;
                    Content.Text = "";
                    Username.Enabled = true;
                    Avatar.Enabled = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    MenuSave.Enabled = true;
                    webhookinput.Enabled = true;
                    Content.Enabled = true;
                    Username.Enabled = true;
                    Avatar.Enabled = true;
                    AcceptButton = messagesend;
                    Settings.Default.DefRecent.Add(_url);
                    Settings.Default.DefRecName.Add(await GetWebhookName(_url));
                    Recent();
                    url = _url;
                    SaveSettings();
                    webhookinput.Text = url;
                    btwebhooklinkchecker.Enabled = false;
                }
                lb_hint.Text = "";
                btwebhooklinkchecker.Text = "Change";
                resp = null;
                resss = null;
                request = null;
                response.Close();
                response.Dispose();
                dataStream.Close();
                dataStream.Dispose();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message, err.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Content.Enabled = false;
                Username.Enabled = false;
                Avatar.Enabled = false;
                messagesend.Enabled = false;
                webhookinput.Enabled = true;
                btwebhooklinkchecker.Text = "Check";
                lb_hint.Text = $"{err.GetType().Name}: {err.Message}";
                lb_hint.ForeColor = Color.Red;
                AcceptButton = btwebhooklinkchecker;
                webhookinput.Focus();
            }
        } // MAIN CHECKER
        async void Send(string message, string user, string avatar)
        {
            lb_hint.Text = "Please wait";
            Content.Enabled = false;
            Username.Enabled = false;
            Avatar.Enabled = false;
            webhookinput.Enabled = false;
            messagesend.Enabled = false;
            try
            {
                var msg = new Dictionary<string, string>
            {
                {"content", message },
                {"username", user},
                {"avatar_url",avatar},
            };
                Content.Text = "";
                FormUrlEncodedContent emsg = new FormUrlEncodedContent(msg);
                HttpResponseMessage resp = await client.PostAsync(url, emsg);
                emsg.Dispose();
                resp.Dispose();
                msg = null;
                lb_hint.Text = "";
                webhookinput.Enabled = true;
                Content.Enabled = true;
                Username.Enabled = true;
                Avatar.Enabled = true;
                Content.Focus();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                lb_hint.Text = $"{err.GetType().Name}: {err.Message}";
                lb_hint.ForeColor = Color.Red;
            }
        } // MAIN SENDER
        async void Recent()
        {
            //get urls
            string[] recent = new string[Settings.Default.DefRecent.Count];
            for (int i = 0; i < Settings.Default.DefRecent.Count; i++)
            {
                if (!string.IsNullOrEmpty(Settings.Default.DefRecent[i]) && !string.IsNullOrWhiteSpace(Settings.Default.DefRecent[i]))
                    recent[i] = Settings.Default.DefRecent[i];
            }
            recent = recent.Distinct().ToArray();
            List<string> rec = recent.ToList();
            rec.RemoveAll(x => x == "null");
            recent = rec.ToArray();
            //get name urls
            string[] names = new string[recent.Length];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = await GetWebhookName(recent[i]) ?? "null";
            }
            if (recent.Length == 0) return;
            MenuRecent.Enabled = true;
            MenuRecent.DropDownItems.Clear();
            ToolStripItem item;
            ContextMenu cmenu = new ContextMenu();
            MenuItem cmenuit = cmenu.MenuItems.Add("Copy url");
            foreach (string web in recent)
            {

                if (!WebhookChecker(web ?? "")) continue;
                item = MenuRecent.DropDownItems.Add("");
                item.Text = names[Array.IndexOf(recent, web)]; //web?.Substring(8, web.IndexOf('/', 50) - 8) + '/' ?? "null";
                item.TextAlign = ContentAlignment.MiddleCenter;

                item.Image = Resources.Webhook;
                item.Click += ((object s, EventArgs a) =>
                {
                    Check(web);
                });
                item.MouseDown += ((object s, MouseEventArgs a) =>
                {
                    cmenuit.Click += ((object se, EventArgs ar) =>
                    {
                        Clipboard.SetText(web);
                    });
                    if (a.Button == MouseButtons.Right)
                        cmenu.Show(this, new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y - item.Size.Height));
                });
            }
        } // UPDATE RECENT
        void SaveSettings()
        {
            Settings.Default.DefWeb = url;
            //Settings.Default.DefUser = Username.Text;
            //Settings.Default.DefAv = Avatar.Text;
            Settings.Default.Save();
            Settings.Default.Reload();
        } // MAIN SAVE
        void LoadSettings()
        {
            Settings.Default.Reload();
            Check(Settings.Default.DefWeb);
            //Username.Text = Settings.Default.DefUser;
            //Avatar.Text = Settings.Default.DefAv;
            Recent();
        } // MAIN LOAD
        async void ResetWorker()
        {
            Settings.Default.Reset();
            MenuRecent.Enabled = false;
            lb_hint.Text = "Back to default";
            lb_hint.ForeColor = Color.Blue;
            await Task.Delay(3000);
            lb_hint.Text = "";
            lb_hint.ForeColor = Color.Black;
        } // RESET WORKER
        async Task<string> GetWebhookName(string url)
        {
            try
            {
            using(WebClient wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync(new Uri(url));
                Match m = Regex.Match(data, "\"name\": \"(.*?)\",");
                return m.Groups[1].Value;
            }
            }
            catch
            {
                return "null";
            }
        }
        async void SaveWorker()
        {
            SaveSettings();
            lb_hint.Text = "Saved";
            lb_hint.ForeColor = Color.Green;
            await Task.Delay(3000);
            lb_hint.Text = "";
            lb_hint.ForeColor = Color.Black;
        } // SAVE WORKER
        async void LoadWorker()
        {
            if (!string.IsNullOrEmpty(Settings.Default.DefWeb))
            {
                LoadSettings();
                lb_hint.Text = "Loaded";
                lb_hint.ForeColor = Color.Green;
                await Task.Delay(3000);
                lb_hint.Text = "";
                lb_hint.ForeColor = Color.Black;
            }
            else
            {
                lb_hint.Text = "Nothing to load";
                lb_hint.ForeColor = Color.Red;
                await Task.Delay(3000);
                lb_hint.Text = "";
                lb_hint.ForeColor = Color.Black;
            }
        } // LOAD WORKER
        private bool WebhookChecker(string url)
        {
            return url.Length > 70 && url.Contains("discord.com/api/webhooks/") || url.Contains("discordapp.com/api/webhooks/");
        } // WEBHOOK CHECKER
        #endregion
        #region Events
        public WebhookSender()
        {
            InitializeComponent();
        } // INIT
        private void WebhookSender_Load(object sender, EventArgs e)
        {
            SizeGripStyle = SizeGripStyle.Show;
            MenuOpen.Image = Resources.Load;
            MenuSave.Image = Resources.Save;
            MenuReset.Image = Resources.Reset;
            MenuRecent.Image = Resources.Recent;
            MenuExit.Image = Resources.Exit;
            MenuRecent.DropDownDirection = ToolStripDropDownDirection.Right;
            Application.ApplicationExit += ((object s, EventArgs a) =>
            {
                SaveSettings();
            });
            Recent();
            lb_hint.AutoSize = true;
            lb_hint.MaximumSize = new Size(Size.Width - lb_hint.Left, 0);
        } // ON LOAD
        private void btwebhooklinkchecker_Click(object sender, EventArgs e)
        {
            Check(webhookinput.Text);
        } // CHECKER
        private void messagesend_Click(object sender, EventArgs e)
        {
            Send(Content.Text, Username.Text, Avatar.Text);
        } // SENDER
        private void webhookinput_TextChanged(object sender, EventArgs e)
        {
            bool valid = WebhookChecker(webhookinput.Text);
            lb_hint.ForeColor = valid ? Color.Black : webhookinput.Text.Length == 0 ? Color.Black : Color.Red;
            lb_hint.Text = valid ? "" : webhookinput.Text.Length == 0 ? "Enter discord webhook link" : "Enter valid discord webhook link";
            btwebhooklinkchecker.Enabled = valid;
            AcceptButton = btwebhooklinkchecker;
        } // INPUT CHECKER
        private void Content_TextChanged(object sender, EventArgs e)
        {
            messagesend.Enabled = !string.IsNullOrEmpty(Content.Text) && !string.IsNullOrWhiteSpace(Content.Text);
            AcceptButton = messagesend;
        } // MESSAGE CHECKER
        private void MenuOpen_Click(object sender, EventArgs e)
        {
            LoadWorker();
        } // MENU OPEN
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        } // MENU EXIT
        private void MenuSave_Click(object sender, EventArgs e)
        {
            SaveWorker();
        } // MENU SAVE
        private void MenuReset_Click(object sender, EventArgs e)
        {
            ResetWorker();
        } // MENU RESET
        private void WebhookSender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Q:
                        e.Handled = e.SuppressKeyPress = true;
                        LoadWorker();
                        break;
                    case Keys.S:
                        if (MenuSave.Enabled)
                        {
                            SaveWorker();
                            e.Handled = e.SuppressKeyPress = true;
                        }
                        break;
                    case Keys.R:
                        ResetWorker();
                        e.Handled = e.SuppressKeyPress = true;
                        break;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                SaveSettings();
                e.Handled = e.SuppressKeyPress = true;
                Environment.Exit(0);
            }
        } // SHORTCUTS
        private void WebhookSender_SizeChanged(object sender, EventArgs e)
        {
            lb_hint.AutoSize = true;
            lb_hint.MaximumSize = new Size(Size.Width - lb_hint.Left, 0);
        } // AUTOSIZE
        #endregion
    }
}
