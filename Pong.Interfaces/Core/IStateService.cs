using System;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Core
{
    public interface IStateService : IUpdateable, IDisposable
    {
        void SetState(IState state);
    }
}
