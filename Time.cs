namespace WorkshopFinish.Backend
{
    public class Time
    {
        // Fields
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        //Properties
        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }
        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }
        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }

        // Constructors
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour)
        {
            Hour = hour;

        }
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;

        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;

        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        // Methods

        // The ToString should return the time in the format : HH:MM:ss.mmm tt
        override public string ToString()
        {
            if (Hour < 0 || Hour > 23)
            {
                throw new ArgumentException("The time is invalid.");
            }
            if (Minute < 0 || Minute > 59)
            {
                throw new ArgumentException("The time is invalid.");
            }
            if (Second < 0 || Second > 59)
            {
                throw new ArgumentException("The time is invalid.");
            }
            if (Millisecond < 0 || Millisecond > 999)
            {
                throw new ArgumentException("The time is invalid.");
            }

            int hour12 = Hour;
            string period;

            period = "PM";
            if (hour12 >= 12)
            {
                hour12 -= 12;
            }

            else
            {
                period = "AM";
            }
            if (hour12 == 0)
            {
                hour12 = 12;
            }

            return $"{hour12:00}:{_minute:00}:{_second:00}:{_millisecond:000}:{period}";
        }


        public int ToMilliseconds()
        {
            if (Hour < 0 || Hour > 23)
            {
                return 0;
            }
            if (Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (Millisecond < 0 || Millisecond > 999)
            {
                return 0;
            }
            return (_hour * 3600000) +
                   (_minute * 60000) +
                   (_second * 1000) +
                   _millisecond;
        }

        public int ToSeconds()
        {
            if (Hour < 0 || Hour > 23)
            {
                return 0;
            }
            if (Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (Millisecond < 0 || Millisecond > 999)
            {
                return 0;
            }
            return Hour * 3600 + Minute * 60 + Second + Millisecond / 1000;

        }
        public int ToMinutes()
        {
            if (Hour < 0 || Hour > 23)
            {
                return 0;
            }
            if (Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (Millisecond < 0 || Millisecond > 999)
            {
                return 0;
            }
            return Hour * 60 + Minute + Second / 60 + Millisecond / 60000;
        }

        public bool IsOtherDay(Time other)
        {
            int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
            if (totalMilliseconds >= 86400000)
            {
                return true;
            }
            return false;
        }


        public Time Add(Time other)
        {
            int ms = this.Millisecond + other.Millisecond;
            int carrySec = ms / 1000;
            ms %= 1000;

            int sec = this.Second + other.Second + carrySec;
            int carryMin = sec / 60;
            sec %= 60;

            int min = this.Minute + other.Minute + carryMin;
            int carryHour = min / 60;
            min %= 60;

            int hour = this.Hour + other.Hour + carryHour;
            hour %= 24;

            return new Time(hour, min, sec, ms);
        }

        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException(nameof(hour), $"The hour:{hour}, is not valid");
            }
            return hour;
        }
        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException(nameof(minute), $"The minute:{minute}, is not valid");
            }
            return minute;
        }
        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentException(nameof(second), $"The second:{second}, is not valid");
            }
            return second;



        }
        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentException(nameof(millisecond), $"The millisecond:{millisecond}, is not valid");
            }
            return millisecond;

        }

    }

}
