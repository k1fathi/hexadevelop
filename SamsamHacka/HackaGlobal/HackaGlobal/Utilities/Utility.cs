using System;
using System.Linq;

namespace HackaGlobal.Utilities
{
    public static class Utilities
    {
        public static T NewDefaultValue<T>(this T enitty) where T : class
        {

            enitty.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (p.PropertyType == typeof(bool) || p.PropertyType == typeof(bool?))
                    p.SetValue(enitty, false, null);
                if (p.PropertyType == typeof(byte) || p.PropertyType == typeof(byte?))
                    p.SetValue(enitty, Convert.ToByte(0), null);
                if (p.PropertyType == typeof(Int16) || p.PropertyType == typeof(Int16?))
                    p.SetValue(enitty, Convert.ToInt16(0), null);
                if (p.PropertyType == typeof(Int32) || p.PropertyType == typeof(Int32?))
                    p.SetValue(enitty, Convert.ToInt32(0), null);
                if (p.PropertyType == typeof(Int64) || p.PropertyType == typeof(Int64?))
                    p.SetValue(enitty, Convert.ToInt64(0), null);
                if (p.PropertyType == typeof(Decimal) || p.PropertyType == typeof(Decimal?))
                    p.SetValue(enitty, Convert.ToDecimal(0), null);
                if (p.PropertyType == typeof(float) || p.PropertyType == typeof(float?))
                    p.SetValue(enitty, float.Parse("0"), null);
                if (p.PropertyType == typeof(Double) || p.PropertyType == typeof(Double?))
                    p.SetValue(enitty, Convert.ToDouble(0), null);
                if (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                    p.SetValue(enitty, new DateTime(), null);
                if (p.PropertyType == typeof(DateTimeOffset) || p.PropertyType == typeof(DateTimeOffset?))
                    p.SetValue(enitty, new DateTimeOffset(), null);
                if (p.PropertyType == typeof(string))
                    p.SetValue(enitty, "", null);
                if (p.PropertyType == typeof(byte[]))
                    p.SetValue(enitty, new byte[] { }, null);
            });
            return enitty;
        }
    }
}