using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Mediator
{
    /// <summary>
    /// Adds functionality for mediating between modules
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Get an instance of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetService<T>();

        /// <summary>
        /// Creates an instance of the given type
        /// </summary>
        /// <typeparam name="T"> Instance of the given type </typeparam>
        /// <returns></returns>
        T Create<T>();

        /// <summary>
        /// Register a singleton service with the <see cref="IMediator"/>
        /// </summary>
        /// <typeparam name="T"> The identifying type, should be an interface </typeparam>
        /// <typeparam name="T1"> The concretion type </typeparam>
        /// <param name="service"> The instance of the service </param>
        /// <returns></returns>
        T RegisterService<T, T1>(T1 service) where T1 : T, IDisposable;


        /// <summary>
        /// Registers a constructor to be used to create new instances of the given type
        /// </summary>
        /// <typeparam name="T"> The identifying type, should be an interface </typeparam>
        /// <param name="creator"> The method by which the type is created, usually a constructor </param>
        /// <returns></returns>
        IMediator RegisterFactory<T>(Func<Object> creator);
    }
}
