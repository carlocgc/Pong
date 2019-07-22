using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;

namespace Pong.Ball.Balls
{
    /// <summary>
    /// A standard ball
    /// </summary>
    public class NormalBall : IBall
    {
        /// <summary> Random number generator </summary>
        private readonly Random _Rand = new Random(Environment.TickCount);
        /// <summary> The balls texture </summary>
        private readonly Texture2D _Texture;
        /// <summary> The size of the game screen, used for edge checking </summary>
        private readonly Vector2 _ScreenSize;
        /// <summary> The center of the screen </summary>
        private readonly Vector2 _StartPosition;
        /// <summary> Base movement speed </summary>
        private readonly Single _Speed;
        /// <summary> Sound of the ball colliding </summary>
        private readonly SoundEffectInstance _ImpactSfx;
        /// <summary> Sound of the player scoring </summary>
        private readonly SoundEffectInstance _PlayerScoreSfx;
        /// <summary> Sound of the enemy scoring </summary>
        private readonly SoundEffectInstance _EnemyScoreSfx;
        /// <summary> Whether the ball is active/moving </summary>
        private Boolean _Active;

        /// <summary> Position of the ball </summary>
        private Vector2 _Position;

        /// <summary> Rectangular bounds of the collider </summary>
        public Rectangle BoundingRect { get; private set; }

        /// <summary> THe direction the ball is moving </summary>
        public Vector2 Direction { get; private set; }

        /// <summary> The collision group this collider belongs to, used to only check collisions between particular groups </summary>
        public CollisionGroup CollisionGroup { get; }

        /// <summary> Position of the ball </summary>
        public Vector2 Position
        {
            get => _Position;
            set
            {
                _Position = value;
                BoundingRect = new Rectangle((Int32)Position.X, (Int32)Position.Y, _Texture.Width, _Texture.Height);
                foreach (IBallMovementListener listener in _MoveListeners)
                {
                    listener.OnBallMoved(value);
                }
            }
        }

        public NormalBall(IContentService contentService, IRenderService renderService, IUpdateService updateService, IPhysicsService physicsService, Vector2 screenSize)
        {
            _ImpactSfx = contentService.Load<SoundEffect>(Data.Sounds.Impact).CreateInstance();
            _PlayerScoreSfx = contentService.Load<SoundEffect>(Data.Sounds.PlayerScored).CreateInstance();
            _EnemyScoreSfx = contentService.Load<SoundEffect>(Data.Sounds.EnemyScored).CreateInstance();
            _Texture = contentService.Load<Texture2D>(Data.Graphics.Ball);
            _ScreenSize = screenSize;
            _Speed = 700f;
            Position = _StartPosition = _ScreenSize / 2;
            CollisionGroup = CollisionGroup.BALL;
            updateService.Register(this);
            renderService.Register(this);
            physicsService.Register(this);
        }

        #region Implementation of ICollider

        /// <summary>
        /// Cause collision behaviour
        /// </summary>
        /// <param name="collider"> The collider this object collided with </param>
        /// <returns></returns>
        public void Collide(ICollider collider)
        {
            _ImpactSfx.Stop(true);
            _ImpactSfx.Play();
            Vector2 postColPos = Position;

            // Move ball so it is no longer intersecting and set a new direction

            if (BoundingRect.Center.Y < collider.BoundingRect.Top) // Ball is above the collider
            {
                Position = new Vector2(postColPos.X, collider.BoundingRect.Top - BoundingRect.Height);
                Direction = new Vector2(Direction.X, -1);
                return;
            }
            if (BoundingRect.Center.Y > collider.BoundingRect.Bottom) // Ball is below the collider
            {
                Position = new Vector2(postColPos.X, collider.BoundingRect.Bottom);
                Direction = new Vector2(Direction.X, 1);
                return;
            }

            if (BoundingRect.Center.X > collider.BoundingRect.Right) // Ball is on the right side of a collider
            {
                postColPos = new Vector2(collider.BoundingRect.Right, postColPos.Y);
                Direction = new Vector2(1, Direction.Y);
            }
            else if (BoundingRect.Center.X < collider.BoundingRect.Left) // Ball is on the left side of a collider
            {
                postColPos = new Vector2(collider.BoundingRect.Left - BoundingRect.Width, postColPos.Y);
                Direction = new Vector2(-1, Direction.Y);
            }

            Position = postColPos;
        }

        #endregion

        #region Implementation of IBall

        /// <summary> Reset ball </summary>
        public void Reset()
        {
            _Active = false;
            Position = _StartPosition;
        }

        /// <summary> Start ball behaviour </summary>
        public void Start()
        {
            Direction = GetRandomDirection();
            Direction.Normalize();
            _Active = true;
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
            Int32[] angles = { 45, 135, 225, 315 };
            Int32 angle = angles[_Rand.Next(0, angles.Length)];
            Single radians = (Single)(angle * Math.PI / 180f);
            Single x = (Single)Math.Cos(radians);
            Single y = (Single)Math.Sin(radians);
            return new Vector2(x, y);
        }

        /// <summary>
        /// Checks the object are within the given bounds
        /// </summary>
        /// <param name="objectBounds"></param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        private void CheckScreenBounds(Rectangle objectBounds, Vector2 screenSize)
        {
            Single x = Position.X;
            Single y = Position.Y;
            if (objectBounds.X < 0)
            {
                _EnemyScoreSfx.Stop(true);
                _EnemyScoreSfx.Play();
                for (var index = _GoalListeners.Count - 1; index >= 0; index--)
                {
                    IBallGoalListener listener = _GoalListeners[index];
                    listener.OnGoal(false);
                }
                return;
            }
            if (objectBounds.X + objectBounds.Width > screenSize.X)
            {
                _PlayerScoreSfx.Stop(true);
                _PlayerScoreSfx.Play();
                for (var index = _GoalListeners.Count - 1; index >= 0; index--)
                {
                    IBallGoalListener listener = _GoalListeners[index];
                    listener.OnGoal(true);
                }
                return;
            }

            if (objectBounds.Y < 0)
            {
                y = 0;
                Direction = new Vector2(Direction.X, Direction.Y * -1);
            }
            else if (objectBounds.Y + objectBounds.Height > screenSize.Y)
            {
                y = screenSize.Y - objectBounds.Height;
                Direction = new Vector2(Direction.X, Direction.Y * -1);
            }
            Position = new Vector2(x, y);
        }

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            if (!_Active) return;
            Position += Direction * _Speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            CheckScreenBounds(BoundingRect, _ScreenSize);
        }

        public Boolean Enabled => true;
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Implementation of INotifer<IBallListener>

        private readonly List<IBallGoalListener> _GoalListeners = new List<IBallGoalListener>();

        public void AddListener(IBallGoalListener listener)
        {
            if (!_GoalListeners.Contains(listener)) _GoalListeners.Add(listener);
        }

        public void RemoveListener(IBallGoalListener listener)
        {
            if (_GoalListeners.Contains(listener)) _GoalListeners.Remove(listener);
        }

        #endregion

        #region Implementation of INotifer<IBallMovementListener>
        private readonly List<IBallMovementListener> _MoveListeners = new List<IBallMovementListener>();

        public void AddListener(IBallMovementListener listener)
        {
            if (!_MoveListeners.Contains(listener)) _MoveListeners.Add(listener);
        }

        public void RemoveListener(IBallMovementListener listener)
        {
            if (_MoveListeners.Contains(listener)) _MoveListeners.Remove(listener);
        }

        #endregion
    }
}
