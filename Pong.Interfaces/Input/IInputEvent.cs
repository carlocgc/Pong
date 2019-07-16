using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Input
{
    public class IInputEvent
    {
        public Vector2 Direction { get; }

        public List<IButtonState> ButtonsStates { get; }
    }
}
