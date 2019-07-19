using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;

namespace Pong.Interfaces.Player
{
    public interface IPlayer : ICollider, IRenderable, IUpdateable
    {
    }
}
