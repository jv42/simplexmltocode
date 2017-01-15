using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace XmlToSerialisableClass
{
    public class XmlDataType
    {
        public bool IsNullable { get; set; }
        public Type? DataType { get; set; }

        public enum Type
        {
            DateTime,
            Date,
            @string,
            @int,
            @decimal,
            @bool,   // true / false
            Bool     // True / False
        };

        public static bool operator ==(XmlDataType a, XmlDataType b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.IsNullable == b.IsNullable && a.DataType == b.DataType;
        }

        public static bool operator !=(XmlDataType a, XmlDataType b)
        {
            return !(a == b);
        }



        private static XmlDataType GetDataType(string value, string dateFormat, string dateTimeFormat)
        {
            var thisType = new XmlDataType { IsNullable = false, DataType = null };

            // IF EMPTY ASSUME STRING
            if (string.IsNullOrWhiteSpace(value))
                return new XmlDataType { IsNullable = true, DataType = null };

            // TRY PARSE AS DATE
            if (!string.IsNullOrWhiteSpace(dateFormat))
            {
                DateTime date;
                if (DateTime.TryParseExact(value,
                                       dateFormat,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out date))
                {
                    thisType.DataType = Type.Date;
                }
            }

            // TRY PARSE AS DATE TIME
            if (!string.IsNullOrWhiteSpace(dateTimeFormat))
            {
                DateTime datetime;
                if (DateTime.TryParseExact(value,
                                       dateTimeFormat,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out datetime))
                {
                    thisType.DataType = Type.DateTime;
                }
            }

            // TRY PARSE AS NUMERIC
            if (!string.IsNullOrWhiteSpace(value))
            {
                decimal num;
                var isNum = decimal.TryParse(value, out num);
                if (isNum)
                {
                    // DECIMAL OR INTEGER
                    if (value.Contains(".")) thisType.DataType = Type.@decimal;
                    else thisType.DataType = (num % 1) == 0 ? Type.@int : Type.@decimal;
                }
            }

            // TRY PARSE AS BOOLEAN
            if (value == "True" || value == "False")
                thisType.DataType = Type.Bool;

            if (value == "true" || value == "false")
                thisType.DataType = Type.@bool;

            if (!string.IsNullOrWhiteSpace(value) && thisType.DataType == null)
                thisType.DataType = Type.@string;

            return thisType;
        }

        public static XmlDataType GetDataTypeFromList(List<string> values, string dateFormat, string dateTimeFormat)
        {
            if (!values.Any())
                return new XmlDataType { IsNullable = true, DataType = Type.@string };

            XmlDataType returnType = null;
            foreach (var value in values)
            {
                var thisType = GetDataType(value, dateFormat, dateTimeFormat);

                if (returnType == null)
                    returnType = thisType;
                else
                    returnType = GetBestType(thisType, returnType);
            }

            if (returnType == null || returnType.DataType == null)
                returnType = new XmlDataType { IsNullable = true, DataType = Type.@string };

            return returnType;
        }

        public static XmlDataType GetBestType(XmlDataType type1, XmlDataType type2)
        {
            var returnType = new XmlDataType();

            if (type1.DataType == null && type2.DataType != null)
                returnType.DataType = type2.DataType;
            else if (type1.DataType != null && type2.DataType == null)
                returnType.DataType = type1.DataType;
            else if (type1.DataType == type2.DataType)
                returnType.DataType = type1.DataType;
            else if (type1.DataType == Type.@string || type2.DataType == Type.@string)
                returnType.DataType = Type.@string;
            else if (type1.DataType == Type.DateTime && type2.DataType == Type.Date || type1.DataType == Type.Date && type2.DataType == Type.DateTime)
                returnType.DataType = Type.DateTime;
            else if (type1.DataType == Type.@decimal && type2.DataType == Type.@int || type1.DataType == Type.@int && type2.DataType == Type.@decimal)
                returnType.DataType = Type.@decimal;
            else if (type1.DataType == Type.@bool && type2.DataType == Type.Bool || type1.DataType == Type.Bool && type2.DataType == Type.@bool)
                returnType.DataType = Type.@bool;
            else
                returnType.DataType = Type.@string;

            returnType.IsNullable = type1.IsNullable || type2.IsNullable;

            return returnType;
        }

        private bool Equals(XmlDataType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.IsNullable.Equals(IsNullable) && other.DataType.Equals(DataType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(XmlDataType)) return false;
            return Equals((XmlDataType)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (IsNullable.GetHashCode() * 397) ^ (DataType.HasValue ? DataType.Value.GetHashCode() : 0);
            }
        }
    }
}
