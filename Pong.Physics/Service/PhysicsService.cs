using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Physics.Service
{
    /// <summary>
    /// Basic physics system that check collisions between objects
    /// </summary>
    public class PhysicsService : IPhysicsService
    {
        private readonly List<ICollider> _Colliders = new List<ICollider>();

        public PhysicsService(IUpdateService updateService)
        {
            updateService.Register(this);
        }

        #region Implementation of IPhysicsService

        /// <summary> Register a collider with the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public void RegisterCollider(ICollider collider)
        {
            if (!_Colliders.Contains(collider)) _Colliders.Add(collider);
        }

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public void DeRegisterCollider(ICollider collider)
        {
            if (_Colliders.Contains(collider)) _Colliders.Remove(collider);
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _Colliders.Clear();
        }

        #endregion

        private void CheckCollisions(CollisionGroup groupA, CollisionGroup groupB)
        {
            List<ICollider> collidersA = _Colliders.Where(col => col.CollisionGroup == groupA).ToList();
            List<ICollider> collidersB = _Colliders.Where(col => col.CollisionGroup == groupB).ToList();
            foreach (ICollider colA in collidersA)
            {
                foreach (ICollider colB in collidersB)
                {
                    if (!colA.BoundingRect.Intersects(colB.BoundingRect)) continue;
                    colA.Collide(colB);
                    colB.Collide(colA);
                }
            }
        }

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            CheckCollisions(CollisionGroup.BALL, CollisionGroup.PADDLE);
        }

        public Boolean Enabled { get; private set; }
        public Int32 UpdateOrder { get; private set; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion
    }
}
