using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Physics.Service;

namespace Pong.Interfaces.Physics.Colliders
{
    public enum CollisionGroup
    {
        BALL,
        PADDLE,
    }

    /// <summary>
    /// Collider used with <see cref="IPhysicsService"/>
    /// </summary>
    public interface ICollider
    {
        /// <summary> Bounds of the collider </summary>
        Rectangle BoundingRect { get; }

        /// <summary> The collision group this collider belongs to, used to only check collisions between particular groups </summary>
        CollisionGroup CollisionGroup { get; }

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        void Collide(ICollider collider);
    }
}
