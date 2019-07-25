using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Input;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;
using Pong.Interfaces.Player;

namespace Pong.Player
{
    public class NormalPlayer : IPlayer, IInputListener
    {
        private readonly Texture2D _Texture;

        private readonly Vector2 _StartPosition;

        private readonly Vector2 _ScreenSize;

        private readonly Single _Speed;

        private Vector2 _Position;

        /// <summary> Direction the collider is moving </summary>
        public Vector2 Direction { get; private set; }

        /// <summary> Bounds of the collider </summary>
        public Rectangle BoundingRect { get; private set; }

        /// <summary> The collision group this collider belongs to, used to only check collisions between particular groups </summary>
        public CollisionGroup CollisionGroup { get; }

        public Vector2 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                BoundingRect = new Rectangle((Int32)_Position.X, (Int32)_Position.Y, _Texture.Width, _Texture.Height);
            }
        }

        public NormalPlayer(IContentService contentService, IRenderService renderService, IUpdateService updateService, IPhysicsService physicsService, IInputService inputService, Vector2 screenSize)
        {
            _Texture = contentService.Load<Texture2D>(Data.Graphics.Player);
            _StartPosition = new Vector2(200, 540 - _Texture.Height / 2);
            Position = _StartPosition;
            _ScreenSize = screenSize;
            _Speed = 650f;
            CollisionGroup = CollisionGroup.PADDLE;
            renderService.Register(this);
            updateService.Register(this);
            physicsService.Register(this);
            inputService.AddListener(this);
        }

        #region Implementation of ICollider

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
            Position += new Vector2(0, Direction.Y) * _Speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            if (Position.Y < 0) Position = new Vector2(Position.X, 0);
            else if (Position.Y + _Texture.Height > _ScreenSize.Y) Position = new Vector2(Position.X, _ScreenSize.Y - _Texture.Height);
        }

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

        #region Implementation of IInputListener

        public void InputUpdate(Vector2 direction, List<IButtonState> buttons)
        {
            Direction = direction;
        }

        #endregion
    }
}
