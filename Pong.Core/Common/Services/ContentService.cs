using System;
using Microsoft.Xna.Framework.Content;
using Pong.Interfaces.Content;

namespace Pong.Core.Common.Services
{
    public class ContentService : IContentService
    {
        private readonly ContentManager _ContentManager;

        public ContentService(ContentManager contentManager)
        {
            _ContentManager = contentManager;
        }

        #region Implementation of IContentService

        /// <summary> Load the content of the given type </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T Load<T>(String path)
        {
            return _ContentManager.Load<T>(path);
        }

        public T LoadLocalized<T>(String assetName)
        {
            return _ContentManager.LoadLocalized<T>(assetName);
        }

        /// <summary>
        /// Unloads all loaded content
        /// </summary>
        public void Unload()
        {
            _ContentManager.Unload();
        }

        #endregion
    }
}
