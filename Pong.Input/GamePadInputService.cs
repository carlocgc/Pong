using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Interfaces.Core;
using Pong.Interfaces.Input;

namespace Pong.Input
{
    public class GamePadInputService : IInputService
    {
        private Vector2 _Direction;

        private readonly List<IButtonState> _ButtonStates = new List<IButtonState>();

        public GamePadInputService(IUpdateService updateService)
        {
            _ButtonStates.Add(new ButtonState(ButtonName.Confirm, false, false));
            _ButtonStates.Add(new ButtonState(ButtonName.Cancel, false, false));

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
            _Direction = new Vector2(GamePad.GetState(0).ThumbSticks.Left.X, GamePad.GetState(0).ThumbSticks.Left.Y * -1); ;
            SetButtonState(ButtonName.Confirm, Buttons.A);
            SetButtonState(ButtonName.Cancel, Buttons.B);

            for (var index = _Listeners.Count - 1; index >= 0; index--)
            {
                IInputListener listener = _Listeners[index];
                listener.InputUpdate(_Direction, _ButtonStates);
            }
        }

        private void SetButtonState(String buttonName, Buttons xnaButton)
        {
            IButtonState state = _ButtonStates.FirstOrDefault(button => button.Name == buttonName);
            Boolean isDown = GamePad.GetState(0).IsButtonDown(xnaButton);
            state.IsHeld = state.IsPressed && isDown;
            state.IsPressed = !state.IsHeld && isDown;
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _ButtonStates.Clear();
        }

        #endregion
    }
}
