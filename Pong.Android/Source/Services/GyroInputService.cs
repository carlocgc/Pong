using System;
using System.Collections.Generic;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;
using Pong.Interfaces.Input;

namespace Pong.Android.Source.Services
{
    /// <summary>
    /// Gyroscopic input service
    /// </summary>
    public class GyroInputService : IInputService
    {
        /// <summary> Direction the device is tilted </summary>
        private Vector2 _Direction;
        /// <summary> All button states provided to listeners </summary>
        private readonly List<IButtonState> _ButtonStates = new List<IButtonState>();
        /// <summary> Device accelerometer </summary>
        private readonly Accelerometer _Accelerometer = new Accelerometer();
        /// <summary> The display orientation of the device, used to determine the direction provided to listeners </summary>
        private readonly DisplayOrientation _Orientation;

        public GyroInputService(IUpdateService updateService, DisplayOrientation orientation)
        {
            _Orientation = orientation;
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
            Single accX = 0f;
            Single accY = 0f;

            if ((_Orientation & DisplayOrientation.LandscapeLeft) != 0) // Landscape left
            {
                accX = _Accelerometer.CurrentValue.Acceleration.Y;
                accY = _Accelerometer.CurrentValue.Acceleration.X;
            }
            else if ((_Orientation & DisplayOrientation.LandscapeRight) != 0) // Landscape right
            {
                accX = -_Accelerometer.CurrentValue.Acceleration.Y;
                accY = -_Accelerometer.CurrentValue.Acceleration.X;
            }
            else if ((_Orientation & DisplayOrientation.Portrait) != 0) // Portrait
            {
                accX = _Accelerometer.CurrentValue.Acceleration.X;
                accY = _Accelerometer.CurrentValue.Acceleration.Y;
            }
            else // Reverse Portrait
            {
                accX = -_Accelerometer.CurrentValue.Acceleration.X;
                accY = -_Accelerometer.CurrentValue.Acceleration.Y;
            }

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
