using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlToSerialisableClass.Helpers
{
    class StringHelpers
    {
        private readonly StringBuilder _sb;
        private readonly char[] _separators;

        public StringHelpers()
        {
            _sb = new StringBuilder();
            _separators = new char[] { ' ', '_' };
        }

        public string ToPascalCase(string str)
        {
            _sb.Clear();

            var parts = str.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length <= 1)
            {
                _sb.Append(str.Substring(0, 1).ToUpper());
                if (str.Length > 1)
                {
                    _sb.Append(str.Substring(1));       // Do not call ToLower() here, we can be converting from camelCase.
                }
            }
            else
            {
                foreach (var part in parts)
                {
                    _sb.Append(part.Substring(0, 1).ToUpper());
                    if (part.Length > 1)
                    {
                        _sb.Append(part.Substring(1).ToLower());    // Here we want ToLower(), we're converting from SEPARATE_WORDS
                    }
                }
            }
            return _sb.ToString();
        }

        /// <summary>
        /// Makes plural variant of name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The plural of name</returns>
        public string MakePlural(string name)
        {
            // TODO: some rules
            return name + "s";
        }
    }
}
