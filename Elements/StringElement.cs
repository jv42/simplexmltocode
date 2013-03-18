using System.Linq;
using System.Text;

namespace XmlToSerialisableClass.Elements
{
	public class StringElement : Element
	{
		public StringElement(string name) : base(name)
		{}

		public override string ParentToString()
		{
			return base.ToString();
		}

		public override string ToString()
		{
			if (Elements.Any())
				return base.ToString();

			var strBuilder = new StringBuilder();
			
			strBuilder.AppendLine(string.Format("[XmlText]"));
			strBuilder.AppendLine(string.Format("public string Value {{ get; set; }}"));

			return strBuilder.ToString();
		}
	}
}