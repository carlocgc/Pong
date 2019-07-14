using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.UI
{
    public interface ILoadingScreenListener
    {
        void OnLoadingScreenComplete(ILoadingScreen loadingScreen);
    }
}
