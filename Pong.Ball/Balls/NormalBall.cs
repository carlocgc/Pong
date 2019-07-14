using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Physics.Colliders;
using System;
using System.ComponentModel;

namespace Pong.Ball.Balls
{
    /// <summary>
    /// A standard ball
    /// </summary>
    public class NormalBall : IBall, ICollider
    {
        /// <summary> Random number generator </summary>
        private readonly Random _Rand = new Random(Environment.TickCount);
        /// <summary> The balls texture </summary>
        private readonly Texture2D _Texture;
        /// <summary> The size of the game screen, used for edge checking </summary>
        private readonly Vector2 _ScreenSize;
        /// <summary> The center of the screen </summary>
        private readonly Vector2 _StartPosition;
        /// <summary> Min travel speed </summary>
        private readonly Single _MinSpeed;
        /// <summary> Max travel speed </summary>
        private readonly Single _MaxSpeed;
        /// <summary> Current travel speed </summary>
        private Single _Speed;
        /// <summary> Whether the ball is active/moving </summary>
        private Boolean _Active;
        /// <summary> THe direction the ball is moving </summary>
        private Vector2 _Direction;

        /// <summary> The position of the ball </summary>
        public Vector2 Position { get; set; }

        public NormalBall(IContentService contentService, Vector2 screenDimensions)
        {
            _Texture = contentService.Load<Texture2D>(Data.Assets.Ball);
            _ScreenSize = screenDimensions;
            _MinSpeed = 500;
            _MaxSpeed = 1000;
            _Speed = GetRandomSpeed();
            Position = _StartPosition = _ScreenSize / 2; ;
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
            // TODO Bounce off the collided object
        }

        #endregion

        #region Implementation of IBall

        /// <summary> Reset ball </summary>
        public void Reset()
        {
            // TODO set to start position and stop ball moving
            _Active = false;
            Position = _StartPosition;
        }

        /// <summary> Start ball behaviour </summary>
        public void Start()
        {
            _Direction = GetRandomDirection();
            _Direction.Normalize();
            _Active = true;
        }

        #endregion

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, Position, Color.White);
        }

        #endregion

        #region IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _Texture?.Dispose();
        }

        #endregion

        /// <summary> Get a random direction as a normalized vector </summary>
        private Vector2 GetRandomDirection()
        {
            Single x = (Single)_Rand.NextDouble();
            Single y = (Single)_Rand.NextDouble();
            return new Vector2(x, y);
        }

        /// <summary> Gets a random speed between min and max speed</summary>
        /// <returns></returns>
        private Single GetRandomSpeed()
        {
            return _Rand.Next((Int32)_MinSpeed, (Int32)_MaxSpeed);
        }

        /// <summary>
        /// returns whether the 
        /// </summary>
        /// <param name="objectBounds"></param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        private void KeepWithinScreen(Rectangle objectBounds, Vector2 screenSize)
        {
            Single x = Position.X;
            Single y = Position.Y;
            if (objectBounds.X < 0)
            {
                x = 0;
                _Direction = new Vector2(_Direction.X * -1, _Direction.Y);
                _Speed = GetRandomSpeed();
            }
            else if (objectBounds.X + objectBounds.Width > screenSize.X)
            {
                x = screenSize.X - objectBounds.Width;
                _Direction = new Vector2(_Direction.X * -1, _Direction.Y);
                _Speed = GetRandomSpeed();
            }
            if (objectBounds.Y < 0)
            {
                y = 0;
                _Direction = new Vector2(_Direction.X, _Direction.Y * -1);
                _Speed = GetRandomSpeed();
            }
            else if (objectBounds.Y + objectBounds.Height > screenSize.Y)
            {
                y = screenSize.Y - objectBounds.Height;
                _Direction = new Vector2(_Direction.X, _Direction.Y * -1);
                _Speed = GetRandomSpeed();
            }
            Position = new Vector2(x, y);
        }

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            if (!_Active) return;
            Position += _Direction * _Speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            KeepWithinScreen(BoundingRect, _ScreenSize);
        }

        public Boolean Enabled => true;
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion
    }
}
