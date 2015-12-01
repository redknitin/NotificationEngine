using ReferenceNotificationImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordObserver rt = new RecordObserver();
            rt.StartTracking();
        }
    }
}
