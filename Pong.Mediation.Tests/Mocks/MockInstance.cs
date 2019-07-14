using System;

namespace Pong.Mediation.Tests.Mocks
{
    public class MockInstance : IDisposable
    {
        public Int32 ID { get; set; }

        public MockInstance(Int32 id)
        {
            ID = id;
        }

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {

        }

        #endregion
    }
}
