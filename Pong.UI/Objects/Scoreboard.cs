using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Interfaces.UI;

namespace Pong.UI.Objects
{
    public class Scoreboard : IScoreboard
    {
        #region Implementation of IScoreboard

        public Int32 PlayerScore { get; set; }
        public Int32 EnemyScore { get; set; }
        public void Reset()
        {

        }

        #endregion
    }
}
