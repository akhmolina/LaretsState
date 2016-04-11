using System.Runtime.Serialization;

namespace LaretsState
{
    [DataContract]
    public class actualState
    {
        [DataMember]
        public serviceState state;
        [DataMember]
        public serviceRecord nextRecord;

        public actualState(serviceState serviceState, serviceRecord serviceRecord)
        {
            this.state = serviceState;
            this.nextRecord = serviceRecord;
        }
    }
}