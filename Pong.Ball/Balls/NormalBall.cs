using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Pong.Interfaces.Ball;

namespace Pong.Ball.Balls
{
    public class NormalBall : IBall
    {
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
    }
}
