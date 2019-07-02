using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;

namespace Pong.Interfaces.Ball
{
    public interface IBall : IRenderable, IDisposable, IUpdateable
    {
        /// <summary> Reset ball </summary>
        void Reset();

        /// <summary> Start ball behaviour </summary>
        void Start();
    }
}
