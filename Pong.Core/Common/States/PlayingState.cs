using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Core;
using Pong.Interfaces.Table;

namespace Pong.Core.Common.States
{
    public class PlayingState : IState
    {
        private readonly IBall _Ball;
        private ITable _Table;

        public PlayingState(IBall ball, ITable table)
        {
            _Ball = ball;
            _Table = table;
        }

        #region Implementation of IState

        public void OnEnter()
        {
            _Ball.Start();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
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

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
