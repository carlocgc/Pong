using System;
using System.Collections.Generic;
using System.Text;
using Pong.Interfaces.Mediator;

namespace Pong.Mediator
{
    /// <summary>
    /// Stores instances of objects and services that can be shared between modules
    /// </summary>
    public class Mediator : IMediator
    {
        /// <summary> Collection of factory method, used for creating new instances of objects</summary>
        private readonly Dictionary<Type, Func<Object>> _InstanceCatalog = new Dictionary<Type, Func<Object>>();
        /// <summary> Collection of singleton service instances </summary>
        private readonly Dictionary<Type, Object> _ServiceCatalog = new Dictionary<Type, Object>();

        #region Implementation of IMediator

        /// <summary>
        /// Get a singleton instance of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            return (T) _ServiceCatalog[typeof(T)]; // TODO should be handled better?
        }

        /// <summary>
        /// Creates an instance of the given type
        /// </summary>
        /// <typeparam name="T"> Instance of the given type </typeparam>
        /// <returns></returns>
        public T Create<T>()
        {
            return (T) _InstanceCatalog[typeof(T)].Invoke(); // TODO should be handled better?
        }

        /// <summary>
        /// Register a singleton service with the <see cref="IMediator"/>
        /// </summary>
        /// <typeparam name="T"> The identifying type, should be an interface </typeparam>
        /// <typeparam name="T1"> The concretion type </typeparam>
        /// <param name="service"> The instance of the service </param>
        /// <returns></returns>
        public T RegisterService<T, T1>(T1 service) where T1 : T, IDisposable
        {
            if (_ServiceCatalog.ContainsKey(typeof(T)))
            {
                ((IDisposable)_ServiceCatalog[typeof(T)]).Dispose();
                _ServiceCatalog.Remove(typeof(T));
            }
            _ServiceCatalog.Add(typeof(T), service);
            return service;
        }

        /// <summary>
        /// Registers a constructor to be used to create new instances of the given type
        /// </summary>
        /// <typeparam name="T"> The identifying type, should be an interface </typeparam>
        /// <param name="creator"> The method by which the type is created, usually a constructor </param>
        /// <returns></returns>
        public IMediator RegisterFactory<T>(Func<Object> creator)
        {
            if (_InstanceCatalog.ContainsKey(typeof(T))) _InstanceCatalog.Remove(typeof(T));
            _InstanceCatalog.Add(typeof(T), creator);
            return this;
        }

        #endregion
    }
}
