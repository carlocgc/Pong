using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Ball
{
    public interface IBallGoalListener
    {
        void OnGoal(Boolean playerScored);
    }
}
