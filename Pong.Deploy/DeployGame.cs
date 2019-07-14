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
using Pong.Mediation;
using Pong.Physics.Service;
using Pong.Table.Tables;
using ContentService = Pong.Content.ContentService;

namespace Pong.Deploy
{
    public class DeployGame : Game
    {
        protected readonly GraphicsDeviceManager _GraphicsDeviceManager;

        private Mediator _Mediator;
        private GameInstance _GameInstance;
        private SpriteBatch _SpriteBatch;
        private IUpdateService _UpdateService;
        private IPhysicsService _PhysicsService;
        private IContentService _ContentService;
        private IRenderService _RenderService;
        
        protected DeployGame()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            RegisterUpdateables();
            RegisterRenderables();

            _GameInstance.Init();

            base.LoadContent();
        }

        private void InitialiseMediator()
        {
            Vector2 screenSize = new Vector2(_GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds.Width, _GraphicsDeviceManager.GraphicsDevice.Viewport.Height);
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_Mediator));
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(Content));
            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            _Mediator.RegisterService<ITable, NormalTable>(new NormalTable(_ContentService));
            _Mediator.RegisterService<IBall, NormalBall>(new NormalBall(_ContentService, screenSize));
        }

        private void RegisterUpdateables()
        {
            _UpdateService.Register(_PhysicsService);
            _UpdateService.Register(_Mediator.GetInstance<IBall>());
            _UpdateService.Register(_Mediator.GetInstance<ITable>());
        }

        private void RegisterRenderables()
        {
            _RenderService.Register(_Mediator.GetInstance<IBall>());
            _RenderService.Register(_Mediator.GetInstance<ITable>());
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepPink);

            _SpriteBatch.Begin();
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
