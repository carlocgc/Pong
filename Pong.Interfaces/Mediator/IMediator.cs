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
        T GetInstance<T>();

        /// <summary>
        /// Creates an instance of the given type
        /// </summary>
        /// <typeparam name="T"> Instance of the given type </typeparam>
        /// <returns></returns>
        T Create<T>();
    }
}
