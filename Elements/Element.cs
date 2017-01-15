using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using XmlToSerialisableClass.Attributes;
using XmlToSerialisableClass.Helpers;

namespace XmlToSerialisableClass.Elements
{
    public class Element
    {
        private readonly string _xmlName;

        public string XmlName { get { return _xmlName; } }

        public string Name { get; set; }
        public bool IsEnumerable { get; set; }
        public bool IsRoot { get; set; }
        public XmlDataType Type { get; set; }

        public List<Attribute> Attributes { get; private set; }
        public List<Element> Elements { get; private set; }

        public List<XAttribute> NamespaceAttributes { get; set; }

        public XElement OriginalElement { get; set; }

        private static StringHelpers _helper;
        static Element()
        {
            _helper = new StringHelpers();
        }


        public Element(string name)
        {
            Name = _helper.ToPascalCase(name);
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

            strBuilder.AppendLine(string.Format("[XmlElement(\"{0}\")]", XmlName));
            if (IsEnumerable)
                strBuilder.AppendLine(string.Format("public List<{0}> {1} {{ get; set; }}", Name, _helper.MakePlural(Name)));
            else
                strBuilder.AppendLine(string.Format("public {0} {0} {{ get; set; }}", Name));

            return strBuilder.ToString();
        }

        public Element FindElement(XElement element)
        {
            if (OriginalElement == element)
                return this;

            foreach (var child in Elements)
            {
                var found = child.FindElement(element);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}