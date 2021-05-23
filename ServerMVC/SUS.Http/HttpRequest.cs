namespace SUS.Http
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SUS.Http.Enums;
    using SUS.Http.GlobalConstans;

    public class HttpRequest
    {

        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            var lines = requestString.Split(new string[] { HttpConstans.NewLine }, StringSplitOptions.None);

            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(' ');
            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0]);
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
            this.Body = bodyBuilder.ToString().TrimEnd();
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}
