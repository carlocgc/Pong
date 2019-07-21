using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Table;

namespace Pong.Table.Tables
{
    public class NormalTable : ITable
    {
        private readonly Texture2D _Texture;

        public NormalTable(IContentService content, IRenderService renderService)
        {
            _Texture = content.Load<Texture2D>(Data.Assets.Background);
            renderService.Register(this);
        }

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, new Vector2(0, 0), Color.Black);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region IDisposable

        public void Dispose()
        {
        }

        #endregion
    }
}
