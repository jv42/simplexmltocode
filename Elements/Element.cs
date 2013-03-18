using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XmlToSerialisableClass.Attributes;

namespace XmlToSerialisableClass.Elements
{
    public class Element
    {
    	private readonly string _xmlName;

        public string Name { get; set; }
		public bool Enumerable { get; set; }
		public bool IsRoot { get; set; }
    	public DataType Type { get; set; }

		public List<Attribute> Attributes { get; private set; }
		public List<Element> Elements { get; private set; }

		public List<XAttribute> NamespaceAttributes { get; set; }

    	public XElement OriginalElement { get; set; }

        public Element(string name)
        {
            Name = name;
        	_xmlName = name;
        	IsRoot = false;

			Attributes = new List<Attribute>();
			Elements = new List<Element>();
			NamespaceAttributes = new List<XAttribute>();
        }

		public virtual string ParentToString()
		{
			return ToString();
		}

    	public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(string.Format("[XmlElement(\"{0}\")]", _xmlName));
			if (Enumerable)
				strBuilder.AppendLine(string.Format("public List<{0}> {0} {{ get; set; }}", Name));
			else
				strBuilder.AppendLine(string.Format("public {0} {0} {{ get; set; }}", Name));

			return strBuilder.ToString();
		}
    }
}