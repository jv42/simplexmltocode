//#define USE_LEGACY_CLASS_CONFLICT_POLICY

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlToSerialisableClass.Attributes;
using XmlToSerialisableClass.Elements;
using XmlToSerialisableClass.Helpers;
using Attribute = XmlToSerialisableClass.Attributes.Attribute;

namespace XmlToSerialisableClass
{
    public class XmlToCode
    {
        private readonly StringHelpers _helper;

        private readonly string _namespace;
        private readonly string _outputFolder;
        private readonly string _dateFormat;
        private readonly string _dateTimeFormat;

        private readonly XElement _oldRoot;

        private readonly string _classTemplate;


        private Element _newRoot;


        /// <summary>
        /// Initializes a new instance of the <see cref="XmlToCode"/> class.
        /// </summary>
        /// <param name="oldRoot">The old root.</param>
        /// <param name="nameSpace">The name space.</param>
        /// <param name="outputFolder">The output folder.</param>
        /// <param name="dateFormat">The date format.</param>
        /// <param name="dateTimeFormat">The date time format.</param>
        /// <param name="classTemplate">The class template.</param>
        public XmlToCode(XElement oldRoot, string nameSpace, string outputFolder, string dateFormat, string dateTimeFormat, string classTemplate)
        {
            _oldRoot = oldRoot;
            _namespace = nameSpace;
            _outputFolder = outputFolder;
            _dateFormat = dateFormat;
            _dateTimeFormat = dateTimeFormat;
            _classTemplate = classTemplate;

            _helper = new StringHelpers();
        }

        /// <summary>
        /// Start the conversion.
        /// </summary>
        /// <param name="logMethod">The log method.</param>
        /// <returns>
        /// An awaitable Task
        /// </returns>
        public async Task ConvertAsync(Action<string> logMethod)
        {
            logMethod("Starting conversion...");

            logMethod("Reading elements...");
            await Task.Run(() =>
            {
                var newElement = ConvertXElementToElement(_oldRoot);
                _newRoot = new Element(newElement.XmlName) { IsRoot = true };

                ConsolidateElements(_newRoot, newElement);

                _newRoot.Attributes.AddRange(newElement.Attributes);
                _newRoot.NamespaceAttributes.AddRange(newElement.NamespaceAttributes);
            }
            );

            logMethod("Resolving conflicts...");

            await Task.Run(() =>
            {
                RenameConflictingClasses(_newRoot);
            }
            );

            logMethod("Creating files...");

            await Task.Run(() =>
            {
                ConvertToFiles(_newRoot);
            }
            );

            logMethod("Done!");
        }

        private Element ConvertXElementToElement(XElement element)
        {
            var elementValues = new List<string>();

            // Leaf element?
            if (!element.Elements().Any())
            {
                var tElem = _oldRoot.Descendants(element.Name).Where(x => GetParentsAsString(x, -1) == GetParentsAsString(element, -1) && !x.Elements().Any()).Select(e => e.Value);
                elementValues.AddRange(tElem);
            }

            // Create the element
            var xElementList = _oldRoot.Descendants(element.Name).GroupBy(el => el.Parent).Select(g => new { g.Key, Count = g.Count() }).Where(x => x.Count > 1);
            Element returnElement;
            var elementName = element.Name.LocalName;
            var elementType = XmlDataType.GetDataTypeFromList(elementValues, _dateFormat, _dateTimeFormat);
            switch (elementType.DataType)
            {
                case XmlDataType.Type.Date:
                    returnElement = new DateTimeElement(elementName, _dateFormat);
                    break;
                case XmlDataType.Type.DateTime:
                    returnElement = new DateTimeElement(elementName, _dateTimeFormat);
                    break;
                case XmlDataType.Type.Bool:
                    returnElement = new BoolElement(elementName, "True", "False");
                    break;
                case XmlDataType.Type.@bool:
                    returnElement = new BoolElement(elementName, "true", "false");
                    break;
                case XmlDataType.Type.@int:
                    returnElement = new IntElement(elementName);
                    break;
                case XmlDataType.Type.@decimal:
                    returnElement = new DecimalElement(elementName);
                    break;
                case XmlDataType.Type.@string:
                    returnElement = new StringElement(elementName);
                    break;
                default:
                    returnElement = new Element(elementName);
                    break;
            }

            returnElement.IsEnumerable = xElementList.Any();
            returnElement.Type = elementType;
            returnElement.OriginalElement = element;

            // Recursive calls for element's children
            foreach (var xElement in element.Elements())
            {
                returnElement.Elements.Add(ConvertXElementToElement(xElement));
            }

            // Treat element's attributes
            foreach (var xAttribute in element.Attributes())
            {
                var tElements = _oldRoot.DescendantsAndSelf(element.Name).Where(x => GetParentsAsString(x, -1) == GetParentsAsString(element, -1)).ToList();

                var xAttr = xAttribute;
                var attributeValues = tElements.Select(tElement => tElement.Attribute(xAttr.Name)).Select(attribute => attribute != null ? attribute.Value : "").ToList();

                Attribute thisAttribute;
                var attributeName = xAttribute.Name.LocalName;

                if (xAttribute.IsNamespaceDeclaration)
                {
                    returnElement.NamespaceAttributes.Add(xAttribute);
                    continue;
                }

                if (attributeName == "schemaLocation")
                {
                    thisAttribute = new SchemaLocationAttribute(attributeName, xAttribute.Value);
                    returnElement.Attributes.Add(thisAttribute);
                    continue;
                }

                var attributeType = XmlDataType.GetDataTypeFromList(attributeValues, _dateFormat, _dateTimeFormat);
                switch (attributeType.DataType)
                {
                    case XmlDataType.Type.Date:
                        thisAttribute = new DateTimeAttribute(attributeName, _dateFormat);
                        break;
                    case XmlDataType.Type.DateTime:
                        thisAttribute = new DateTimeAttribute(attributeName, _dateTimeFormat);
                        break;
                    case XmlDataType.Type.Bool:
                        thisAttribute = new BoolAttribute(attributeName, "True", "False");
                        break;
                    case XmlDataType.Type.@bool:
                        thisAttribute = new BoolAttribute(attributeName, "true", "false");
                        break;
                    case XmlDataType.Type.@int:
                        thisAttribute = new IntAttribute(attributeName);
                        break;
                    case XmlDataType.Type.@decimal:
                        thisAttribute = new DecimalAttribute(attributeName);
                        break;
                    case XmlDataType.Type.@string:
                        thisAttribute = new StringAttribute(attributeName);
                        break;
                    default:
                        thisAttribute = new Attribute(attributeName);
                        break;
                }
                thisAttribute.Type = attributeType;

                returnElement.Attributes.Add(thisAttribute);
            }

            return returnElement;
        }

        private void ConsolidateElements(Element newElement, Element currentElement)
        {
            // compare current element elements with new element elements and add unique missing to new element
            foreach (var cElement in currentElement.Elements)
            {
                var tempElement = newElement.Elements.FirstOrDefault(e => e.Name == cElement.Name);

                if (tempElement == null) // element missing, add it
                {
                    var elementName = cElement.XmlName;
                    switch (cElement.Type.DataType)
                    {
                        case XmlDataType.Type.Date:
                            tempElement = new DateTimeElement(elementName, _dateFormat);
                            break;
                        case XmlDataType.Type.DateTime:
                            tempElement = new DateTimeElement(elementName, _dateTimeFormat);
                            break;
                        case XmlDataType.Type.Bool:
                            tempElement = new BoolElement(elementName, "True", "False");
                            break;
                        case XmlDataType.Type.@bool:
                            tempElement = new BoolElement(elementName, "true", "false");
                            break;
                        case XmlDataType.Type.@int:
                            tempElement = new IntElement(elementName);
                            break;
                        case XmlDataType.Type.@decimal:
                            tempElement = new DecimalElement(elementName);
                            break;
                        case XmlDataType.Type.@string:
                            tempElement = new StringElement(elementName);
                            break;
                        default:
                            tempElement = new Element(elementName);
                            break;
                    }

                    tempElement.IsEnumerable = cElement.IsEnumerable;
                    tempElement.Type = cElement.Type;
                    tempElement.OriginalElement = cElement.OriginalElement;
                    tempElement.NamespaceAttributes = cElement.NamespaceAttributes;

                    newElement.Elements.Add(tempElement);
                }

                foreach (var attribute in cElement.Attributes)
                {
                    // Check Attribute Exists
                    if (tempElement.Attributes.Any(a => a.Name == attribute.Name))
                        continue;

                    var sameAttributes = cElement.Attributes.Where(a => a.Name == attribute.Name).ToList();
                    var dataType = sameAttributes.Aggregate<Attribute, XmlDataType>(null, (current, sameAttribute) => current == null ? sameAttribute.Type : XmlDataType.GetBestType(current, sameAttribute.Type));
                    attribute.Type = dataType;
                    tempElement.Attributes.Add(attribute);
                }

                ConsolidateElements(tempElement, cElement);
            }
        }

        private void RenameConflictingClasses(Element element)
        {
            var allElements = GetAllElements(element);

#if USE_LEGACY_CLASS_CONFLICT_POLICY
            int groups = 0;
            foreach (var element1 in allElements)
            {
                var elementsWithThisName = allElements.Where(e => e.Name == element1.Name).ToList();

                if (elementsWithThisName.Count > 1)
                {
                    System.Diagnostics.Debug.WriteLine("Found dupe: {0} [{1}]", element1.Name, elementsWithThisName.Count);
                    groups++;
                }

                var count = 1;
                while (elementsWithThisName.Count > 1)
                {
                    foreach (var element2 in elementsWithThisName)
                    {
                        element2.Name = GetParentsAsString(element2.OriginalElement, count);
                        System.Diagnostics.Debug.WriteLine("Renamed dupe: {0}=>{1}", element1.Name, element2.Name);
                    }
                    elementsWithThisName = allElements.Where(e => e.Name == element1.Name).ToList();
                    count++;
                }
            }
#else
            var dupes = allElements.GroupBy((elem) => elem.Name).Where((group) => group.Count() > 1).ToList();

            foreach (var dupeGroup in dupes)
            {
                // Note: generate a 'key' comprising all the info about the element as the sum of its parts
                var dupeXmls = dupeGroup.Select((d) => Tuple.Create(d,
                    d.ParentToString() +
                    String.Join(" + ", from elem in d.Elements
                                       orderby elem.Name
                                       select elem.ToString()) +
                    String.Join(" - ", from attr in d.Attributes
                                       orderby attr.Name
                                       select attr.ToString())));

                var uniqueXmls = dupeXmls.GroupBy(d => d.Item2).ToList();

                Console.WriteLine("Found dupe set: {0} [{1}] with {2} unique XML", dupeGroup.Key, dupeGroup.Count(), uniqueXmls.Count);

                // Do not rename if all same XML => will overwrite Count-1 times the output CS file, don't care
                if (uniqueXmls.Count == 1)
                {
                    continue;
                }

                // Generate unique numbered names
                int add = 1;
                foreach (var unique in uniqueXmls)
                {
                    foreach (var elem in unique)
                    {
                        elem.Item1.Name = elem.Item1.Name + add;
                    }
                    add++;
                }
            }
#endif
        }

        private List<Element> GetAllElements(Element element)
        {
            var elementList = new List<Element>();
            elementList.AddRange(element.Elements);
            foreach (var el in element.Elements)
                elementList.AddRange(GetAllElements(el));
            return elementList;
        }

        private string GetParentsAsString(XElement element, int depth)
        {
            if (depth == 0)
                return element.Name.LocalName;

            if (element.Parent != null)
                return GetParentsAsString(element.Parent, depth - 1) + _helper.ToPascalCase(element.Name.LocalName);
            return element.Name.LocalName;
        }

        private void ConvertToFiles(Element element)
        {
            var classCode = _classTemplate;

            classCode = classCode.Replace("##NAMESPACE##", _namespace);

            var className = element.Name;
            classCode = classCode.Replace("##ELEMENTNAME##", className);

            var nameSpaceCode = new List<string>();
            if (element.IsRoot && !String.Equals(element.Name, element.XmlName))
                nameSpaceCode.Add(string.Format("[XmlRoot(\"{0}\")]", element.XmlName));

            foreach (var namespaceAttribute in element.NamespaceAttributes.Where(el => string.IsNullOrWhiteSpace(el.Name.NamespaceName)))
            {
                nameSpaceCode.Add(string.Format("[XmlTypeAttribute(AnonymousType = true, Namespace = \"{0}\")]", namespaceAttribute.Value));
            }
            classCode = classCode.Replace("##ELEMENTNAMESPACE##", string.Join(Environment.NewLine, nameSpaceCode));

            var attributesCode = from attr in element.Attributes
                                 select attr.ToString();

            // TODO: this causes an empty line when no attribute is added
            classCode = classCode.Replace("##ATTRIBUTES##", attributesCode.Any() ? String.Join(Environment.NewLine, attributesCode) : String.Empty);

            var elementsCode = new List<string>();
            foreach (var elem in element.Elements)
                elementsCode.Add(elem.ParentToString());

            //element.Elements.Aggregate("", (current, elem) => current + (elem + Environment.NewLine));
            if (!elementsCode.Any())
                elementsCode.Add(element.ToString());

            classCode = classCode.Replace("##ELEMENTS##", elementsCode.Any() ? String.Join(Environment.NewLine, elementsCode) : String.Empty);

            using (var classFile = new StreamWriter(Path.Combine(_outputFolder, className + ".cs"), false))
            {
                classFile.Write(Format.Code(classCode));
            }

            foreach (var el in element.Elements)
            {
                ConvertToFiles(el);
            }
        }
    }
}