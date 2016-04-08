using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaretsState
{
    public class serviseRecord
    {
        public readonly DateTime serviceStart;
        public readonly TimeSpan serviceDuration;
        public readonly DateTime created;
        
        public serviseRecord (DateTime ServiceStart, TimeSpan ServiceDuration)
        {
            serviceStart = ServiceStart;
            serviceDuration = ServiceDuration;
            created = DateTime.Now;
        }
    }
}