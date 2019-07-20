using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Interfaces.Physics.Service
{
    /// <summary>
    /// Service that will detect collisions between colliders
    /// </summary>
    public interface IPhysicsService : IDisposable, IUpdateable
    {
        /// <summary> Register a collider with the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        void RegisterCollider(ICollider collider);

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        void DeRegisterCollider(ICollider collider);
    }
}
