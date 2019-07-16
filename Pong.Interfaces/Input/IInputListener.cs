using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Input
{
    public interface IInputListener
    {
        void InputUpdate(IInputEvent input);
    }
}
