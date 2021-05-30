namespace SUS.MvcFramework
{
    using System;

    using SUS.Http.Enums;

    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
