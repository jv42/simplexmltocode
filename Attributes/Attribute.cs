namespace XmlToSerialisableClass.Attributes
{
    public class Attribute
	{
		public string Name { get; set; }
		public DataType Type { get; set; }

		public Attribute(string name)
		{
			Name = name;
		}
    }
}