namespace WS
{
    partial class WebhookSender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebhookSender));
            this.webhookinput = new System.Windows.Forms.MaskedTextBox();
            this.btwebhooklinkchecker = new System.Windows.Forms.Button();
            this.messagesend = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.MaskedTextBox();
            this.Avatar = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Content = new System.Windows.Forms.TextBox();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_hint = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // webhookinput
            // 
            resources.ApplyResources(this.webhookinput, "webhookinput");
            this.webhookinput.Name = "webhookinput";
            this.webhookinput.TextChanged += new System.EventHandler(this.webhookinput_TextChanged);
            // 
            // btwebhooklinkchecker
            // 
            resources.ApplyResources(this.btwebhooklinkchecker, "btwebhooklinkchecker");
            this.btwebhooklinkchecker.FlatAppearance.BorderSize = 0;
            this.btwebhooklinkchecker.Name = "btwebhooklinkchecker";
            this.btwebhooklinkchecker.TabStop = false;
            this.btwebhooklinkchecker.Click += new System.EventHandler(this.btwebhooklinkchecker_Click);
            // 
            // messagesend
            // 
            resources.ApplyResources(this.messagesend, "messagesend");
            this.messagesend.FlatAppearance.BorderSize = 0;
            this.messagesend.Name = "messagesend";
            this.messagesend.TabStop = false;
            this.messagesend.Click += new System.EventHandler(this.messagesend_Click);
            // 
            // Username
            // 
            resources.ApplyResources(this.Username, "Username");
            this.Username.Name = "Username";
            // 
            // Avatar
            // 
            resources.ApplyResources(this.Avatar, "Avatar");
            this.Avatar.Name = "Avatar";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Content
            // 
            resources.ApplyResources(this.Content, "Content");
            this.Content.Name = "Content";
            this.Content.TextChanged += new System.EventHandler(this.Content_TextChanged);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Menu, "Menu");
            this.Menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.Menu.Name = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.MenuRecent,
            this.MenuReset,
            this.toolStripSeparator1,
            this.MenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            resources.ApplyResources(this.MenuOpen, "MenuOpen");
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            resources.ApplyResources(this.MenuSave, "MenuSave");
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuRecent
            // 
            this.MenuRecent.CheckOnClick = true;
            resources.ApplyResources(this.MenuRecent, "MenuRecent");
            this.MenuRecent.Name = "MenuRecent";
            // 
            // MenuReset
            // 
            this.MenuReset.Name = "MenuReset";
            resources.ApplyResources(this.MenuReset, "MenuReset");
            this.MenuReset.Click += new System.EventHandler(this.MenuReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            resources.ApplyResources(this.MenuExit, "MenuExit");
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // lb_hint
            // 
            resources.ApplyResources(this.lb_hint, "lb_hint");
            this.lb_hint.Name = "lb_hint";
            // 
            // WebhookSender
            // 
            this.AcceptButton = this.btwebhooklinkchecker;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_hint);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Avatar);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.messagesend);
            this.Controls.Add(this.btwebhooklinkchecker);
            this.Controls.Add(this.webhookinput);
            this.Controls.Add(this.Menu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "WebhookSender";
            this.Load += new System.EventHandler(this.WebhookSender_Load);
            this.SizeChanged += new System.EventHandler(this.WebhookSender_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WebhookSender_KeyDown);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox webhookinput;
        private System.Windows.Forms.Button btwebhooklinkchecker;
        private System.Windows.Forms.Button messagesend;
        private System.Windows.Forms.MaskedTextBox Username;
        private System.Windows.Forms.MaskedTextBox Avatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Content;
        new private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.Label lb_hint;
        private System.Windows.Forms.ToolStripMenuItem MenuReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuRecent;
    }
}