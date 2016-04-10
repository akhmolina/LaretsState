using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaretsState
{
    public class serviceRecord
    {
        private static int lastid = 0;

        public  DateTime serviceStart;
        public  TimeSpan serviceDuration;
        public readonly DateTime creationTime;
        public readonly int id;
        
        public serviceRecord (DateTime ServiceStart, TimeSpan ServiceDuration)
        {
            serviceStart = ServiceStart;
            serviceDuration = ServiceDuration;
            creationTime = DateTime.Now;
            this.id = ++lastid;
        }
    }
}