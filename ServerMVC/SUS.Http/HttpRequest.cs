﻿namespace SUS.Http
{
    using System;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using SUS.Http.Enums;
    using SUS.Http.GlobalConstans;

    public class HttpRequest
    {
        public static IDictionary<string, Dictionary<string, string>> Sessions = new Dictionary<string, Dictionary<string, string>>();
        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            this.FormData = new Dictionary<string, string>();
            this.QueryData = new();

            var lines = requestString.Split(new string[] { HttpConstans.NewLine }, StringSplitOptions.None);

            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(' ');
            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);
            this.Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;
            StringBuilder bodyBuilder = new StringBuilder();

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }

            if (this.Headers.Any(x => x.Name == HttpConstans.RequestCookieHeader))
            {
                var cookiesAsString = this.Headers.FirstOrDefault(x => x.Name == HttpConstans.RequestCookieHeader).Value;
                var cookies = cookiesAsString.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookieAsString in cookies)
                {
                    this.Cookies.Add(new Cookie(cookieAsString));
                }
            }

            var sessionCookie = this.Cookies.FirstOrDefault(x => x.Name == HttpConstans.SessionCookieName);

            if (sessionCookie == null)
            {
                var sessionId = Guid.NewGuid().ToString();
                this.Session = new Dictionary<string, string>();
                Sessions.Add(sessionId, this.Session);
                this.Cookies.Add(new Cookie(HttpConstans.SessionCookieName, sessionId));
            }
            else if (!Sessions.ContainsKey(sessionCookie.Value))
            {
                this.Session = new Dictionary<string, string>();
                Sessions.Add(sessionCookie.Value, this.Session);
            }
            else
            {
                this.Session = Sessions[sessionCookie.Value];
            }

            if (this.Path.Contains("?"))
            {
                var pathParts = this.Path.Split('?', 2);
                this.Path = pathParts[0];
                this.QueryString = pathParts[1];
            }
            else
            {
                this.QueryString = string.Empty;
            }

            this.Body = bodyBuilder.ToString().TrimEnd('\n', '\r');

            SplitParameters(this.Body, this.FormData);
            SplitParameters(this.QueryString, this.QueryData);
        }

        private static void SplitParameters(string parametersAsString, Dictionary<string, string> output)
        {
            var parameters = parametersAsString.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var parameter in parameters)
            {
                var parameterParts = parameter.Split('=', 2);
                var name = parameterParts[0];
                var value = WebUtility.UrlDecode(parameterParts[1]);
                if (!output.ContainsKey(name))
                {
                    output.Add(name, value);
                }
            }
        }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public Dictionary<string, string> Session { get; set; }

        public Dictionary<string, string> FormData { get; set; }
        public Dictionary<string, string> QueryData { get; set; }

        public string Body { get; set; }
    }
}
