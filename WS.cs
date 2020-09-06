/*
separate class file for no reason ¯\_(ツ)_/¯
*/
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWS
{
    class DWS
    {
        public string Url { get; set; }
        public DWS() { }
        public DWS(string url) { Url = url; }
        static public bool DiscordWebhookChecker(string url) => url.Length > 70 && url.Contains("discord.com/api/webhooks/") || url.Contains("discordapp.com/api/webhooks/");
        static public Dictionary<string, string> CreateWebhookMessage(string message)
        {
            return new Dictionary<string, string>
            {
                {"content", message },
                {"username", ""},
                {"avatar_url", ""},
            };
        }
        static public Dictionary<string, string> CreateWebhookMessage(string message, string username)
        {
            return new Dictionary<string, string>
            {
                {"content", message },
                {"username", username},
                {"avatar_url", ""},
            };
        }
        static public Dictionary<string, string> CreateWebhookMessage(string message, string username, string avatar_url)
        {
            return new Dictionary<string, string>
            {
                {"content", message },
                {"username", username},
                {"avatar_url",avatar_url},
            };
        }
        public async Task<HttpStatusCode> Send(HttpClient client, Dictionary<string, string> msg)
        {
            FormUrlEncodedContent e = new FormUrlEncodedContent(msg);
            if (string.IsNullOrEmpty(Url) && string.IsNullOrWhiteSpace(Url) && DiscordWebhookChecker(Url)) throw new NoUrlException("Invalid Discord Webhook URL",new ArgumentNullException());
            HttpResponseMessage r = await client.PostAsync(Url, e);
            return r.StatusCode;
        }
    }
    [Serializable]
    public class NoUrlException : Exception
    {
        public NoUrlException()
        { }
        public NoUrlException(string message)
            :base(message)
        { }
        public NoUrlException(string message, Exception innerexception)
            :base (message,innerexception)
        { }
    }
}
