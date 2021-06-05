namespace SUS.MvcFramework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SUS.MvcFramework.Contracts;

    public class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, Type> dependencyCOntainer = new();
        public void Add<TSource, TDestionation>()
        {
            this.dependencyCOntainer[typeof(TSource)] = typeof(TDestionation);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyCOntainer.ContainsKey(type))
            {
                type = this.dependencyCOntainer[type];
            }

            var constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault();
            var parameters = constructor.GetParameters();
            var parameterValues = new List<object>();
            foreach (var parameter in parameters)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parameterValues.Add(parameterValue);
            }

            var obj = constructor.Invoke(parameterValues.ToArray());
            return obj;
        }
    }
}
