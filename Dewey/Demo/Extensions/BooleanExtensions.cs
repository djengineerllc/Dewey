using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public static class BooleanExtensions
    {
        public static string ToString(this bool value, string format)
        {
            return string.Format(new BoolFormatProvider(), format, value);
        }
    }
    public class BoolFormatProvider : IFormatProvider, ICustomFormatter
    {
        #region ICustomFormatter Members

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            bool value = (bool)arg;
            format = (format == null ? null : format.Trim().ToLower());
            string ret = string.Empty;
            switch (format)
            {
                case "yn":
                    ret = value ? "Yes" : "No";
                    break;
                case "10":
                    ret = value ? "1" : "0";
                    break;
                case "onoff":
                    ret = value ? "On" : "Off";
                    break;
                default:
                    if (arg is IFormatProvider)
                    {
                        ret = ((IFormattable)arg).ToString(format, formatProvider);
                    }
                    else
                    {
                        ret = arg.ToString();
                    }
                    break;
            }
            return ret;
        }

        #endregion

        #region IFormatProvider Members

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        #endregion
    }
}