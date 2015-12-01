using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationEngine;

namespace ReferenceNotificationImplementation
{
    public class RecordSubject : AbstractSubject<RecordModel>
    {
        public override void RefreshState()
        {
            RecordModel lRecord = new RecordModel();

            //Fetch from the data source
            //lRecord.ID = DateTime.UtcNow.Ticks.ToString();
            //lRecord.ModifiedDate = DateTime.Now;
            lRecord.ID = DateTime.UtcNow.Minute.ToString();
            lRecord.ModifiedDate = DateTime.Today;

            this.SetState(lRecord);
        }
    }
}
