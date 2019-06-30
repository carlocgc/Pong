using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Physics.Service;
using Pong.Mediation;
using Pong.Physics.Service;

namespace Pong.Deploy
{
    public class DeployGame : Game
    {
        protected readonly IMediator _Mediator;

        protected DeployGame()
        {
            _Mediator = new Mediator();
        }

        #region Overrides of Game

        protected override void Initialize()
        {
            _Mediator.RegisterService<IPhysicsService, PhysicsService>(new PhysicsService(_Mediator));

            base.Initialize();
        }

        #endregion
    }
}
