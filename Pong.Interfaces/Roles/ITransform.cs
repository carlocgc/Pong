using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Roles
{
    public interface ITransform
    {
        Vector2 Position { get; set; }
    }
}
