using Pong.Interfaces.Ball;
using Pong.Interfaces.Enemy;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Player;
using Pong.Interfaces.Table;

namespace Pong.Core.Common.States
{
    public class PlayingState : BaseState
    {
        private IBall _Ball;
        private ITable _Table;
        private IPlayer _Player;
        private IEnemy _Enemy;

        public PlayingState(IMediator mediator) : base(mediator)
        {
        }

        #region Overrides of BaseState

        public override void OnEnter()
        {
            base.OnEnter();
            _Table = _Mediator.Create<ITable>();
            _Ball = _Mediator.Create<IBall>();
            _Player = _Mediator.Create<IPlayer>();
            _Enemy = _Mediator.Create<IEnemy>();

            _Ball.Start();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        #endregion
    }
}
