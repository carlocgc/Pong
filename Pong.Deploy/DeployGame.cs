using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Ball.Balls;
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
        private readonly Mediator _Mediator;

        private SpriteBatch _SpriteBatch;
        private IUpdateService _UpdateService;
        private IPhysicsService _PhysicsService;
        private IContentService _ContentService;
        private IRenderService _RenderService;

        protected DeployGame()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _Mediator = new Mediator();
        }

        #region Overrides of Game

        protected override void Initialize()
        {
            // Initialise services
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_Mediator));
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(Content));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Vector2 screenSize = new Vector2(_GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds.Width, _GraphicsDeviceManager.GraphicsDevice.Viewport.Height);

            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            ITable table = _Mediator.RegisterService<ITable, NormalTable>(new NormalTable(_ContentService));
            IBall ball = _Mediator.RegisterService<IBall, NormalBall>(new NormalBall(_ContentService, screenSize));

            _UpdateService.Register(_PhysicsService);
            _UpdateService.Register(table);
            _UpdateService.Register(ball);

            _RenderService.Register(table);
            _RenderService.Register(ball);

            ball.Start();

            base.LoadContent();
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
