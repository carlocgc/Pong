using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Ball.Balls;
using Pong.Core;
using Pong.Core.Common.Services;
using Pong.Enemy;
using Pong.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Enemy;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Input;
using Pong.Interfaces.Physics.Colliders;
using Pong.Interfaces.Physics.Service;
using Pong.Interfaces.Player;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;
using Pong.Mediation;
using Pong.Physics.Service;
using Pong.Player;
using Pong.Table.Tables;
using Pong.UI.Objects;
using ContentService = Pong.Content.ContentService;

namespace Pong.Deploy
{
    public class DeployGame : Game
    {
        /// <summary> Monogame graphics device </summary>
        protected readonly GraphicsDeviceManager _GraphicsDeviceManager;
        /// <summary> The window scale all the graphics are relative to, this is used to create a scale matrix for spritebatch.begin, keeping the game scaled within any sized window </summary>
        protected readonly Vector2 _VirtualWindowScale;
        /// <summary> Sprite batch used for drawing </summary>
        protected SpriteBatch _SpriteBatch;
        /// <summary> The top level object of the scene graph </summary>
        protected GameInstance _GameInstance;
        /// <summary> Mediator between modules, can create or provide objects and services requested by interface</summary>
        protected Mediator _Mediator;
        /// <summary> Updates all registered <exception cref="IUpdateable">'s </exception></summary>
        protected IUpdateService _UpdateService;
        /// <summary> Content wrapper, used to get assets from the content store </summary>
        protected IContentService _ContentService;
        /// <summary> Calls draw on all registered <see cref="IRenderable"/>'s </summary>
        protected IRenderService _RenderService;
        /// <summary> Provides input data to all registered <see cref="IInputListener"/>'s </summary>
        protected IInputService _InputService;
        /// <summary> Checks collisions between all registered <see cref="ICollider"/>'s </summary>
        protected IPhysicsService _PhysicsService;

        protected DeployGame()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _VirtualWindowScale = new Vector2(1920, 1080);
        }

        #region Overrides of Game

        /// <summary>
        /// Create the <see cref="Mediator"/> and <see cref="GameInstance"/>
        /// </summary>
        protected override void Initialize()
        {
            _Mediator = new Mediator();
            _GameInstance = new GameInstance(_Mediator);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(Content));
            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_UpdateService));
            _Mediator.RegisterService<IStateService, StateService>(new StateService(_UpdateService));

            _Mediator.RegisterCreator<ILoadingScreen>(() => new LoadingScreen(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IScoreboard>(() => new Scoreboard(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, _PhysicsService, _VirtualWindowScale));
            _Mediator.RegisterCreator<IPlayer>(() => new NormalPlayer(_ContentService, _RenderService, _UpdateService, _PhysicsService, _InputService, _VirtualWindowScale));
            _Mediator.RegisterCreator<IEnemy>(() => new NormalEnemy(_ContentService, _RenderService, _UpdateService, _PhysicsService, _VirtualWindowScale));

            _GameInstance.Init();

            base.LoadContent();
        }


        /// <summary>
        /// Gets the scale matrix from a virtual resolution, used to keep the game scaled within any sized window
        /// </summary>
        /// <returns> Scale matrix used with spritebatch begin </returns>
        private Matrix GetWindowScalar(Vector2 virtualResolution)
        {
            var scaleX = _GraphicsDeviceManager.GraphicsDevice.Viewport.Width / virtualResolution.X;
            var scaleY = _GraphicsDeviceManager.GraphicsDevice.Viewport.Height / virtualResolution.Y;
            var matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);
            return matrix;
        }

        /// <summary>
        /// Calls draw on the <see cref="IRenderService"/> using the scale matrix
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepPink);

            _SpriteBatch.Begin(transformMatrix: GetWindowScalar(_VirtualWindowScale));
            _RenderService.Draw(gameTime, _SpriteBatch);
            _SpriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Calls update on the <see cref="IUpdateService"/>
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            _UpdateService.Update(gameTime);
            base.Update(gameTime);
        }

        #endregion

    }
}
