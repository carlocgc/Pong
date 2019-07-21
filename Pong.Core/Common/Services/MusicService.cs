using System;
using Microsoft.Xna.Framework.Audio;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;

namespace Pong.Core.Common.Services
{
    public class MusicService : IMusicService
    {
        private readonly IContentService _ContentService;

        private SoundEffectInstance _CurrentSong;

        public MusicService(IContentService contentService)
        {
            _ContentService = contentService;
        }

        #region Implementation of IMusicService

        public void PlayMusic(String path, Single volume = 1f, Boolean loop = true)
        {
            _CurrentSong?.Stop(true);

            try
            {
                SoundEffect song = _ContentService.Load<SoundEffect>(path);
                _CurrentSong = song.CreateInstance();
                _CurrentSong.Volume = volume;
                _CurrentSong.IsLooped = loop;
                _CurrentSong.Play();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{path} sound effect content cannot be found. {e}");
            }
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            _CurrentSong?.Stop(true);
            _CurrentSong?.Dispose();
        }

        #endregion
    }
}
