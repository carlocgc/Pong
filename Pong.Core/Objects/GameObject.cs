using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakernoid
{
    public abstract class GameObject
    {
        /// <summary> The game file associated with the object </summary>
        protected readonly Game _Game;
        /// <summary> Texture asset name </summary>
        protected string _TextureName = "";
        /// <summary> The actual texture </summary>
        protected Texture2D _Texture;
        /// <summary> Postion of the object on screen (0, 0) by default </summary>
        public Vector2 Position = Vector2.Zero;

        /// <summary> Width of texture </summary>
        public float Width => _Texture.Width;

        /// <summary> Height of texture </summary>
        public float Height => _Texture.Height;

        /// <summary> Rectangle of texture for checking boundaries on collisions with power ups </summary>
        public Rectangle BoundingRect
        {
            get
            {
                // Remember the posistion is calculated from center but rectangle needs top left/right
                // so width/height / 2 must be deducted
                Rectangle rect = new Rectangle((int)Position.X - (int)(Width / 2), (int)Position.Y - (int)(Height / 2), _Texture.Width, _Texture.Height);
                return rect;
            }
        }

        /// <summary> Base Constructor </summary>
        public GameObject(Game myGame)
        {
            _Game = myGame;
        }

        /// <summary> Load object content here </summary>
        public virtual void LoadContent()
        {
            if (_TextureName != "")
            {
                _Texture = _Game.Content.Load<Texture2D>(_TextureName);
            }
        }

        /// <summary> Update logic for object </summary>
        public virtual void Update(Single deltaTime)
        {
        }

        /// <summary> Draw object logic </summary>
        public virtual void Draw(SpriteBatch batch)
        {
            if (_Texture == null) return;

            // Position as a vector2 
            Vector2 drawPosition = Position;
            // Texture position is calculated from top left of the asset, Vector2 pos is from top left
            // So position needs to be adjusted by half the asset size in both vectors x and y
            // This moves the asset left and up to center it on the Vector2
            drawPosition.X -= _Texture.Width / 2;
            drawPosition.Y -= _Texture.Height / 2;
            // Draw object
            batch.Draw(_Texture, drawPosition, Color.White);
        }
    }
}
