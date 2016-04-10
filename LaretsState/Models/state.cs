using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaretsState
{

    public class state
    {
        public serviceRecord nextRecord
        { get { return getNextRecord(); } }

        public serviceState actualState
        { get { return getActualState(); } }

        private static List<serviceRecord> _plan = new List<serviceRecord>();


        public state() { }

        public List<serviceRecord> getRecords()
        {
            return _plan;
        }

        public void updateRecord(serviceRecord record)
        {
            serviceRecord newRecord = record;
            lock (_plan)
            {
                serviceRecord oldRecord = _plan.Where(r=> r.id== record.id).FirstOrDefault();
                if (oldRecord == null)
                { throw new ArgumentException("В плане отсутствует запись с id " + record.id, "recordid"); }

                var ColissionRecords = GetCollisionRecords(newRecord);

                if (ColissionRecords.Count() > 1 ||
                    ColissionRecords.Count() == 1 && !ColissionRecords.Contains(oldRecord))
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                oldRecord = newRecord;
                //_plan.Remove(oldRecord);
                //_plan.Add(newRecord);
            }
        }

        public void deleteRecord(serviceRecord record)
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

        private List<serviceRecord> GetCollisionRecords (serviceRecord record)
        {
            return _plan.Where(r => r.serviceStart <= record.serviceStart.Add(record.serviceDuration)
                    && r.serviceStart.Add(r.serviceDuration) > record.serviceStart).ToList();
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

        private  serviceState getActualState()
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