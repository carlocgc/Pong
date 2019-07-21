using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;

namespace Pong.Interfaces.UI
{
    public interface IScoreboard : IRenderable, IUpdateable
    {
        Int32 PlayerScore { get; set; }

        Int32 EnemyScore { get; set; }

        void Reset();
    }
}
