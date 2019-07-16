using System;
using Pong.Interfaces.Input;

namespace Pong.Input
{
    /// <summary>
    /// The current state of a button, passed to input listeners
    /// </summary>
    public class ButtonState : IButtonState
    {
        #region Implementation of IButtonState

        public String Name { get; }
        public Boolean IsPressed { get; set; }
        public Boolean IsHeld { get; set; }

        #endregion

        public ButtonState(String name, Boolean isPressed, Boolean isHeld)
        {
            Name = name;
            IsPressed = isPressed;
            IsHeld = isHeld;
        }
    }
}
