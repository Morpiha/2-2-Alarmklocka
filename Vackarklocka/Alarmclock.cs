using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vackarklocka
{
    class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;
        public AlarmClock() : this(0, 0) { }
        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0) { }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmMinute = alarmMinute;
            AlarmHour = alarmHour;
        }
        public bool TickTock()
        {
            if (Minute < 59)
            {
                Minute++;
            } else
            {
                Minute = 0;
                if(Hour<23)
                {
                    Hour++;
                }else
                {
                    Hour = 0;
                }
                
            }
            return Hour == AlarmHour && Minute == AlarmMinute;
        }
        public override string ToString()
        {
            return string.Format("{0,2}:{1:00} ({2}:{3:00})", Hour, Minute, _alarmHour, _alarmMinute);
        }
       
        public int AlarmHour
        {

            get { return _alarmHour; }

            set
            {
                _alarmHour = value;
            }
        }
        public int AlarmMinute
        {
            get { return _alarmMinute; }

            set
            {
                 throw new Exception("Alarmminuten är inte i intervallet 0-59");
                _alarmMinute = value;
            }

        }
        public int Hour
        {
            get { return _hour; }

            set
            {
                _hour = value;
            }
        }
        public int Minute
        {
            get { return _minute; }

            set
            {
                _minute = value;
            }
        }
    }
}