using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Physics.Service;

namespace Pong.Interfaces.Physics.Colliders
{
    /// <summary>
    /// Collider used with <see cref="IPhysicsService"/>
    /// </summary>
    public interface ICollider
    {
        /// <summary> Identifier for the type of collider </summary>
        Int32 Type { get; }

        ICollider Collide(ICollider collider);
    }
}
