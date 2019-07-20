using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Enemy;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Enemy
{
    public class NormalEnemy : IEnemy
    {
        private readonly Texture2D _Texture;

        private readonly Vector2 _StartPosition;

        private readonly Vector2 _ScreenSize;

        private readonly Single _Speed;

        private Vector2 _Position;

        private Vector2 _Direction;

        public Vector2 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                BoundingRect = new Rectangle((Int32)_Position.X, (Int32)_Position.Y - _Texture.Height / 2, _Texture.Width, _Texture.Height);
            }
        }

        #region Implementation of ICollider

        /// <summary> Bounds of the collider </summary>
        public Rectangle BoundingRect { get; private set; }

        /// <summary> The collision group this collider belongs to, used to only check collisions between particular groups </summary>
        public CollisionGroup CollisionGroup { get; }

        public NormalEnemy(IContentService contentService, IRenderService renderService, IUpdateService updateService, IPhysicsService physicsService, Vector2 screenSize)
        {
            _Texture = contentService.Load<Texture2D>(Data.Assets.Enemy);
            _Speed = 800f;
            _ScreenSize = screenSize;
            _StartPosition = new Vector2(1688, 540);
            Position = _StartPosition;
            CollisionGroup = CollisionGroup.PADDLE;
            renderService.Register(this);
            updateService.Register(this);
            physicsService.Register(this);
        }

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        public void Collide(ICollider collider)
        {

        }

        #endregion

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, BoundingRect, Color.White);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            Position += _Direction * _Speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            if (BoundingRect.Y < 0) Position = new Vector2(Position.X, BoundingRect.Height / 2);
            else if (BoundingRect.Y + BoundingRect.Height > _ScreenSize.Y) Position = new Vector2(BoundingRect.X, _ScreenSize.Y - BoundingRect.Height);
        }

        #endregion

        #region Implementation of IUpdateable

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Implementation of IResetable

        public void Reset()
        {
            Position = _StartPosition;
        }

        #endregion

        #region Implementation of IBallMovementListener

        public void OnBallMoved(Vector2 position)
        {
            Vector2 direction = position - Position;
            direction.Normalize();
            _Direction = new Vector2(0, direction.Y);
        }

        #endregion
    }
}
