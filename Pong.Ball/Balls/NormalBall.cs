using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Ball.Balls
{
    public class NormalBall : IBall, IBoxCollider
    {
        #region Implementation of IBoxCollider

        /// <summary> Rectangular bounds of the collider </summary>
        public Rectangle BoundingRect { get; }

        #endregion

        public NormalBall()
        {

        }

        #region Implementation of IBall

        public void Reset()
        {
            Console.WriteLine($"{this} was reset");
        }

        public void Start()
        {
            Console.WriteLine($"{this} has started!");
        }

        #endregion

        #region Implementation of ICollider

        /// <summary> Identifier for the type of collider </summary>
        public Int32 Type { get; }

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        public void Collide(ICollider collider)
        {

        }

        #endregion

    }
}
