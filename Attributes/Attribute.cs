using XmlToSerialisableClass.Helpers;

namespace XmlToSerialisableClass.Attributes
{
    public class Attribute
    {
        private readonly string _xmlName;
        public string XmlName { get { return _xmlName; } }

        public string Name { get; set; }
        public XmlDataType Type { get; set; }

        private static readonly StringHelpers _helper;
        static Attribute()
        {
            _helper = new StringHelpers();
        }

        public Attribute(string name)
        {
            _xmlName = name;
            Name = _helper.ToPascalCase(name);
        }
    }
}