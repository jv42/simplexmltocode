using System.Text;

namespace XmlToSerialisableClass.Attributes
{
	public class DateTimeAttribute : Attribute
	{
		private readonly string _dateTimeFormat;

		public DateTimeAttribute(string name, string dateTimeFormat) : base(name)
		{
			_dateTimeFormat = dateTimeFormat;
		}

		public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlIgnore]"));
			strBuilder.AppendLine(string.Format("public DateTime{0} {1} {{ get; set; }}", Type.nullable ? "?" : "", Name));
			strBuilder.AppendLine(string.Format("[XmlAttribute(\"{0}\")]", XmlName));
			strBuilder.AppendLine(string.Format("public string {0}String", Name));
			strBuilder.AppendLine(string.Format("{{"));

			if (Type.nullable)
			{
				strBuilder.AppendLine(string.Format("get {{ return {0}==null ? String.Empty : {0}.Value.ToString(\"{1}\"); }}", Name,  _dateTimeFormat));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) {0} = null;", Name));
				strBuilder.AppendLine(string.Format("else {0} = DateTime.ParseExact(value, \"{1}\", null);", Name, _dateTimeFormat));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("get {{ return {0}.ToString(\"{1}\"); }}", Name, _dateTimeFormat));
				strBuilder.AppendLine(string.Format("set {{ {0} = DateTime.ParseExact(value, \"{1}\", null); }}", Name, _dateTimeFormat));
			}

			strBuilder.AppendLine(string.Format("}}"));

			return strBuilder.ToString();
		}
	}
}