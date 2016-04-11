using System;
using System.Runtime.Serialization;

namespace LaretsState
{
    [DataContract]
    public class serviceRecord
    {
        private static int lastid = 0;

        [DataMember]
        public  DateTime serviceStart;
        [DataMember]
        public  TimeSpan serviceDuration;
        [DataMember]
        public readonly DateTime creationTime;
        [DataMember]
        public readonly int id;
        
        public serviceRecord (DateTime serviceStart, TimeSpan serviceDuration)
        {
            this.serviceStart = serviceStart;
            this.serviceDuration = serviceDuration;
            this.creationTime = DateTime.Now;
            this.id = ++lastid;
        }

        public serviceRecord() {}
    }
}