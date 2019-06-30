using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Physics.Service
{
    public class PhysicsService : IPhysicsService, 
    {
        private IMediator _Mediator;

        public PhysicsService(IMediator mediator)
        {
            _Mediator = mediator;
        }

        #region Implementation of IPhysicsService

        /// <summary> Register a collider with the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public IPhysicsService RegisterCollider(ICollider collider)
        {
            
        }

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public IPhysicsService DeRegisterCollider(ICollider collider)
        {
            
        }

        /// <summary> Start physics service </summary>
        public void Start()
        {
           
        }

        /// <summary> Stop the physics service </summary>
        public void Stop()
        {
           
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {

        }

        #endregion
    }
}
