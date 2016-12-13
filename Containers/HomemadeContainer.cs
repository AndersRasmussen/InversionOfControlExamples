using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Netcompany.Courses.TPS.Homemade
{
    /// <summary>
    /// Sample homemade container
    /// 
    /// This implements a simple container, which only supports constructor injection.
    /// 
    /// This is only for demo purposes and should not be used in a production system.
    /// 
    /// Missing (but explicitly avoided) features:
    /// - Error handling
    /// - Cycle detection in dependencies
    /// </summary>
    public class HomemadeContainer
    {
        private readonly IDictionary<Type, Type> _mapping = new Dictionary<Type, Type>();

        public void Register<TService, TImplementation>()
        {
            _mapping.Add(typeof(TService), typeof(TImplementation));
        }

        public void Register<TImplementation>()
        {
            _mapping.Add(typeof(TImplementation), typeof(TImplementation));
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        private object Resolve(Type t)
        {
            // Find the concrete type
            var type = _mapping[t];

            // Get the best matching constructor
            var constructor = GetBestMatchingConstuctor(type);

            // Call Resolve recursive and construct a parameter array
            var parameters = constructor.GetParameters().Select(parameter => Resolve(parameter.ParameterType)).ToArray();

            // Create the type
            return constructor.Invoke(parameters);
        }

        private ConstructorInfo GetBestMatchingConstuctor(Type t)
        {
            // First look at the constuctors with most parameters first
            foreach (var constructor in t.GetConstructors().OrderByDescending(x => x.GetParameters().Length))
            {
                // If there are any parameters we can't fulfill, then continue
                if (constructor.GetParameters().Any(x => !CanResolve(x.ParameterType)))
                    continue;

                return constructor;
            }
            throw new Exception("Not possible to find a constructor which can be fulfilled");
        }

        private bool CanResolve(Type t)
        {
            return _mapping.ContainsKey(t);
        }
    }
}
