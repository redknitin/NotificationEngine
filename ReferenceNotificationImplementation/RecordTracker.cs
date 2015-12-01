using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceNotificationImplementation
{
    public class RecordTracker
    {
        private System.Threading.Thread threadTracker = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(TrackMethod));
        RecordSubject rsub = new RecordSubject();
        
        public int timeoutMilli = 3000;

        public void BeginTracking()
        {
            threadTracker.Start(this);
        }

        private static void TrackMethod(object obj)
        {
            RecordTracker myObj = (RecordTracker)obj;
            while (true)
            {
                myObj.rsub.RefreshState();
                System.Threading.Thread.Sleep(myObj.timeoutMilli);
            }
        }
    }
}
