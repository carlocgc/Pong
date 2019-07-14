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
            Vector2 screenSize = new Vector2(_GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds.Width, _GraphicsDeviceManager.GraphicsDevice.Viewport.Height);
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(Content));
            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_UpdateService));
            _Mediator.RegisterService<IStateService, StateService>(new StateService(_UpdateService));
            _Mediator.RegisterCreator<ITable>(() => new NormalTable(_ContentService, _RenderService, _UpdateService));
            _Mediator.RegisterCreator<IBall>(() => new NormalBall(_ContentService, _RenderService, _UpdateService, screenSize));
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
