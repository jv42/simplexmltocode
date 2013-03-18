using System.Text;

namespace XmlToSerialisableClass.Attributes
{
	public class IntAttribute : Attribute
	{
		public IntAttribute(string name) : base(name)
		{
		}

		public override string ToString()
		{
			var strBuilder = new StringBuilder();
			
			if (Type.nullable)
			{
				strBuilder.AppendLine(string.Format("[XmlIgnore]"));
				strBuilder.AppendLine(string.Format("public int? {0} {{ get; set; }}", Name));
				strBuilder.AppendLine(string.Format("[XmlAttribute(\"{0}\")]", Name));
				strBuilder.AppendLine(string.Format("public string {0}String", Name));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("get {{ return {0}==null ? \"\" : {0}.Value.ToString(CultureInfo.InvariantCulture); }}", Name));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) {0} = null;", Name));
				strBuilder.AppendLine(string.Format("else {0} = int.Parse(value);", Name));
				strBuilder.AppendLine(string.Format("}}"));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("[XmlAttribute(\"{0}\")]", Name));
				strBuilder.AppendLine(string.Format("public int {0}  {{ get; set; }}", Name));
			}

			return strBuilder.ToString();
		}
	}
}