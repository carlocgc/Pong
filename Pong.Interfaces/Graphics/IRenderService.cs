using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Graphics
{
    /// <summary>
    /// Adds functionality for drawing registered <see cref="IRenderable"/>s
    /// </summary>
    public interface IRenderService
    {
        /// <summary> Add a renderable to the render service </summary>
        /// <param name="renderable"></param>
        void Register(IRenderable renderable);

        /// <summary> Remove a renderable from the render service </summary>
        /// <param name="renderable"></param>
        void Deregister(IRenderable renderable);
    }
}
