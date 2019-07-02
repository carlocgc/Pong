using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Core
{
    /// <summary>
    /// Update service that calls update on all registered <see cref="IUpdateable"/>s
    /// </summary>
    public interface IUpdateService : IUpdateable, IDisposable
    {
        /// <summary> Add an object to update </summary>
        /// <param name="updateable"></param>
        IUpdateService Register(IUpdateable updateable);

        /// <summary> Remove an object </summary>
        /// <param name="updateable"></param>
        IUpdateService Deregister(IUpdateable updateable);
    }
}
