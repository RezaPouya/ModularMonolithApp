using System;

namespace Framework.Core.Helpers
{
    public static class NumToString
    {
        private static string[] yakan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
        private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };

        private static string getnum3(int num3)
        {
            string s = "";
            int d3, d12;
            d12 = num3 % 100;
            d3 = num3 / 100;
            if (d3 != 0)
                s = sadgan[d3] + " و ";
            if ((d12 >= 10) && (d12 <= 19))
            {
                s = s + dahyek[d12 - 10];
            }
            else
            {
                int d2 = d12 / 10;
                if (d2 != 0)
                    s = s + dahgan[d2] + " و ";
                int d1 = d12 % 10;
                if (d1 != 0)
                    s = s + yakan[d1] + " و ";
                s = s.Substring(0, s.Length - 3);
            };
            return s;
        }

        public static string num2str(this string snum)
        {
            string stotal = "";
            if (snum == "") return "صفر";
            if (snum == "0")
            {
                return yakan[0];
            }
            else
            {
                snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');
                int L = snum.Length / 3 - 1;
                for (int i = 0; i <= L; i++)
                {
                    int b = int.Parse(snum.Substring(i * 3, 3));
                    if (b != 0)
                        stotal = stotal + getnum3(b) + " " + basex[L - i] + " و ";
                }
                stotal = stotal.Substring(0, stotal.Length - 3);
            }
            return stotal;
        }

        public static int? PersianNumberCharactersToInt32(this string str)
        {
            string convertedNum = "";
            foreach (var ch in str)
            {
                char tmp = ' ';
                if (ch == '۹' || ch == '9')
                    tmp = '9';

                if (ch == '۸' || ch == '8')
                    tmp = '8';

                if (ch == '۷' || ch == '7')
                    tmp = '7';

                if (ch == '۶' || ch == '6')
                    tmp = '6';

                if (ch == '۵' || ch == '5')
                    tmp = '5';

                if (ch == '۴' || ch == '4')
                    tmp = '4';

                if (ch == '۳' || ch == '3')
                    tmp = '3';

                if (ch == '۲' || ch == '2')
                    tmp = '2';

                if (ch == '۱' || ch == '1')
                    tmp = '1';

                if (ch == '۰' || ch == '0')
                    tmp = '0';

                convertedNum += tmp;
            }

            convertedNum = convertedNum.Trim().Replace(" ", "");

            if (string.IsNullOrEmpty(convertedNum))
                return null;

            return Convert.ToInt32(convertedNum);
        }
    }
}