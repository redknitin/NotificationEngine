using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceNotificationImplementation
{
    public class RecordObserver : NotificationEngine.IObserver<RecordModel>
    {
        private System.Threading.Thread threadTracker = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(TrackMethod));
        RecordSubject rsub = new RecordSubject();
        
        public int timeoutMilli = 3000;

        public void StartTracking()
        {
            threadTracker.Start(this);
        }

        private static void TrackMethod(object obj)
        {
            RecordObserver myObj = (RecordObserver)obj;
            myObj.rsub.Attach(myObj);
            while (true)
            {
                myObj.rsub.RefreshState();
                System.Threading.Thread.Sleep(myObj.timeoutMilli);
            }
        }

        public void StopTracking()
        {
            threadTracker.Abort();
        }

        public void Update(RecordModel aOld, RecordModel aNew)
        {
            Console.WriteLine("Was: " + (aOld == null ? "" : aOld.ID) + " " + (aOld==null?"":aOld.ModifiedDate.ToString()) + "  -->  Is: " + aNew.ID + " " + aNew.ModifiedDate.ToString());
        }

        public void Update()
        {
            Console.WriteLine("Detected change");
        }
    }
}
