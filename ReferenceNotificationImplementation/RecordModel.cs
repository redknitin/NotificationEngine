using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceNotificationImplementation
{
    public class RecordModel
    {
        public string ID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RecordModel)
            {
                RecordModel mod = (RecordModel)obj;
                if (ID.Equals(mod.ID) && ModifiedDate.Equals(mod.ModifiedDate))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
