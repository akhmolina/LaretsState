using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaretsState
{

    public class state
    {
        private static state _Instance = null;
        internal static state Instance
        {  get
            {
                if (_Instance == null) { _Instance = new state(); }
                return _Instance;
            }
        }

        public serviceRecord nextRecord
        { get { return getNextRecord(); } }

        public serviceState actualState
        { get { return getActualState(); } }

        private List<serviceRecord> _plan = new List<serviceRecord>();
        internal List<serviceRecord> plan
        {
            get { return _plan; }
            private set { if (_plan != value) _plan = value; }
        }

        private state() { }

        internal void updateRecord(serviceRecord oldRecord, serviceRecord newRecord)
        {
            lock (plan)
            {
                var ColissionRecords = GetCollisionRecords(newRecord);

                if (ColissionRecords.Count() > 1 ||
                    ColissionRecords.Count() == 1 && !ColissionRecords.Contains(oldRecord))
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                plan.Remove(oldRecord);
                plan.Add(newRecord);
            }
        }

        internal void deliteRecord(serviceRecord record)
        {
            plan.Remove(record);
        }

        internal void addRecord(serviceRecord record)
        {
            lock (plan)
            {
                var ColissionRecords = GetCollisionRecords(record);

                if (ColissionRecords.Count() > 1 )
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                plan.Add(record);
            }
        }

        private IEnumerable<serviceRecord> GetCollisionRecords (serviceRecord record)
        {
            return plan.Where(r => r.serviceStart <= record.serviceStart.Add(record.serviceDuration)
                    && r.serviceStart.Add(r.serviceDuration) > record.serviceStart);
        }

        private serviceRecord getNextRecord()
        {
            DateTime nowdate = DateTime.Now;

            if (plan.Count() == 0) return null;

            return plan
                .Where(r => r.serviceStart > nowdate)
                .OrderBy(r => r.serviceStart)
                .First();
        }

        private  serviceState getActualState()
        {
            DateTime nowDateTime = DateTime.Now;
            var recordsInProgress = plan.Where(r => r.serviceStart <= nowDateTime 
                && r.serviceStart.Add(r.serviceDuration) > nowDateTime).Count();

            if (recordsInProgress >0)
            { return serviceState.OnService; }
            else
            { return serviceState.Normal; }
        }

    }

    public enum serviceState
    { Normal, OnService}
}