using System.Linq;
using System.Text;

namespace XmlToSerialisableClass.Elements
{
	public class IntElement : Element
	{
		public IntElement(string name): base(name)
		{ }

		public override string ParentToString()
		{
			return base.ToString();
		}

		public override string ToString()
		{
			if (Elements.Any())
				return base.ToString();

			var strBuilder = new StringBuilder();
			
			if (Type.IsNullable)
			{
				strBuilder.AppendLine(string.Format("[XmlIgnore]"));
				strBuilder.AppendLine(string.Format("public int? Value {{ get; set; }}"));
				strBuilder.AppendLine(string.Format("[XmlText]"));
				strBuilder.AppendLine(string.Format("public string ValueString"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("get {{ return Value==null ? String.Empty : Value.Value.ToString(CultureInfo.InvariantCulture); }}"));
				strBuilder.AppendLine(string.Format("set"));
				strBuilder.AppendLine(string.Format("{{"));
				strBuilder.AppendLine(string.Format("if (String.IsNullOrWhiteSpace(value)) Value = null;"));
				strBuilder.AppendLine(string.Format("else Value = int.Parse(value);"));
				strBuilder.AppendLine(string.Format("}}"));
				strBuilder.AppendLine(string.Format("}}"));
			}
			else
			{
				strBuilder.AppendLine(string.Format("[XmlText]"));
				strBuilder.AppendLine(string.Format("public int Value {{ get; set; }}"));
			}

			return strBuilder.ToString();
		}
	}
}