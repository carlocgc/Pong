using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Input
{
    public class IButtonState
    {
        public String Name { get; }

        public Boolean IsPressed { get; }

        public Boolean IsHeld { get; }
    }
}
