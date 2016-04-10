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
        

        private state() { }

        public IEnumerable<serviceRecord> GetAllRecords()
        {
            return _plan;
        }

        public void updateRecord(serviceRecord oldRecord, serviceRecord newRecord)
        {
            lock (_plan)
            {
                var ColissionRecords = GetCollisionRecords(newRecord);

                if (ColissionRecords.Count() > 1 ||
                    ColissionRecords.Count() == 1 && !ColissionRecords.Contains(oldRecord))
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                _plan.Remove(oldRecord);
                _plan.Add(newRecord);
            }
        }

        public void deliteRecord(serviceRecord record)
        {
            _plan.Remove(record);
        }

        public void addRecord(serviceRecord record)
        {
            lock (_plan)
            {
                var ColissionRecords = GetCollisionRecords(record);

                if (ColissionRecords.Count() > 1 )
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                _plan.Add(record);
            }
        }

        private IEnumerable<serviceRecord> GetCollisionRecords (serviceRecord record)
        {
            return _plan.Where(r => r.serviceStart <= record.serviceStart.Add(record.serviceDuration)
                    && r.serviceStart.Add(r.serviceDuration) > record.serviceStart);
        }

        private serviceRecord getNextRecord()
        {
            DateTime nowdate = DateTime.Now;

            if (_plan.Count() == 0) return null;

            return _plan
                .Where(r => r.serviceStart > nowdate)
                .OrderBy(r => r.serviceStart)
                .First();
        }

        private serviceState getActualState()
        {
            DateTime nowDateTime = DateTime.Now;
            var recordsInProgress = _plan.Where(r => r.serviceStart <= nowDateTime 
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