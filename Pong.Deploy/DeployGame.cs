using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Ball.Balls;
using Pong.Content;
using Pong.Core.Services;
using Pong.Graphics;
using Pong.Interfaces.Ball;
using Pong.Interfaces.Content;
using Pong.Interfaces.Core;
using Pong.Interfaces.Graphics;
using Pong.Interfaces.Physics.Service;
using Pong.Mediation;
using Pong.Physics.Service;

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
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            _RenderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            IBall ball = _Mediator.RegisterService<IBall, NormalBall>(new NormalBall(_ContentService));

            _UpdateService.Register(_PhysicsService);
            _UpdateService.Register(ball);

            _RenderService.Register(ball);

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
