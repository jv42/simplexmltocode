using System.Linq;
using System.Text;

namespace XmlToSerialisableClass.Elements
{
	public class BoolElement : Element
	{
		private readonly string _trueValue;
		private readonly string _falseValue;

		public BoolElement(string name, string trueValue, string falseValue) : base(name)
		{
			_trueValue = trueValue;
			_falseValue = falseValue;
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
				strBuilder.AppendLine(string.Format("get {{ return Value==null ? String.Empty : Value.Value ? \"{0}\" : \"{1}\"; }}", _trueValue, _falseValue));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) Value = null;"));
				strBuilder.AppendLine(string.Format("else Value = value == \"{0}\";", _trueValue));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("get {{ return Value ? \"{0}\" : \"{1}\"; }}", _trueValue, _falseValue));
				strBuilder.AppendLine(string.Format("set {{ Value = value == \"{0}\"; }}", _trueValue));
			}

			strBuilder.AppendLine(string.Format("}}"));

			return strBuilder.ToString();
		}
	}
}