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

        private readonly Vector2 _PlayerScoreOrigin;

        private readonly Vector2 _EnemyScoreOrigin;

        private readonly Vector2 _ScoreDivideOrigin;

        #region Implementation of IScoreboard

        public Int32 PlayerScore { get; set; }

        public Int32 EnemyScore { get; set; }

        public Scoreboard(IContentService contentService, IRenderService renderService, IUpdateService updateService)
        {
            _Scorefont = contentService.Load<SpriteFont>(Data.Fonts.ScoreFont);
            _PlayerScoreOrigin = new Vector2(800, 50);
            _EnemyScoreOrigin = new Vector2(1120, 50);
            _ScoreDivideOrigin = new Vector2(960, 50);
            PlayerScore = 0;
            EnemyScore = 0;
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
            // Right align player score to origin position
            Vector2 playerScorePosition = new Vector2(_PlayerScoreOrigin.X - _Scorefont.MeasureString(PlayerScore.ToString()).X, _PlayerScoreOrigin.Y);

            Vector2 scoreDivideSize = _Scorefont.MeasureString(Data.Strings.ScoreDivide);
            Vector2 scoreDividePos = new Vector2(_ScoreDivideOrigin.X - scoreDivideSize.X / 2, _ScoreDivideOrigin.Y);

            spriteBatch.DrawString(_Scorefont, PlayerScore.ToString(), playerScorePosition, Color.White);
            spriteBatch.DrawString(_Scorefont, EnemyScore.ToString(), _EnemyScoreOrigin, Color.White);
            spriteBatch.DrawString(_Scorefont, Data.Strings.ScoreDivide, scoreDividePos, Color.White);
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
