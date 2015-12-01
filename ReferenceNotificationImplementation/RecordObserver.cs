using NotificationEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceNotificationImplementation
{
    public class RecordObserver : AbstractBackgroundThreadedObserver<RecordModel> // NotificationEngine.IObserver<RecordModel>
    {
        public RecordObserver():base(new RecordSubject()) {}

        public override void Update(RecordModel aOld, RecordModel aNew)
        {
            Console.WriteLine("Was: " + (aOld == null ? "" : aOld.ID) + " " + (aOld==null?"":aOld.ModifiedDate.ToShortDateString()) + "  -->  Is: " + aNew.ID + " " + aNew.ModifiedDate.ToShortDateString());
        }

        public override void Update()
        {
            Console.WriteLine("Detected change");
        }
    }
}
