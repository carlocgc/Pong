using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Physics.Service
{
    /// <summary>
    /// Basic physics system that check collisions between objects
    /// </summary>
    public class PhysicsService : IPhysicsService
    {
        private readonly IMediator _Mediator;

        private List<ICollider> _Colliders;

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
            if (!_Colliders.Contains(collider)) _Colliders.Add(collider);
            return this;
        }

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public IPhysicsService DeRegisterCollider(ICollider collider)
        {
            if (_Colliders.Contains(collider)) _Colliders.Remove(collider);
            return this;
        }

        /// <summary> Start physics service </summary>
        public void Start()
        {
            Enabled = true;
        }

        /// <summary>
        /// Calculates if two rectangles collide
        /// </summary>
        /// <param name="boxA"></param>
        /// <param name="boxB"></param>
        /// <returns></returns>
        private Boolean BoxToBoxIntersect(IBoxCollider boxA, IBoxCollider boxB)
        {
            // TODO Bounding box collision

            return false;
        }

        /// <summary> Stop the physics service </summary>
        public void Stop()
        {
            Enabled = false;
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Stop();
            _Colliders.Clear();
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            
        }

        public Boolean Enabled { get; private set; }
        public Int32 UpdateOrder { get; private set; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion
    }
}
