using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.Player
{
    public interface IPlayer : ICollider, IRenderable, IUpdateable, IResetable, ITransform
    {
    }
}
