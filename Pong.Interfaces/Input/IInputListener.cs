using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Input
{
    public interface IInputListener
    {
        void InputUpdate(Vector2 direction, List<IButtonState> buttons);
    }
}
