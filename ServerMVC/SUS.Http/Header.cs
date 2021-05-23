namespace SUS.Http
{
    using System;

    public class Header
    {
        public Header(string headerLine)
        {
            var headerParts = headerLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);

            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}