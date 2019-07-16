using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Input
{
    public interface IInputEvent
    {
        Vector2 Direction { get; }

        List<IButtonState> ButtonsStates { get; }
    }
}
