/*
 * Added Nuget packages:
 * xunit
 * xunit.console.runner
 * xunit.console.runner.visualstudio
 */
using System;
using Pong.Interfaces.Physics.Service;
using Xunit;
using Pong.Mediation.Tests.Mocks;

namespace Pong.Mediation.Tests
{
    public class MediatorTests
    {
        [Fact]
        public void RegisterService_ShouldWork()
        {
            // Arrange
            Mediator mediator = new Mediator();

            // Act
            mediator.RegisterService<IPhysicsService, MockService>(new MockService());
            IDisposable service = mediator.GetInstance<IPhysicsService>();

            // Assert
            Assert.NotNull(service);
            Assert.IsType<MockService>(service);
        }

        [Fact]
        public void RegisterService_ShouldOverride()
        {
            // Arrange
            Mediator mediator = new Mediator();

            MockService mockService1 = new MockService();
            MockService mockService2 = new MockService();

            // Act
            mediator.RegisterService<IPhysicsService, MockService>(mockService1);
            mediator.RegisterService<IPhysicsService, MockService>(mockService2);
            IDisposable service = mediator.GetInstance<IPhysicsService>();

            // Assert
            Assert.NotNull(service);
            Assert.IsType<MockService>(service);
            Assert.Equal(mockService2, service);
        }

        [Fact]
        public void RegisterInstance_ShouldWork()
        {
            // Arrange
            Mediator mediator = new Mediator();

            // Act
            Func<MockInstance> func = () => new MockInstance(0);
            mediator.RegisterCreator<MockInstance>(func);
            IDisposable mi = mediator.Create<MockInstance>();

            // Assert
            Assert.NotNull(mi);
            Assert.IsType<MockInstance>(mi);
        }

        [Fact]
        public void RegisterInstance_ShouldOverride()
        {
            // Arrange
            Mediator mediator = new Mediator();

            // Act
            Func<MockInstance> func1 = () => new MockInstance(0);
            Func<MockInstance> func2 = () => new MockInstance(1);
            mediator.RegisterCreator<MockInstance>(func1);
            mediator.RegisterCreator<MockInstance>(func2);
            MockInstance mi = mediator.Create<MockInstance>();

            // Assert
            Assert.NotNull(mi);
            Assert.IsType<MockInstance>(mi);
            Assert.Equal(1, mi.ID);
        }
    }
}
