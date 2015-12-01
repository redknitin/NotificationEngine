using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEngine
{
    public interface IObserver<T>
    {
        void Update(T aOld, T aNew); //Why get the Observer to call Subject.GetState?
        void Update();
    }
}
