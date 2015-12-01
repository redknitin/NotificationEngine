using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEngine
{
    public interface ISubject<T>
    {
        void Attach(IObserver<T> aObserver);
        T GetState();
        void SetState(T a);
    }
}
