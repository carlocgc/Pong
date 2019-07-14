using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Core;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Table;

namespace Pong.Core
{
    public class GameInstance
    {
        private IMediator _Mediator;
        private IStateService _StateService;
        private IBall _Ball;
        private ITable _Table;

        public GameInstance(IMediator mediator)
        {
            _Mediator = mediator;
            _StateService = _Mediator.GetInstance<IStateService>();
            _Ball = _Mediator.GetInstance<IBall>();
            _Table = _Mediator.GetInstance<ITable>();
        }

        public void Init()
        {
            _Ball.Start();
        }
    }
}
