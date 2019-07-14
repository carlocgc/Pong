using Pong.Interfaces.Mediator;
using Pong.Interfaces.UI;

namespace Pong.Core.Common.States
{
    public class LoadingState : BaseState, ILoadingScreenListener
    {
        private ILoadingScreen _LoadingScreen;

        public LoadingState(IMediator mediator) : base(mediator)
        {
        }

        #region Overrides of BaseState

        public override void OnEnter()
        {
            base.OnEnter();
            _LoadingScreen = _Mediator.Create<ILoadingScreen>();
            _LoadingScreen.AddListener(this);
            _LoadingScreen.SetActive(true);
        }

        #endregion

        #region Implementation of ILoadingScreenListener

        public void OnLoadingScreenComplete(ILoadingScreen loadingScreen)
        {
            EndState(new PlayingState(_Mediator));
        }

        #endregion
    }
}
