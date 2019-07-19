using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Input
{
    public interface IButtonState
    {
        String Name { get; }

        Boolean IsPressed { get; set; }

        Boolean IsHeld { get; set; }
    }
}
