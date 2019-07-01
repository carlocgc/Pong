using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Graphics;

namespace Pong.Graphics
{
    public class RenderService : IRenderService
    {
        private readonly List<IRenderable> _Renderables = new List<IRenderable>();

        private readonly SpriteBatch _SpriteBatch;

        public RenderService(SpriteBatch spriteBatch)
        {
            _SpriteBatch = spriteBatch;
            Enabled = true;
        }

        #region Implementation of IRenderService

        /// <summary> Add a renderable to the render service </summary>
        /// <param name="renderable"></param>
        public void Register(IRenderable renderable)
        {
            if (!_Renderables.Contains(renderable)) _Renderables.Add(renderable);
        }

        /// <summary> Remove a renderable from the render service </summary>
        /// <param name="renderable"></param>
        public void Deregister(IRenderable renderable)
        {
            if (_Renderables.Contains(renderable)) _Renderables.Remove(renderable);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            _SpriteBatch.Begin();

            foreach (IRenderable renderable in _Renderables)
            {
                renderable.Draw(gameTime, _SpriteBatch);
            }

            _SpriteBatch.End();
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _SpriteBatch?.Dispose();
            _Renderables.Clear();
        }

        #endregion
    }
}
