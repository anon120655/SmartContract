
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartContract.Utils
{
    public static class GeneralUtils
    {

        public static string getThaiMonth(int m, string format = "MMMM")
        {
            if (m < 1 || m > 12) return string.Empty;
            var dt = new DateTime(2000, m, 1);
            return dt.ToString(format, new CultureInfo("th-TH"));
        }

        public static string getThaiYear(int y)
        {
            DateTime dateeng = DateTime.ParseExact(y.ToString(), "yyyy", new CultureInfo("en-US"));
            int thaiYear = new ThaiBuddhistCalendar().GetYear(dateeng);

            if (thaiYear < 2500)
            {
                thaiYear = thaiYear + 543;
            }
            if (thaiYear > 3000)
            {
                thaiYear = thaiYear - 543;
            }

            return thaiYear.ToString();
        }

        public static string getFullThaiShot(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                string _datetime = datetime.Value.ToString();
                DateTime dateeng = DateTime.ParseExact(_datetime, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                int thaiYear = new ThaiBuddhistCalendar().GetYear(dateeng);
                int thaiMonth = new ThaiBuddhistCalendar().GetMonth(dateeng);
                int thaiDay = new ThaiBuddhistCalendar().GetDayOfMonth(dateeng);

                string _thaiDay = thaiDay < 10 ? string.Format("{0}{1}", "0", thaiDay) : thaiDay.ToString();
                string _thaiMonth = thaiMonth < 10 ? string.Format("{0}{1}", "0", thaiMonth) : thaiMonth.ToString();

                string MonthCurrentName = string.Empty;
                if (thaiMonth == 1) MonthCurrentName = "ม.ค.";
                if (thaiMonth == 2) MonthCurrentName = "ก.พ.";
                if (thaiMonth == 3) MonthCurrentName = "มี.ค.";
                if (thaiMonth == 4) MonthCurrentName = "เม.ย.";
                if (thaiMonth == 5) MonthCurrentName = "พ.ค.";
                if (thaiMonth == 6) MonthCurrentName = "มิ.ย.";
                if (thaiMonth == 7) MonthCurrentName = "ก.ค.";
                if (thaiMonth == 8) MonthCurrentName = "ส.ค.";
                if (thaiMonth == 9) MonthCurrentName = "ก.ย.";
                if (thaiMonth == 10) MonthCurrentName = "ต.ค.";
                if (thaiMonth == 11) MonthCurrentName = "พ.ย.";
                if (thaiMonth == 12) MonthCurrentName = "ธ.ค.";

                return string.Format("{0} {1} {2}", _thaiDay, MonthCurrentName, thaiYear);
            }
            else
            {
                return String.Empty;
            }
        }

        public static string getFullThaiFullShot(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                string _datetime = datetime.Value.ToString();
                DateTime dateeng = DateTime.ParseExact(_datetime, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                int thaiYear = new ThaiBuddhistCalendar().GetYear(dateeng);
                int thaiMonth = new ThaiBuddhistCalendar().GetMonth(dateeng);
                int thaiDay = new ThaiBuddhistCalendar().GetDayOfMonth(dateeng);

                string _thaiDay = thaiDay < 10 ? string.Format("{0}{1}", "", thaiDay) : thaiDay.ToString();
                string _thaiMonth = thaiMonth < 10 ? string.Format("{0}{1}", "0", thaiMonth) : thaiMonth.ToString();

                string MonthCurrentName = string.Empty;
                if (thaiMonth == 1) MonthCurrentName = "มกราคม";
                if (thaiMonth == 2) MonthCurrentName = "กุมภาพันธ์";
                if (thaiMonth == 3) MonthCurrentName = "มีนาคม";
                if (thaiMonth == 4) MonthCurrentName = "เมษายน";
                if (thaiMonth == 5) MonthCurrentName = "พฤษภาคม";
                if (thaiMonth == 6) MonthCurrentName = "มิถุนายน";
                if (thaiMonth == 7) MonthCurrentName = "กรกฎาคม";
                if (thaiMonth == 8) MonthCurrentName = "สิงหาคม";
                if (thaiMonth == 9) MonthCurrentName = "กันยายน";
                if (thaiMonth == 10) MonthCurrentName = "ตุลาคม";
                if (thaiMonth == 11) MonthCurrentName = "พฤศจิกายน";
                if (thaiMonth == 12) MonthCurrentName = "ธันวาคม";

                return string.Format("{0} {1} {2}", _thaiDay, MonthCurrentName, thaiYear);
            }
            else
            {
                return String.Empty;
            }
        }

        public static bool CheckHashDate(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
                return true;

            return false;
        }

        public static string DateToThString(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                string _datetime = datetime.Value.ToString();
                DateTime dateeng = DateTime.ParseExact(_datetime, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                int thaiYear = new ThaiBuddhistCalendar().GetYear(dateeng);
                int thaiMonth = new ThaiBuddhistCalendar().GetMonth(dateeng);
                int thaiDay = new ThaiBuddhistCalendar().GetDayOfMonth(dateeng);

                if (thaiYear < 2500)
                {
                    thaiYear = thaiYear + 543;
                }
                if (thaiYear > 3000)
                {
                    thaiYear = thaiYear - 543;
                }

                string _thaiDay = thaiDay < 10 ? string.Format("{0}{1}", "0", thaiDay) : thaiDay.ToString();
                string _thaiMonth = thaiMonth < 10 ? string.Format("{0}{1}", "0", thaiMonth) : thaiMonth.ToString();

                return string.Format("{0}/{1}/{2}", _thaiDay, _thaiMonth, thaiYear);
            }
            else
            {
                return String.Empty;
            }
        }

        public static string DateToTimeString(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                DateTime dateeng = DateTime.ParseExact(datetime.Value.ToString(), "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                int hour = new ThaiBuddhistCalendar().GetHour(dateeng);
                int minute = new ThaiBuddhistCalendar().GetMinute(dateeng);
                return $"{hour}:{minute}";
            }
            else
            {
                return String.Empty;
            }
        }

        public static string GetDateHour(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                return string.Format("{0}", datetime.Value.Hour < 10 ? $"0{datetime.Value.Hour}" : datetime.Value.Hour.ToString());
            }
            return String.Empty;
        }

        public static string GetDateMinute(DateTime? datetime)
        {
            if (datetime.HasValue && datetime != DateTime.MinValue)
            {
                return string.Format("{0}", datetime.Value.Minute < 10 ? $"0{datetime.Value.Minute}" : datetime.Value.Minute.ToString());
            }
            return String.Empty;
        }

        public static DateTime? DateToEn(string datetime, string format = "dd/MM/yyyy", string Culture = "th-TH")
        {
            if (DateTime.TryParseExact(datetime, format, new CultureInfo(Culture), DateTimeStyles.None, out DateTime date))
            {
                if (date.Year > 2500)
                {
                    date = date.AddYears(-543);
                }
                return date;
            }
            return null;
        }

        public static DateTime? DateTimeToEn(string datetime, string format = "dd/MM/yyyy", string Culture = "th-TH")
        {
            if (DateTime.TryParseExact(datetime, format, new CultureInfo(Culture), DateTimeStyles.None, out DateTime date))
            {
                if (date.Year > 2500)
                {
                    date = date.AddYears(-543);
                }
                return date;
            }
            return null;
        }

        public static void CopyObject<T>(object sourceObject, ref T destObject)
        {

            //  If either the source, or destination is null, return
            if (sourceObject == null || destObject == null)
                return;

            //  Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //  Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties())
            {
                //  Get the matching property in the destination object
                PropertyInfo targetObj = targetType.GetProperty(p.Name);
                var value = p.GetValue(sourceObject, null);
                //  If there is none, skip                
                if (targetObj == null || value == null || targetObj.GetSetMethod(true) == null)
                    continue;
                //  Set the value in the destination
                if (p.PropertyType == typeof(int) || p.PropertyType == typeof(decimal) || p.PropertyType == typeof(short) || p.PropertyType == typeof(double))
                {
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        targetObj.SetValue(destObject, value, null);
                }
                else if (p.PropertyType == typeof(Guid))
                {
                    if (value == null || (Guid)value == Guid.Empty)
                        continue;
                    else
                        targetObj.SetValue(destObject, value, null);
                }
                else
                {
                    targetObj.SetValue(destObject, value, null);
                }
            }
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetExMessage(Exception ex)
        {
            String messageError = ex.Message;
            if (ex.InnerException != null && ex.InnerException.Message != null)
            {
                messageError = ex.InnerException.Message;
            }

            return messageError;
        }

        public static string WappText(string text, int cutNo)
        {
            var textlenght = text.Length;
            var textNew = text;
            if (textlenght > cutNo)
            {
                textNew = text.Substring(0, cutNo);
            }
            return textNew;
        }

        public static string GetRandomString(int stringLength)
        {
            StringBuilder sb = new StringBuilder();
            int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
            for (int i = 1; i <= numGuidsToConcat; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }

            return sb.ToString(0, stringLength);
        }

        public static string ThaiBahtText(string strNumber, bool IsTrillion = false)
        {
            string BahtText = "";
            string strTrillion = "";
            string[] strThaiNumber = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] strThaiPos = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };

            decimal decNumber = 0;
            decimal.TryParse(strNumber, out decNumber);

            if (decNumber == 0)
            {
                return "ศูนย์บาทถ้วน";
            }

            strNumber = decNumber.ToString("0.00");
            string strInteger = strNumber.Split('.')[0];
            string strSatang = strNumber.Split('.')[1];

            if (strInteger.Length > 13)
                throw new Exception("รองรับตัวเลขได้เพียง ล้านล้าน เท่านั้น!");

            bool _IsTrillion = strInteger.Length > 7;
            if (_IsTrillion)
            {
                strTrillion = strInteger.Substring(0, strInteger.Length - 6);
                BahtText = ThaiBahtText(strTrillion, _IsTrillion);
                strInteger = strInteger.Substring(strTrillion.Length);
            }

            int strLength = strInteger.Length;
            for (int i = 0; i < strInteger.Length; i++)
            {
                string number = strInteger.Substring(i, 1);
                if (number != "0")
                {
                    if (i == strLength - 1 && number == "1" && strLength != 1)
                    {
                        BahtText += "เอ็ด";
                    }
                    else if (i == strLength - 2 && number == "2" && strLength != 1)
                    {
                        BahtText += "ยี่";
                    }
                    else if (i != strLength - 2 || number != "1")
                    {
                        BahtText += strThaiNumber[int.Parse(number)];
                    }

                    BahtText += strThaiPos[(strLength - i) - 1];
                }
            }

            if (IsTrillion)
            {
                return BahtText + "ล้าน";
            }

            if (strInteger != "0")
            {
                BahtText += "บาท";
            }

            if (strSatang == "00")
            {
                BahtText += "ถ้วน";
            }
            else
            {
                strLength = strSatang.Length;
                for (int i = 0; i < strSatang.Length; i++)
                {
                    string number = strSatang.Substring(i, 1);
                    if (number != "0")
                    {
                        if (i == strLength - 1 && number == "1" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "เอ็ด";
                        }
                        else if (i == strLength - 2 && number == "2" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "ยี่";
                        }
                        else if (i != strLength - 2 || number != "1")
                        {
                            BahtText += strThaiNumber[int.Parse(number)];
                        }

                        BahtText += strThaiPos[(strLength - i) - 1];
                    }
                }

                BahtText += "สตางค์";
            }

            return BahtText;
        }

        public static bool IsBase64String(string base64)
        {
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public static int getNumberOfPdfPages(byte[] _Bytes)
        {
            Stream stream = new MemoryStream(_Bytes);
            using (StreamReader sr = new StreamReader(stream))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

        public static int getNumberOfPdfPage(String fileName)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(fileName.Replace("\\", "//"))))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

    }
}
