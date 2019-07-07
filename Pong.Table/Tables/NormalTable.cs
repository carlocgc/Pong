using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Table;

namespace Pong.Table.Tables
{
    public class NormalTable : ITable
    {
        private readonly Random _Rand = new Random(Environment.TickCount);

        private readonly Texture2D _Texture;

        private readonly TimeSpan _ColourChangeTime;

        private TimeSpan _Elapsed;

        private Color _Color;

        public NormalTable(IContentService content)
        {
            _Texture = content.Load<Texture2D>(Data.Assets.Background);
            _ColourChangeTime = TimeSpan.FromSeconds(1);
            _Color = GetRandomColor();
        }

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, new Vector2(0, 0), _Color);
        }

        #endregion

        /// <summary>
        /// Gets a random colour
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            return new Color()
            {
                R = (Byte)_Rand.Next(1, 255),
                G = (Byte)_Rand.Next(1, 255),
                B = (Byte)_Rand.Next(1, 255),
                A = (Byte)255,
            };
        }

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            _Elapsed += gameTime.ElapsedGameTime;
            if (_Elapsed < _ColourChangeTime) return;
            _Color = GetRandomColor();
            _Elapsed = TimeSpan.Zero;
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
