using System;

namespace Pong.Interfaces.Core
{
    public interface IMusicService : IDisposable
    {
        void PlayMusic(String path, Single volume = 1f, Boolean loop = true);
    }
}
