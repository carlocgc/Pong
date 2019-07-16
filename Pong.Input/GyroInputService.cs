using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Input;

namespace Pong.Input
{
    public class GyroInputService : IInputService
    {
        #region Implementation of INotifer<IInputListener>

        public void AddListener(IInputListener listener)
        {

        }

        public void RemoveListener(IInputListener listener)
        {

        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
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
