using System;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Mediation.Tests.Mocks
{
    /// <summary>
    /// Test service
    /// </summary>
    public class MockService : IPhysicsService
    {
        #region Implementation of IDisposable

        public void Dispose()
        {

        }

        #endregion

        #region Implementation of IUpdateable
        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Implementation of IPhysicsService

        /// <summary> Register a collider with the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public IPhysicsService RegisterCollider(ICollider collider)
        {
            throw new NotImplementedException();
        }

        /// <summary> Deregister a collider from the physics service </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public IPhysicsService DeRegisterCollider(ICollider collider)
        {
            throw new NotImplementedException();
        }

        /// <summary> Start physics service </summary>
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary> Stop the physics service </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
