using System;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Core;
using Pong.Interfaces.Enemy;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Player;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;

namespace Pong.Core.Common.States
{
    public class PlayingState : BaseState, IBallGoalListener
    {
        private IBall _Ball;
        private ITable _Table;
        private IPlayer _Player;
        private IEnemy _Enemy;
        private IScoreboard _Scoreboard;

        public PlayingState(IMediator mediator) : base(mediator)
        {
        }

        #region Overrides of BaseState

        public override void OnEnter()
        {
            base.OnEnter();

            _Mediator.GetInstance<IMusicService>().PlayMusic(Data.Sounds.Bgm);

            _Table = _Mediator.Create<ITable>();
            _Scoreboard = _Mediator.Create<IScoreboard>();
            _Player = _Mediator.Create<IPlayer>();
            _Enemy = _Mediator.Create<IEnemy>();
            _Ball = _Mediator.Create<IBall>();
            _Ball.AddListener(_Enemy);
            _Ball.AddListener(this);
            _Ball.Start();
        }

        #endregion

        #region Implementation of IBallListener

        public void OnGoal(Boolean playerScored)
        {
            if (playerScored) _Scoreboard.PlayerScore = _Scoreboard.PlayerScore + 1;
            else _Scoreboard.EnemyScore = _Scoreboard.EnemyScore + 1;
            _Player.Reset();
            _Enemy.Reset();
            _Ball.Reset();
            _Ball.Start();
        }

        #endregion
    }
}
