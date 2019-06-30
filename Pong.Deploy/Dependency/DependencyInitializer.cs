using System;
using System.Collections.Generic;
using System.Text;
using Pong.Interfaces.Mediator;
using Pong.Interfaces.Physics.Service;
using Pong.Mediation;
using Pong.Physics.Service;

namespace Pong.Deploy.Dependency
{
    public class DependencyInitializer
    {
        private IMediator _Mediator;

        public void Initialise()
        {
            _Mediator = new Mediator();

            PhysicsService physics = new PhysicsService();
            _Mediator.RegisterService<IPhysicsService, PhysicsService>(physics);

            // TODO Register factory methods and services
            // TODO Register game instance etc...
        }
    }
}
