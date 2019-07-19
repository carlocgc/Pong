using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;
using Pong.Interfaces.Player;

namespace Pong.Player
{
    public class NormalPlayer : IPlayer
    {
        private Texture _Texture;

        public NormalPlayer(IContentService contentService, IPhysicsService physicsService, IUpdateService updateService)
        {
            _Texture = contentService.Load<Texture2D>()
        }

        #region Implementation of ICollider

        /// <summary> Bounds of the collider </summary>
        public Rectangle BoundingRect { get; }

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
    }
}
