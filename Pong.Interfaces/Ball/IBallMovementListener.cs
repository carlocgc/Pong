using Microsoft.Xna.Framework;

namespace Pong.Interfaces.Ball
{
    public interface IBallMovementListener
    {
        void OnBallMoved(Vector2 position);
    }
}
