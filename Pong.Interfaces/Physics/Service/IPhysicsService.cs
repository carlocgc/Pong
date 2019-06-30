using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Interfaces.Physics.Service
{
    /// <summary>
    /// Service that will detect collisions between colliders
    /// </summary>
    public interface IPhysicsService
    {
        /// <summary> Register a collider with the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        IPhysicsService RegisterCollider(ICollider collider);

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        IPhysicsService DeRegisterCollider(ICollider collider);

        /// <summary> Start physics service </summary>
        void Start();

        /// <summary> Stop the physics service </summary>
        void Stop();
    }
}
