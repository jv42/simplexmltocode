using System.Text;

namespace XmlToSerialisableClass.Attributes
{
	public class SchemaLocationAttribute : Attribute
	{
		private readonly string _value;

		public SchemaLocationAttribute(string name, string value) : base(name)
		{
			_value = value;
		}

		public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlAttribute(\"schemaLocation\", Namespace = XmlSchema.InstanceNamespace)]"));
			strBuilder.AppendLine(string.Format("public string XsiSchemaLocation = \"{0}\";", _value));

			return strBuilder.ToString();
		}
	}
}