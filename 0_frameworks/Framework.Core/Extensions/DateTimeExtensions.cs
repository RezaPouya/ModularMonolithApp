using System;
using System.Globalization;

namespace Framework.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetDateFromTicks(this long numberOfTicks)
        {
            return new DateTime(numberOfTicks);
        }

        public static int GetAge(this DateTime? userBirthday)
        {
            if (userBirthday == null)
                return 0;

            return (int)Math.Round(DateTime.Now.Subtract(userBirthday.Value).TotalDays / 365.25);
        }

        public static int GetAge(this DateTime userBirthday)
        {
            return (int)Math.Round(DateTime.Now.Subtract(userBirthday).TotalDays / 365.25);
        }

        /// <summary>
        /// age
        /// </summary>
        /// <param name="age">as year</param>
        public static DateTime GetProximateBirthDate(this int age)
        {
            if (age == 0)
                return DateTime.Now;

            var totalDays = (int)Math.Round(age * 365.25, MidpointRounding.AwayFromZero);

            if (totalDays <= 365)
                return DateTime.Now.AddYears(-1);

            return DateTime.Now.AddDays(-totalDays);
        }

        /// <summary>
        /// age
        /// </summary>
        /// <param name="age">as year</param>
        public static DateTime GetProximateBirthDate(this int? age)
        {
            return age.Value.GetProximateBirthDate();
        }

        public static string GetDaysFromDateTime(this DateTime? applyTime, bool isPersian = true)
        {
            var time = applyTime == null ? DateTime.Now : applyTime.Value;
            var diffrence = (DateTime.Now - time).Days;

            if (isPersian)
            {
                if (diffrence <= 0)
                    return "امروز";

                if (diffrence == 1)
                    return "دیروز";

                if (diffrence == 2)
                    return "پریروز";

                return $"{diffrence} روز پیش";
            }

            if (diffrence <= 0)
                return "Today";

            if (diffrence == 1)
                return "Yesterday";

            return $"{diffrence} days ago";
        }

        /// <summary>
        /// گرفتن روزهای گذشته بر اساس تاریخ فعلی
        /// </summary>
        public static string GetDaysFromDateTime(this DateTime applyTime, bool isPersian = true)
        {
            var diffrence = (DateTime.Now - applyTime).Days;

            if (isPersian)
            {
                if (diffrence <= 0)
                    return "امروز";

                if (diffrence == 1)
                    return "دیروز";

                if (diffrence == 2)
                    return "پریروز";

                return $"{diffrence} روز پیش";
            }

            if (diffrence <= 0)
                return "Today";

            if (diffrence == 1)
                return "Yesterday";

            return $"{diffrence} days ago";
        }

        /// <summary>
        /// گرفتن روزهای آینده بر اساس تاریخ فعلی
        /// </summary>
        public static string GetDaysFromDateTimeForFuture(this DateTime applyTime, bool isPersian = true)
        {
            var diffrence = (DateTime.Now - applyTime).Days * -1;

            if (isPersian)
            {
                if (diffrence <= 0)
                    return "امروز";

                if (diffrence == 1)
                    return "فردا";

                return $"{diffrence} روز دیگر";
            }

            if (diffrence <= 0)
                return "Today";

            if (diffrence == 1)
                return "Tommorow";

            return $"{diffrence} remaining";
        }

        /// <summary>
        /// Written By R.P
        /// </summary>
        public static string GetDurationFromPersianYearMonthFa(int year, int month, int? finishYear, int? finisthMonth)
        {
            var pc = new PersianCalendar();
            var startDate = new DateTime(year, month, 1, pc);

            DateTime endDate = DateTime.Now.Date;

            if (finishYear != null && finishYear.Value != 0 && finishYear.Value < 3000)
            {
                var fMonth = finisthMonth == null || finisthMonth.Value > 0 || finisthMonth.Value < 12 ? finisthMonth.Value : 1;
                endDate = new DateTime(finishYear.Value, fMonth, 1, pc);
            }

            if (startDate >= endDate)
            {
                return "نا معتبر";
            }

            var totalAveratgeDiffrentialMonth = endDate.Subtract(startDate).Days / (365.2425 / 12);

            var diffYear = Convert.ToInt32(Math.Floor(totalAveratgeDiffrentialMonth / 12));

            var diffMonth = Convert.ToInt32(Math.Round(totalAveratgeDiffrentialMonth % 12, MidpointRounding.AwayFromZero));

            diffMonth = diffMonth == 12 ? 11 : diffMonth;

            var yString = diffYear <= 0 ? "" : $"{diffYear} سال";
            var mString = diffMonth <= 0 ? "" : $"{diffMonth} ماه";
            var and = diffMonth > 0 && diffYear > 0 ? " و " : "";

            var dString = $"{ yString} {and} {mString}";

            return dString.Trim();
        }

        /// <summary>
        /// Written By R.P
        /// </summary>
        public static string GetDurationFromPersianYearMonthEn(int year, int month, int? finishYear, int? finisthMonth)
        {
            var pc = new PersianCalendar();
            var startDate = new DateTime(year, month, 1, pc);

            DateTime endDate = DateTime.Now.Date;

            if (finishYear != null && finishYear.Value != 0 && finishYear.Value < 3000)
            {
                var fMonth = finisthMonth == null || finisthMonth.Value > 0 || finisthMonth.Value < 12 ? finisthMonth.Value : 1;
                endDate = new DateTime(finishYear.Value, fMonth, 1, pc);
            }

            if (startDate >= endDate)
            {
                return "نا معتبر";
            }

            var totalAveratgeDiffrentialMonth = endDate.Subtract(startDate).Days / (365.2425 / 12);

            var diffYear = Convert.ToInt32(Math.Floor(totalAveratgeDiffrentialMonth / 12));
            var diffMonth = Convert.ToInt32(Math.Round(totalAveratgeDiffrentialMonth % 12, MidpointRounding.AwayFromZero));
            diffMonth = diffMonth == 12 ? 11 : diffMonth;

            var yString = diffYear <= 0 ? "" : $"{diffYear} " + (diffYear == 1 ? "year" : "years");
            var mString = diffMonth <= 0 ? "" : $"{diffMonth} " + (diffMonth == 1 ? "month" : "months");
            var and = diffMonth > 0 && diffYear > 0 ? " and " : "";

            var dString = $"{ yString} {and} {mString}";

            return dString.Trim();
        }

        public static string ToStringShamsiDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int intYear = pc.GetYear(dt);
            int intMonth = pc.GetMonth(dt);
            int intDayOfMonth = pc.GetDayOfMonth(dt);
            string strMonthName = intMonth.GetMonthNameFa();
            string strDayName = "";

            return string.Format("{0} {1} {2} {3}", strDayName, intDayOfMonth, strMonthName, intYear);
        }

        public static string GetMonthNameFa(this int intMonth)
        {
            switch (intMonth)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهشت";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }

        public static string GetMonthNameEn(this int intMonth)
        {
            switch (intMonth)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "";
            }
        }
    }
}