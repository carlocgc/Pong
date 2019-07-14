using Microsoft.Xna.Framework;
using Pong.Interfaces.Physics.Service;

namespace Pong.Interfaces.Physics.Colliders
{
    /// <summary>
    /// Collider used with <see cref="IPhysicsService"/>
    /// </summary>
    public interface ICollider
    {
        /// <summary> Bounds of the collider </summary>
        Rectangle BoundingRect { get; }

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        void Collide(ICollider collider);
    }
}
