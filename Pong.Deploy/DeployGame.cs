using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Ball.Balls;
using Pong.Core;
using Pong.Core.Common.Services;
using Pong.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Service;
using Pong.Interfaces.Table;
using Pong.Interfaces.UI;
using Pong.Mediation;
using Pong.Physics.Service;
using Pong.Table.Tables;
using Pong.UI.Objects;
using ContentService = Pong.Content.ContentService;

namespace Pong.Deploy
{
    public class DeployGame : Game
    {
        protected readonly GraphicsDeviceManager _GraphicsDeviceManager;
        private readonly Vector2 _VirtualWindowScale;
        private SpriteBatch _SpriteBatch;

        private Mediator _Mediator;
        private GameInstance _GameInstance;

        private IUpdateService _UpdateService;
        private IPhysicsService _PhysicsService;
        private IContentService _ContentService;
        private IRenderService _RenderService;

        protected DeployGame()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _VirtualWindowScale = new Vector2(1920, 1080);
        }

        #region Overrides of Game

        protected override void Initialize()
        {
            _Mediator = new Mediator();
            _GameInstance = new GameInstance(_Mediator);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);
            InitialiseMediator();
            _GameInstance.Init();

            base.LoadContent();
        }

        private void InitialiseMediator()
        {            
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(Content));
            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_UpdateService));
            _Mediator.RegisterService<IStateService, StateService>(new StateService(_UpdateService));
            _Mediator.RegisterCreator<ILoadingScreen>(() => new LoadingScreen(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, _VirtualWindowScale));
        }

        /// <summary>
        /// Gets the scale matrix from a virtual resolution 
        /// </summary>
        /// <returns></returns>
        private Matrix GetWindowScalar(Vector2 virtualResolution)
        {
            var scaleX = _GraphicsDeviceManager.GraphicsDevice.Viewport.Width / virtualResolution.X;
            var scaleY = _GraphicsDeviceManager.GraphicsDevice.Viewport.Height / virtualResolution.Y;
            var matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);
            return matrix;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepPink);

            _SpriteBatch.Begin(transformMatrix: GetWindowScalar(_VirtualWindowScale));
            _RenderService.Draw(gameTime, _SpriteBatch);
            _SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            _UpdateService.Update(gameTime);
            base.Update(gameTime);
        }

        #endregion

    }
}
