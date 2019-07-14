using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Core
{
    public interface IStateService : IUpdateable, IDisposable
    {
        void SetState(IState state);
    }
}
