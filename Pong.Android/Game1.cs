using Microsoft.Xna.Framework;
using Pong.Android.Source.Services;
using Pong.Ball.Balls;
using Pong.Deploy;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Input;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;
using Pong.Table.Tables;
using Pong.UI.Objects;

namespace Pong.Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : DeployGame
    {

        public Game1() : base()
        {
            _GraphicsDeviceManager.IsFullScreen = true;
            _GraphicsDeviceManager.PreferredBackBufferWidth = 1920;
            _GraphicsDeviceManager.PreferredBackBufferHeight = 1080;
            _GraphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here
            base.LoadContent();

            _InputService = _Mediator.RegisterService<IInputService, GyroInputService>(new GyroInputService(_UpdateService));
            _Mediator.RegisterCreator<ILoadingScreen>(() => new LoadingScreen(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new InputTestBall(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale, _InputService));
            //_Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale));

            _GameInstance.Init();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
