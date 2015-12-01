using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEngine
{
    public class AbstractBackgroundThreadedObserver<T> : IObserver<T>
    {
        private System.Threading.Thread threadTracker = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(TrackMethod));
        ISubject<T> mSubject;

        public int timeoutMilli = 3000;

        public AbstractBackgroundThreadedObserver(ISubject<T> subjectInstance)
        {
            mSubject = subjectInstance;
        }

        public void StartTracking()
        {
            threadTracker.Start(this);
        }

        private static void TrackMethod(object obj)
        {
            AbstractBackgroundThreadedObserver<T> myObj = (AbstractBackgroundThreadedObserver<T>)obj;
            myObj.mSubject.Attach(myObj);
            while (true)
            {
                myObj.mSubject.RefreshState();
                System.Threading.Thread.Sleep(myObj.timeoutMilli);
            }
        }

        public void StopTracking()
        {
            threadTracker.Abort();
        }

        public virtual void Update(T aOld, T aNew)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}
