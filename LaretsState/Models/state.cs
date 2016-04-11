using System;
using System.Collections.Generic;
using System.Linq;

namespace LaretsState
{

    public static class state
    {

        public static actualState actualState
        { get { return new actualState(getActualState(), getNextRecord()); } }

        private static List<serviceRecord> _plan = new List<serviceRecord>();

        static state() { }

        public static List<serviceRecord> getRecords()
        {
            return _plan;
        }

        public static void updateRecord(serviceRecord record)
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

        public static void deleteRecord(serviceRecord record)
        {
            _plan.Remove(record);
        }

        public static void addRecord(serviceRecord record)
        {
            lock (_plan)
            {
                var ColissionRecords = GetCollisionRecords(record);

                if (ColissionRecords.Count() > 1 )
                { throw new Exception("На предложенное время уже запланировано обслуживание"); }

                _plan.Add(record);
            }
        }

        private static List<serviceRecord> GetCollisionRecords (serviceRecord record)
        {
            return _plan.Where(r => r.serviceStart <= record.serviceStart.Add(record.serviceDuration)
                    && r.serviceStart.Add(r.serviceDuration) > record.serviceStart).ToList();
        }

        private static serviceRecord getNextRecord()
        {
            DateTime nowdate = DateTime.Now;

            if (_plan.Count() == 0) return null;

            return _plan
                .Where(r => r.serviceStart > nowdate)
                .OrderBy(r => r.serviceStart)
                .First();
        }

        private static serviceState getActualState()
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