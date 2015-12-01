using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationEngine
{
    public class AbstractSubject<T> : ISubject<T>
    {
        protected List<IObserver<T>> mObservers = new List<IObserver<T>>();

        public void Attach(IObserver<T> aObserver) {
            if (!mObservers.Contains(aObserver))
            {
                mObservers.Add(aObserver);
            }
        }

        private bool mCompareStateOnSet = true;
        public bool CompareStateOnSet {
            get { return mCompareStateOnSet; }
            set { mCompareStateOnSet = value; } 
        }

        T mInstance;
        public T GetState() { return mInstance; }
        public void SetState(T a) {
            if (!CompareStateOnSet || (mInstance == null && a != null) || (mInstance != null && !mInstance.Equals(a)))
            {
                var oldState = mInstance;
                mInstance = a;

                foreach (var iterObserver in mObservers)
                {
                    iterObserver.Update(oldState, mInstance);
                    iterObserver.Update();
                }
            }
        }
    }
}
