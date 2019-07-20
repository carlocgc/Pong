using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Input
{
    public interface IInputListener
    {
        void InputUpdate(Vector2 direction, List<IButtonState> buttons);
    }
}
