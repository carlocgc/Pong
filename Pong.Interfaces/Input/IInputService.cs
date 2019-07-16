using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.Input
{
    public interface IInputService : INotifer<IInputListener>, IUpdateable
    {
    }
}
