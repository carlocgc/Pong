using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.Ball
{
    public interface IBall : ICollider, IRenderable, IDisposable, IUpdateable, IResetable, ITransform
    {
        /// <summary> Start ball behaviour </summary>
        void Start();
    }
}
