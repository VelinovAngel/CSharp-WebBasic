namespace SUS.MvcFramework.Contracts
{
    using System;

    public interface IServiceCollection
    {
        void Add<TSource, TDestionation>();

        public object CreateInstance(Type type);
    }
}
