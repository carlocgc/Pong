using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Ball.Balls;
using Pong.Deploy;
using Pong.Enemy;
using Pong.Input;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Enemy;
using Pong.Interfaces.Input;
using Pong.Interfaces.Player;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;
using Pong.Player;
using Pong.Table.Tables;
using Pong.UI.Objects;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace Pong.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DesktopGame : DeployGame
    {
        public DesktopGame() : base()
        {
            _GraphicsDeviceManager.PreferredBackBufferWidth = 1280;
            _GraphicsDeviceManager.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add Desktop specific initialization

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

            _InputService = _Mediator.RegisterService<IInputService, GamePadInputService>(new GamePadInputService(_UpdateService));
            _Mediator.RegisterCreator<ILoadingScreen>(() => new LoadingScreen(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale));
            _Mediator.RegisterCreator<IPlayer>(() => new NormalPlayer(_ContentService, _RenderService, _PhysicsService, _UpdateService, _InputService, _VirtualWindowScale));
            _Mediator.RegisterCreator<IEnemy>(() => new NormalEnemy(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale));

            _GameInstance.Init();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);

            // TODO: Add your update logic here
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
