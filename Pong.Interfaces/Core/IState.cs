using System;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Core
{
    public interface IState : IUpdateable, IDisposable
    {
        void OnEnter();

        void OnExit();
    }
}
