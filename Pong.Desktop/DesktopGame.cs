using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Core.Common.Services;
using Pong.Deploy;
using Pong.Input;
using Pong.Interfaces.Core;
using Pong.Interfaces.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace Pong.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DesktopGame : DeployGame
    {
        public DesktopGame()
        {
            _GraphicsDeviceManager.PreferredBackBufferWidth = 1280;
            _GraphicsDeviceManager.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here

            _SpriteBatch = new SpriteBatch(GraphicsDevice);
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _InputService = _Mediator.RegisterService<IInputService, GamePadInputService>(new GamePadInputService(_UpdateService));

            base.LoadContent();
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
    }
}
