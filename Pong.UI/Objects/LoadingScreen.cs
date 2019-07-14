using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.UI;

namespace Pong.UI.Objects
{
    public class LoadingScreen : ILoadingScreen
    {
        private readonly Texture2D _Screen;
        private readonly IRenderService _RenderService;
        private readonly IUpdateService _UpdateService;

        private Boolean _Active;

        private TimeSpan _DisplayDuration;
        private TimeSpan _ElapsedTime;

        public LoadingScreen(IContentService contentService, IRenderService renderService, IUpdateService updateService)
        {
            _Screen = contentService.Load<Texture2D>(Data.Assets.StartScreen);
            _RenderService = renderService;
            _UpdateService = updateService;
            _RenderService.Register(this);
            _UpdateService.Register(this);
            _DisplayDuration = TimeSpan.FromSeconds(3);
        }

        #region Implementation of ILoadingScreen

        public void SetActive(Boolean active)
        {
            _Active = active;
        }

        #endregion

        #region Implementation of INotifer<ILoadingScreenListener>

        private readonly List<ILoadingScreenListener> _Listeners = new List<ILoadingScreenListener>();
        

        public void AddListener(ILoadingScreenListener listener)
        {
            if (!_Listeners.Contains(listener)) _Listeners.Add(listener);
        }

        public void RemoveListener(ILoadingScreenListener listener)
        {
            if (_Listeners.Contains(listener)) _Listeners.Remove(listener);
        }

        #endregion

        #region Implementation of IRenderable

        /// <summary> Draws the object to screen </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="matrix"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Screen, new Vector2(0,0), Color.White);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            if (!_Active) return;
            _ElapsedTime += gameTime.ElapsedGameTime;
            if (_ElapsedTime < _DisplayDuration) return;

            _Active = false;
            _ElapsedTime = TimeSpan.Zero;
            
            for (var index = _Listeners.Count - 1; index >= 0; index--)
            {
                ILoadingScreenListener listener = _Listeners[index];
                listener.OnLoadingScreenComplete(this);
            }
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _RenderService.Deregister(this);
            _UpdateService.Deregister(this);
        }

        #endregion
    }
}
