using System.Text;
using System.Xml.Linq;

namespace XmlToSerialisableClass.Attributes
{
	public class XmlTypeAttribute : XAttribute
	{
		public XmlTypeAttribute(XName name, string value) : base(name, value)
		{}

		public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlTypeAttribute(AnonymousType = {0}, Namespace = {1})]", string.IsNullOrWhiteSpace(Name.NamespaceName)?"true":"false", Value));

			return strBuilder.ToString();
		}
	}
}