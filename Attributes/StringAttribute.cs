using System.Text;

namespace XmlToSerialisableClass.Attributes
{
    public class StringAttribute : Attribute
    {
        public StringAttribute(string name) : base(name)
        { }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(string.Format("[XmlAttribute(\"{0}\")]", XmlName));
            strBuilder.AppendLine(string.Format("public string {0} {{ get; set; }}", Name));

            return strBuilder.ToString();
        }
    }
}