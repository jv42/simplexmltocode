using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace XmlToSerialisableClass
{
	public class DataType
	{
		public bool nullable { get; set; }
		public Type? type { get; set; }

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

		public static bool operator ==(DataType a, DataType b)
		{
			if (ReferenceEquals(a, b))
				return true;

			if (((object)a == null) || ((object)b == null))
				return false;

			return a.nullable == b.nullable && a.type == b.type;
		}

		public static bool operator !=(DataType a, DataType b)
		{
			return !(a == b);
		}



		private static DataType GetDataType(string value, string dateFormat, string dateTimeFormat)
		{
			var thisType = new DataType { nullable = false, type = null };

			// IF EMPTY ASSUME STRING
			if (string.IsNullOrWhiteSpace(value))
				return new DataType { nullable = true, type = null };

			// TRY PARSE AS DATE
			if (!string.IsNullOrWhiteSpace(dateFormat))
			{
				DateTime date;
				DateTime.TryParseExact(value,
									   dateFormat,
									   CultureInfo.InvariantCulture,
									   DateTimeStyles.None,
									   out date);
				if (date != DateTime.MinValue && date != DateTime.MaxValue)
					thisType.type = Type.Date;
			}

			// TRY PARSE AS DATE TIME
			if (!string.IsNullOrWhiteSpace(dateFormat))
			{
				DateTime datetime;
				DateTime.TryParseExact(value,
									   dateTimeFormat,
									   CultureInfo.InvariantCulture,
									   DateTimeStyles.None,
									   out datetime);
				if (datetime != DateTime.MinValue && datetime != DateTime.MaxValue)
					thisType.type = Type.DateTime;
			}

			// TRY PARSE AS NUMERIC
			if (!string.IsNullOrWhiteSpace(value))
			{
				decimal num;
				var isNum = decimal.TryParse(value, out num);
				if (isNum)
				{
					// DECIMAL OR INTEGER
					if (value.Contains(".")) thisType.type = Type.@decimal;
					else thisType.type = (num % 1) == 0 ? Type.@int : Type.@decimal;
				}
			}

			// TRY PARSE AS BOOLEAN
			if (value == "True" || value == "False")
				thisType.type = Type.Bool;

			if (value == "true" || value == "false")
				thisType.type = Type.@bool;

			if (!string.IsNullOrWhiteSpace(value) && thisType.type == null)
				thisType.type = Type.@string;

			return thisType;
		}

		public static DataType GetDataTypeFromList(List<string> values, string dateFormat, string dateTimeFormat)
		{
			if (!values.Any()) return new DataType { nullable = true, type = Type.@string };

			DataType returnType = null;
			foreach (var value in values)
			{
				var thisType = GetDataType(value, dateFormat, dateTimeFormat);

				if (returnType == null)
					returnType = thisType;
				else
					returnType = GetBestType(thisType, returnType);
			}

			if (returnType == null || returnType.type == null)
				returnType = new DataType { nullable = true, type = Type.@string };

			return returnType;
		}

		public static DataType GetBestType(DataType type1, DataType type2)
		{
			var returnType = new DataType();

			if (type1.type == null && type2.type != null)
				returnType.type = type2.type;
			else if (type1.type != null && type2.type == null)
				returnType.type = type1.type;
			else if (type1.type == type2.type)
				returnType.type = type1.type;
			else if (type1.type == Type.@string || type2.type == Type.@string)
				returnType.type = Type.@string;
			else if (type1.type == Type.DateTime && type2.type == Type.Date || type1.type == Type.Date && type2.type == Type.DateTime)
				returnType.type = Type.DateTime;
			else if (type1.type == Type.@decimal && type2.type == Type.@int || type1.type == Type.@int && type2.type == Type.@decimal)
				returnType.type = Type.@decimal;
			else if (type1.type == Type.@bool && type2.type == Type.Bool || type1.type == Type.Bool && type2.type == Type.@bool)
				returnType.type = Type.@bool;
			else
				returnType.type = Type.@string;

			returnType.nullable = type1.nullable || type2.nullable;

			return returnType;
		}
	}
}
