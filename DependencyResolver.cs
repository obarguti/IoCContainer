using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainer
{
    public class DependencyResolver
    {
        private readonly Dictionary<Type, Type> _dependencyMap;

        public DependencyResolver()
        {
            _dependencyMap = new Dictionary<Type, Type>();
        }

        public void Register<T1, T2>()
        {
            _dependencyMap.Add(typeof(T1), typeof(T2));
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            Type resolvedType;

            try
            {
                resolvedType = _dependencyMap[type];
            }
            catch
            {
                throw new Exception(string.Format("Unable to find an output of type {0}", type.Name));   
            }

            var constructor = resolvedType.GetConstructors().First();
            var parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }

            var resolvedParameters = parameters.Select(p => Resolve(p.ParameterType)).ToArray();
            return constructor.Invoke(resolvedParameters);
        }

        //public IOutput ResolveOutput()
        //{
        //    switch (Settings.Default.Output)
        //    {
        //        case "Printer":
        //            return new Printer();
        //        case "HardDisk":
        //            return new HardDisk();
        //        default:
        //            throw new Exception(string.Format("Unable to find an output of type {0}", Settings.Default.Output));
        //    }
        //}

        //public IOutput ResolveOutput()
        //{
        //    var iOutput = typeof(IOutput);
        //    var types = Assembly.GetExecutingAssembly().GetTypes();
        //    var type = types.SingleOrDefault(t => iOutput.IsAssignableFrom(t) && t.Name == Settings.Default.Output);

        //    if (type == null)
        //    {
        //        throw new Exception(string.Format("Unable to find an output of type {0}", Settings.Default.Output));
        //    }

        //    return (IOutput)Activator.CreateInstance(type);
        //}
    }
}
