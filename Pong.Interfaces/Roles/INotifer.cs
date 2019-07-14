using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Interfaces.Roles
{
    public interface INotifer<T>
    {
        void AddListener(T listener);

        void RemoveListener(T listener);
    }
}
