using System;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;
using Pong.Interfaces.Mediator;

namespace Pong.Core.Common.States
{
    public abstract class BaseState : IState
    {
        protected readonly IMediator _Mediator;

        protected readonly IStateService _StateService;

        protected BaseState(IMediator mediator)
        {
            _Mediator = mediator;
            _StateService = _Mediator.GetInstance<IStateService>();
        }

        protected virtual void EndState(IState nextState = null)
        {
            _StateService.SetState(nextState);
        }

        #region Implementation of IState

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
            Dispose();
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

        #region Implementation of IDisposable

        public void Dispose()
        {
        }

        #endregion
    }
}
