using System.Text;

namespace SUS.Http
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value)
            :base(name,value)
        {
            this.Path = "/";
        }

        //Max-Age
        //Expires
        public int MaxAge { get; set; }
        public bool HttpOnly { get; set; }
        public string Path { get; set; }

        //Domain, Path

        public override string ToString()
        {
            StringBuilder cookieBuilder = new StringBuilder();
            cookieBuilder.Append($"{this.Name}={this.Value}; Path={this.Path};");

            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append(" HttpOnly;");
            }

            return cookieBuilder.ToString();
        }
    }
}
