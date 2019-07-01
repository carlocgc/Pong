using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Ball.Balls
{
    /// <summary>
    /// A standard ball
    /// </summary>
    public class NormalBall : IBall, ICollider, IDisposable
    {
        /// <summary> The balls texture </summary>
        private readonly Texture2D _Texture;

        public Vector2 Position { get; set; }

        public NormalBall(IContentService contentService)
        {
            _Texture = contentService.Load<Texture2D>(Data.Assets.Ball);
            Position = new Vector2(200, 200);
        }

        #region Implementation of ICollider

        /// <summary> Rectangular bounds of the collider </summary>
        public Rectangle BoundingRect => new Rectangle(Position.ToPoint(), new Point(_Texture.Width, _Texture.Height));

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        public void Collide(ICollider collider)
        {

        }

        #endregion

        #region Implementation of IBall

        /// <summary> Reset ball </summary>
        public void Reset()
        {

        }

        /// <summary> Start ball behaviour </summary>
        public void Start()
        {

        }

        #endregion

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, BoundingRect.Location.ToVector2(), Color.White);
        }

        #endregion

        #region IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _Texture?.Dispose();
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {

        }

        public Boolean Enabled => true;
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion
    }
}
