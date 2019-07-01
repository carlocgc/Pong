using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Interfaces.Graphics
{
    /// <summary>
    /// Adds draw functionality to implementing classes
    /// </summary>
    public interface IRenderable
    {
        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
