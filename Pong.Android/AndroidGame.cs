using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Android.Source.Services;
using Pong.Core.Common.Services;
using Pong.Deploy;
using Pong.Interfaces.Core;
using Pong.Interfaces.Input;

namespace Pong.Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AndroidGame : DeployGame
    {
        public AndroidGame()
        {
            _GraphicsDeviceManager.IsFullScreen = true;
            _GraphicsDeviceManager.PreferredBackBufferWidth = 1920;
            _GraphicsDeviceManager.PreferredBackBufferHeight = 1080;
            _GraphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _InputService = _Mediator.RegisterService<IInputService, GyroInputService>(new GyroInputService(_UpdateService, Window.CurrentOrientation));

            base.LoadContent();
        }
    }
}
