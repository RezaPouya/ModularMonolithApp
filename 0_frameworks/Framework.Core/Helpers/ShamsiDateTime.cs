using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework.Core.Helpers
{
    public class ShamsiDateTime
    {
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private static string[] _dayNames = new string[] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        private static string[] _monthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };

        /// <summary>
        /// Get month name by month
        /// </summary>
        /// <param name="month"></param>
        static public string GetMonthName(int month)
        {
            if (month > 0 && month < 13)
                return _monthNames[month - 1];
            else
                return string.Empty;
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName => _monthNames[Month - 1];
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public int DayOfWeek { get; set; }
        public string DayOfWeekName { get; set; }

        public int TwoDigitYear => Convert.ToInt32(Year.ToString().Substring(2));
        public int FourDigitYear => Convert.ToInt32(Year.ToString().Substring(4));

        public ShamsiDateTime()
        {
            Day = 0;
            Month = 0;
            Year = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

        public override string ToString()
        {
            return System.String.Format("{0}/{1}/{2}", Year, Month.ToString().PadLeft(2, '0'), Day.ToString().PadLeft(2, '0'));
        }

        public string ToDateDotTime()
        {
            return System.String.Format("{0}/{1}/{2} {3}:{4}:{5}", Year, Month.ToString().PadLeft(2, '0'), Day.ToString().PadLeft(2, '0'), Hour.ToString().PadLeft(2, '0'), Minute.ToString().PadLeft(2, '0'),
                Second.ToString().PadLeft(2, '0'));
        }

        public string ToDateDotTimeWithoutSeconds()
        {
            return System.String.Format("{0}/{1}/{2} {3}:{4}", Year, Month.ToString().PadLeft(2, '0'), Day.ToString().PadLeft(2, '0'), Hour.ToString().PadLeft(2, '0'), Minute.ToString().PadLeft(2, '0'));
        }

        public string ToLongDate()
        {
            return System.String.Format("{0} , {1} {2} {3}", _dayNames[DayOfWeek], Day, _monthNames[Month - 1], Year);
        }

        public string ToLongDateWithTime()
        {
            return System.String.Format("{0} , {1} {2} {3} {4}:{5}", _dayNames[DayOfWeek], Day, _monthNames[Month - 1], Year, Hour, Minute);
        }

        public string ToLongDateTime()
        {
            return System.String.Format("{0} - {1}:{2}:{3}", ToLongDate(), this.Hour, this.Minute, this.Second);
        }

        public static string GetNameSeasonFromDate(DateTime georgianDT)
        {
            var shamsidate = ToShamsi(georgianDT);

            if (shamsidate.Month >= 1 && shamsidate.Month < 4)
            {
                return "بهار";
            }
            if (shamsidate.Month >= 4 && shamsidate.Month < 7)
            {
                return "تابستان";
            }
            if (shamsidate.Month >= 7 && shamsidate.Month < 10)
            {
                return "پاییز";
            }

            return "زمستان";
        }

        public static int GetSeasonFromDate(DateTime georgianDT)
        {
            var shamsidate = ToShamsi(georgianDT);

            if (shamsidate.Month >= 1 && shamsidate.Month < 4)
            {
                return 1;
            }
            if (shamsidate.Month >= 4 && shamsidate.Month < 7)
            {
                return 2;
            }
            if (shamsidate.Month >= 7 && shamsidate.Month < 10)
            {
                return 3;
            }

            return 4;
        }

        public static ShamsiDateTime ToShamsi(DateTime georgianDT)
        {
            var pc = new PersianCalendar();

            var sd = new ShamsiDateTime();
            sd.Day = pc.GetDayOfMonth(georgianDT);
            sd.Month = pc.GetMonth(georgianDT);
            sd.Year = pc.GetYear(georgianDT);
            sd.Minute = pc.GetMinute(georgianDT);
            sd.DayOfWeek = (int)pc.GetDayOfWeek(georgianDT);
            sd.Second = pc.GetSecond(georgianDT);
            sd.Hour = pc.GetHour(georgianDT);
            sd.DayOfWeekName = _dayNames[sd.DayOfWeek];

            return sd;
        }

        public static DateTime GetFromPersian(string persiandate, char splitter)
        {
            var ps = new PersianCalendar();
            string[] persianDatesplited = persiandate.Split(splitter);
            DateTime persianDate = ps.ToDateTime
                (Convert.ToInt32(persianDatesplited[0]), Convert.ToInt32(persianDatesplited[1]), (Convert.ToInt32(ZeroRemoverForGeorgianCalendar(persianDatesplited[2]))), 12, 0, 0, 0);
            return persianDate;
        }

        private static string ZeroRemoverForGeorgianCalendar(string date)
        {
            if (date[0] == '0')
                return date[1].ToString();

            return date;
        }

        public static ShamsiDateTime Now
        {
            get
            {
                return ToShamsi(DateTime.Now);
            }
        }

        public DateTime ToDateTime()
        {
            var pc = new System.Globalization.PersianCalendar();
            return pc.ToDateTime(Year, Month, Day, Hour, Minute, Second, 0);
        }

        public string ToFileDateTime()
        {
            return System.String.Format("{0}-{1}-{2}", Year, Month.ToString().PadLeft(2, '0'), Day.ToString().PadLeft(2, '0'));
        }

        public string ToRecordingDateTime()
        {
            return System.String.Format("{0}{1}{2}{3}{4}{5}", Year, Month.ToString().PadLeft(2, '0'), Day.ToString().PadLeft(2, '0'),
                Hour.ToString().PadLeft(2, '0'),
                Minute.ToString().PadLeft(2, '0'), Second.ToString().PadLeft(2, '0')
                );
        }
    }
}