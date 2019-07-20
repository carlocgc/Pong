using Microsoft.Xna.Framework;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Roles;

namespace Pong.Interfaces.Enemy
{
    public interface IEnemy : ICollider, IRenderable, IUpdateable, IResetable
    {
    }
}
