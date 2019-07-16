using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.Input
{
    public interface IInputService : INotifer<IInputListener>, IUpdateable, IDisposable
    {
    }
}
