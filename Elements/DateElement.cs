using System.Linq;
using System.Text;

namespace XmlToSerialisableClass.Elements
{
	public class DateTimeElement : Element
	{
		private readonly string _dateTimeFormat;

		public DateTimeElement(string name, string dateTimeFormat) : base(name)
		{
			_dateTimeFormat = dateTimeFormat;
		}

		public override string ParentToString()
		{
			return base.ToString();
		}

		public override string ToString()
		{
			if (Elements.Any())
				return base.ToString();

			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlIgnore]"));
			strBuilder.AppendLine(string.Format("public DateTime{0} Value {{ get; set; }}", Type.nullable ? "?" : ""));
			strBuilder.AppendLine(string.Format("[XmlText]"));
			strBuilder.AppendLine(string.Format("public string ValueString"));
			strBuilder.AppendLine(string.Format("{{"));

			if (Type.nullable)
			{
				strBuilder.AppendLine(string.Format("get {{ return Value==null ? \"\" : Value.Value.ToString(\"{0}\"); }}", _dateTimeFormat));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) Value = null;"));
				strBuilder.AppendLine(string.Format("else Value = DateTime.ParseExact(value, \"{0}\", null);", _dateTimeFormat));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("get {{ return Value.ToString(\"{0}\"); }}", _dateTimeFormat));
				strBuilder.AppendLine(string.Format("set {{ Value = DateTime.ParseExact(value, \"{0}\", null); }}", _dateTimeFormat));
			}

			strBuilder.AppendLine(string.Format("}}"));

			return strBuilder.ToString();
		}
	}
}