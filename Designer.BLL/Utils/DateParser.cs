using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Utils
{
    public static class DateParser
    {
        public static DateTime ParseDate(string date)
        {
            string lastChar = date.Substring(date.Length - 1);
            string format;

            if(lastChar == "Z")
            {
                format = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";
            }
            else
            {
                format = "dd-MM-yy HH:mm:ss";
            }
            
            IFormatProvider provider = CultureInfo.InvariantCulture;
            var styles = DateTimeStyles.None;

            DateTime parsedDate = new DateTime();

            try
            {
                parsedDate = DateTime.ParseExact(date, format, provider, styles);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return parsedDate;

        }
    }
}
