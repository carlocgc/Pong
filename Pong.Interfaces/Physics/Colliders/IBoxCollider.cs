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
    /// Box collider used in an <see cref="IPhysicsService"/>
    /// </summary>
    public interface IBoxCollider : ICollider
    {
        /// <summary> Rectangular bounds of the collider </summary>
        Rectangle BoundingRect { get; }
    }
}
