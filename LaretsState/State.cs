using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaretsState
{

    public class state
    {
        //private static object Lock;
        private DateTime _nextService;
        public DateTime nextService
        {
            get { return _nextService; }
            private set { if (_nextService != value) _nextService = value; }
        }

        private DateTime _nextServiceDuration;
        public DateTime nextServiceDuration
        {
            get { return _nextServiceDuration; }
            private set { if (_nextServiceDuration != value) _nextServiceDuration = value; }
        }

 
        public serviseState actualState
        {
            get {
                if (DateTime.Now >= nextService && DateTime.Now <= nextServiceDuration)
                { return serviseState.OnService; }
                else
                { return serviseState.Normal; }
            }
        }

        private DateTime _updated;
        public DateTime updated
        {
            get { return _updated; }
            private set { if (_updated != value) _updated = value; }
        }

        private static state _state = null;
        public static state Instance
        {
            get
            {
                if (_state == null) _state = new state();
                return _state;
            }
        }

        private state() { }

        internal void update(DateTime nextService, DateTime nextServiceDuration)
        {

        }
    }

    public enum serviseState
    { Normal, OnService}
}