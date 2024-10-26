﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Pong.Interfaces.Core;

namespace Pong.Core.Common.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly List<IUpdateable> _Updateables = new List<IUpdateable>();

        #region Implementation of IUpdateService

        /// <summary> Add an object to update </summary>
        /// <param name="updateable"></param>
        public void Register(IUpdateable updateable)
        {
            if (!_Updateables.Contains(updateable)) _Updateables.Add(updateable);
        }

        /// <summary> Remove an object </summary>
        /// <param name="updateable"></param>
        public void Deregister(IUpdateable updateable)
        {
            if (!_Updateables.Contains(updateable)) _Updateables.Remove(updateable);
        }

        #endregion

        #region Implementation of IUpdateable

        public void Update(GameTime gameTime)
        {
            for (var index = _Updateables.Count - 1; index >= 0; index--)
            {
                IUpdateable updateable = _Updateables[index];
                updateable.Update(gameTime);
            }
        }

        public Boolean Enabled { get; }
        public Int32 UpdateOrder { get; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _Updateables.Clear();
        }

        #endregion
    }
}
