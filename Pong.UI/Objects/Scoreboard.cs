using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.UI;

namespace Pong.UI.Objects
{
    public class Scoreboard : IScoreboard
    {

        private readonly SpriteFont _Scorefont;

        private Vector2 _PlayerScorePosition;

        private Vector2 _EnemyScorePosition;

        #region Implementation of IScoreboard

        public Int32 PlayerScore { get; set; }

        public Int32 EnemyScore { get; set; }

        public Scoreboard(IContentService contentService, IRenderService renderService, IUpdateService updateService)
        {
            _Scorefont = contentService.Load<SpriteFont>(Data.Assets.ScoreFont);
            _PlayerScorePosition = new Vector2(500, 50);
            _EnemyScorePosition = new Vector2(1400, 50);
            renderService.Register(this);
            updateService.Register(this);
        }

        public void Reset()
        {
            PlayerScore = 0;
            EnemyScore = 0;
        }

        #endregion

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_Scorefont, PlayerScore.ToString(), _PlayerScorePosition, Color.White);
            spriteBatch.DrawString(_Scorefont, EnemyScore.ToString(), _EnemyScorePosition, Color.White);
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
