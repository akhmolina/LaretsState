using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LaretsState
{
    [DataContract]
    public class serviceRecord
    {
        private static int lastid = 0;

        [DataMember]
        public DateTime serviceStart { get; set; }
        [DataMember]
        public  TimeSpan serviceDuration { get; set; }
        [DataMember]
        public DateTime creationTime { get; set; }

        [DataMember]
        public int id { get; set; }


        public serviceRecord (DateTime serviceStart, TimeSpan serviceDuration)
            :this()
        {
            this.serviceStart = serviceStart;
            this.serviceDuration = serviceDuration;
        }

        public serviceRecord()
        {
            this.creationTime = DateTime.Now;
            this.id = ++lastid;
        }

    }
}