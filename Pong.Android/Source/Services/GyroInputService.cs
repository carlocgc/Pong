using System;
using System.Collections.Generic;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;
using Pong.Interfaces.Input;

namespace Pong.Android.Source.Services
{
    public class GyroInputService : IInputService
    {
        private Vector2 _Direction;

        private readonly List<IButtonState> _ButtonStates = new List<IButtonState>();

        private readonly Accelerometer _Accelerometer = new Accelerometer();

        public GyroInputService(IUpdateService updateService)
        {
            SensorState state = _Accelerometer.State;
            _Accelerometer.Start();
            updateService.Register(this);
        }

        #region Implementation of INotifer<IInputListener>

        private readonly List<IInputListener> _Listeners = new List<IInputListener>();

        public void AddListener(IInputListener listener)
        {
            if (!_Listeners.Contains(listener)) _Listeners.Add(listener);
        }

        public void RemoveListener(IInputListener listener)
        {
            if (_Listeners.Contains(listener)) _Listeners.Remove(listener);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            // Reversed X and Y because accelerator gives reversed result when x = x / y = y
            Single accX = _Accelerometer.CurrentValue.Acceleration.Y;
            Single accY = _Accelerometer.CurrentValue.Acceleration.X;
            _Direction = new Vector2(accX, accY);

            for (var index = _Listeners.Count - 1; index >= 0; index--)
            {
                IInputListener listener = _Listeners[index];
                listener.InputUpdate(_Direction, _ButtonStates);
            }
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

        }

        #endregion
    }
}
