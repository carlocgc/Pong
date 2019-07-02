using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Interfaces.Graphics
{
    /// <summary>
    /// Adds functionality for drawing registered <see cref="IRenderable"/>s
    /// </summary>
    public interface IRenderService : IUpdateable, IDisposable
    {
        /// <summary> Add a renderable to the render service </summary>
        /// <param name="renderable"></param>
        void Register(IRenderable renderable);

        /// <summary> Remove a renderable from the render service </summary>
        /// <param name="renderable"></param>
        void Deregister(IRenderable renderable);

        /// <summary> Calls draw method on all registered <see cref="IRenderable"/>s </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
