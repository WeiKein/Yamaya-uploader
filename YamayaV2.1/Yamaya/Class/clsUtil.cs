using System;

namespace Yamaya
{
    class SafeConvert
    {
        public static string ToString(object obj)
        {
            if (obj == null)
                return string.Empty;

            if (obj == DBNull.Value)
                return string.Empty;

            try
            {
                return Convert.ToString(obj).Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static decimal ToDecimal(object obj)
        {
            if (obj == null)
                return 0;

            if (obj == DBNull.Value)
                return 0;

            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return 0;
            }
        }

        public static int ToInt(object obj)
        {
            if (obj == null)
                return 0;

            if (obj == DBNull.Value)
                return 0;

            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(object obj)
        {
            if (obj == null)
                return DateTime.MinValue;

            if (obj == DBNull.Value)
                return DateTime.MinValue;

            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static bool ToBoolean(object obj)
        {
            if (obj == null)
                return false;

            if (obj == DBNull.Value)
                return false;

            if (ToString(obj) == "0")
                return false;

            if (ToString(obj) == "1")
                return true;

            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return false;
            }
        }
    }
}
