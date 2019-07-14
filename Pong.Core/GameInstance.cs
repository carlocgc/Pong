using Pong.Core.Common.States;
using Pong.Interfaces.Core;
using Pong.Interfaces.Mediator;

namespace Pong.Core
{
    public class GameInstance
    {
        private readonly IMediator _Mediator;

        public GameInstance(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public void Init()
        {
            _Mediator.GetInstance<IStateService>().SetState(new LoadingState(_Mediator));
        }
    }
}
