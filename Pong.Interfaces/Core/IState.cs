using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Core
{
    public interface IState : IUpdateable, IDisposable
    {
        void OnEnter();

        void OnExit();
    }
}
