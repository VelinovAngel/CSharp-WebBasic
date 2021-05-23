namespace SUS.Http
{
    using System;
    using System.Collections.Generic;

    using SUS.Http.Enums;

    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            this.StatusCode = statusCode;
            this.Body = body;
            this.Header = new List<Header>
            {
                {new Header ("Content-Type", contentType) },
                {new Header("Contente-Length", body.Length.ToString()) }

            };


        }

        public byte[] Body { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection<Header> Header { get; set; }

    }
}
