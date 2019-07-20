using System;

namespace Pong.Interfaces.Input
{
    public interface IButtonState
    {
        String Name { get; }

        Boolean IsPressed { get; set; }

        Boolean IsHeld { get; set; }
    }
}
