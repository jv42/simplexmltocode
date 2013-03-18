using System.Linq;
using System.Text;

namespace XmlToSerialisableClass
{
	public static class Format
	{
		public static string Code(string code)
		{
			var formattedCode = new StringBuilder();
			var tabLevel = 0;
			var codeLines = code.Split('\n');
			foreach (var codeLine in codeLines.Select(c => c.Trim()))
				if (!(codeLine.StartsWith("{") && codeLine.EndsWith("}")))
					if (codeLine.StartsWith("{") || codeLine.EndsWith("{"))
						formattedCode.AppendLine("".PadLeft(tabLevel++, '\t') + codeLine);
					else if (codeLine.StartsWith("}") && codeLine.EndsWith("}"))
						formattedCode.AppendLine("".PadLeft(--tabLevel, '\t') + codeLine);
					else
						formattedCode.AppendLine("".PadLeft(tabLevel, '\t') + codeLine);
				else
					formattedCode.AppendLine("".PadLeft(tabLevel, '\t') + codeLine);
			return formattedCode.ToString();
		}
	}
}