using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Ball.Balls
{
    public class NormalBall : IBall, ICollider
    {
        public NormalBall() : base()
        {
        }

        #region Implementation of ICollider


        /// <summary> Rectangular bounds of the collider </summary>
        public Rectangle BoundingRect { get; }

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        public void Collide(ICollider collider)
        {

        }

        #endregion

        #region Implementation of IBall

        /// <summary> Reset ball </summary>
        public void Reset()
        {
         
        }

        /// <summary> Start ball behaviour </summary>
        public void Start()
        {
         
        }

        #endregion
    }
}
