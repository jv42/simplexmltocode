using System.Text;

namespace XmlToSerialisableClass.Attributes
{
	public class BoolAttribute : Attribute
	{
		private readonly string _trueValue;
		private readonly string _falseValue;

		public BoolAttribute(string name, string trueValue, string falseValue) : base(name)
		{
			_trueValue = trueValue;
			_falseValue = falseValue;
		}

		public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlIgnore]"));
			strBuilder.AppendLine(string.Format("public bool{0} {1} {{ get; set; }}", Type.nullable ? "?" : "", Name));
			strBuilder.AppendLine(string.Format("[XmlAttribute(\"{0}\")]", Name));
			strBuilder.AppendLine(string.Format("public string {0}String", Name));
			strBuilder.AppendLine(string.Format("{{"));

			if (Type.nullable)
			{
				strBuilder.AppendLine(string.Format("get {{ return {0}==null ? \"\" : {0}.Value ? \"{0}\" : \"{1}\"; }}", _trueValue, _falseValue));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) {0} = null;", Name));
				strBuilder.AppendLine(string.Format("else {0} = value == \"{1}\";", Name, _trueValue));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("get {{ return {0} ? \"{0}\" : \"{1}\"; }}", _trueValue, _falseValue));
				strBuilder.AppendLine(string.Format("set {{ {0} = value == \"{1}\"; }}", Name, _trueValue));
			}

			strBuilder.AppendLine(string.Format("}}"));

			return strBuilder.ToString();
		}
	}
}