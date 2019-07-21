using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.UI
{
    public interface ILoadingScreen : INotifer<ILoadingScreenListener>, IRenderable, IUpdateable, IDisposable
    {
        void SetActive(Boolean active);
    }
}
