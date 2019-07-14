using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;

namespace Pong.Core.Common.Services
{
    public class StateService : IStateService
    {
        private IState _CurrentState;

        #region Implementation of IDisposable

        public void SetState(IState state)
        {
            _CurrentState?.OnExit();
            _CurrentState = state;
            _CurrentState.OnEnter();
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            _CurrentState?.Update(gameTime);
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion


        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _CurrentState?.Dispose();
            _CurrentState = null;
        }
    }
}
