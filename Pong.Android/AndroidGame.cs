using Microsoft.Xna.Framework;
using Pong.Android.Source.Services;
using Pong.Ball.Balls;
using Pong.Deploy;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Input;
using Pong.Interfaces.Player;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;
using Pong.Player;
using Pong.Table.Tables;
using Pong.UI.Objects;

namespace Pong.Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AndroidGame : DeployGame
    {

        public AndroidGame() : base()
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
            // TODO: use this.Content to load your game content here
            base.LoadContent();

            _InputService = _Mediator.RegisterService<IInputService, GyroInputService>(new GyroInputService(_UpdateService, Window.CurrentOrientation));
            _Mediator.RegisterCreator<ILoadingScreen>(() => new LoadingScreen(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale));
            _Mediator.RegisterCreator<IPlayer>(() => new NormalPlayer(_ContentService, _RenderService, _PhysicsService, _UpdateService, _InputService, _VirtualWindowScale));

            _GameInstance.Init();
        }
    }
}
