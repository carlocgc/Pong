﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        protected readonly Mediator _Mediator;
        protected readonly GraphicsDeviceManager _GraphicsDeviceManager;
        protected readonly ContentManager _ContentManager;

        protected SpriteBatch _SpriteBatch;
        protected IUpdateService _UpdateService;
        protected IPhysicsService _PhysicsService;
        protected IContentService _ContentService;

        protected DeployGame()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            _ContentManager = new ContentManager(Services)
            {
                RootDirectory = "Content"
            };

            _Mediator = new Mediator();

        }

        #region Overrides of Game

        protected override void Initialize()
        {
            // Initialise services
            _UpdateService = _Mediator.RegisterService<IUpdateService, UpdateService>(new UpdateService());
            _PhysicsService = _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_Mediator));
            _ContentService = _Mediator.RegisterService<IContentService, ContentService>(new ContentService(_ContentManager));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            IRenderService renderService = _Mediator.RegisterService<IRenderService, RenderService>(new RenderService(_SpriteBatch));
            IBall ball = _Mediator.RegisterService<IBall, NormalBall>(new NormalBall(_ContentService));

            _UpdateService.Register(_PhysicsService).
                Register(renderService).
                Register(ball);

            renderService.Register(ball);

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
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
