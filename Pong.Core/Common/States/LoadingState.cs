using Pong.Interfaces.Mediator;

namespace Pong.Core.Common.States
{
    public class LoadingState : BaseState
    {
        public LoadingState(IMediator mediator) : base(mediator)
        {
        }

        #region Overrides of BaseState

        public override void OnEnter()
        {
            base.OnEnter();
            // TODO Show loading screen

            EndState(new PlayingState(_Mediator));
        }

        #endregion

    }
}
