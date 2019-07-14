using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;

namespace Pong.Interfaces.Table
{
    public interface ITable : IRenderable, IUpdateable, IDisposable
    {
    }
}
