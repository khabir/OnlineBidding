using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineBidding.Helper
{
    public static class XMLExtensions
    {
        public static string GetStringValue(this XElement element, string field)
        {
            return (element.Element(field) == null) ? null : element.Element(field).Value;
        }
        public static char GetCharValue(this XElement element, string field)
        {
            return (element.Element(field) == null) ? ' ' : Convert.ToChar(element.Element(field).Value);
        }
        public static bool? GetBooleanValue(this XElement element, string field)
        {
            if (element.Element(field) == null)
                return null;
            else
                return Convert.ToBoolean(element.Element(field).Value);
        }
        public static DateTime? GetDateTimeValue(this XElement element, string field)
        {
            if (element.Element(field) == null)
                return null;

            DateTime result;

            DateTime.TryParse(element.Element(field).Value, out result);

            return result;
        }

        public static int? GetIntValue(this XElement element, string field)
        {
            if (element.Element(field) == null)
                return null;

            int result;

            int.TryParse(element.Element(field).Value, out result);

            return result;
        }

        public static byte[] GetByteArrayValue(this XElement element, string field)
        {
            return null;
        }

    }
}