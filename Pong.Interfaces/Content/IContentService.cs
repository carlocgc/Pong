using System;

namespace Pong.Interfaces.Content
{
    /// <summary>
    /// Wrapper for monogame content
    /// </summary>
    public interface IContentService
    {
        /// <summary> Load the content of the given type </summary>
        /// <typeparam name="T"></typeparam>        
        /// <param name="assetName"></param>
        /// <returns></returns>
        T Load<T>(String assetName);

        T LoadLocalized<T>(String assetName);

        /// <summary>
        /// Unloads all loaded content
        /// </summary>
        void Unload();
    }
}
