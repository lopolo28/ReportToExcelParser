using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ReportToExcelParser.Models
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Reports : IEquatable<Reports>
    {
        private Report reportField;

        /// <remarks/>
        [XmlElementAttribute("Report")]
        public Report report
        {
            get => reportField;
            set => reportField = value;
        }

        public bool Equals(Reports other)
        {
            if (report.Equals(other.report))
                return true;
            return false;
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Report : Comparison, IEquatable<Report>
    {
        private Prop[] propField;

        private string typeField;

        private string titleField;

        private string linkField;

        private string uUTResultField;

        private int stepCountField;

        /// <remarks/>
        [XmlElementAttribute("Prop")]
        public Prop[] Prop
        {
            get
            {
                return this.propField;
            }
            set
            {
                this.propField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string UUTResult
        {
            get
            {
                return this.uUTResultField;
            }
            set
            {
                this.uUTResultField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int StepCount
        {
            get
            {
                return this.stepCountField;
            }
            set
            {
                this.stepCountField = value;
            }
        }

        public bool Equals(Report other)
        {
            if (CompareWithNullHandle<string>(Type, other.Type) &&
                CompareWithNullHandle<string>(Title, other.Title) &&
                CompareWithNullHandle<string>(Link, other.Link) &&
                CompareWithNullHandle<string>(UUTResult, other.UUTResult) &&
                CompareWithNullHandle<int>(StepCount, other.StepCount))
            {

                if (Prop != null && other.Prop != null && Prop.Length == other.Prop.Length)
                {
                    for (int i = 0; i < Prop.Length; i++)
                    {
                        if (!Prop[i].Equals(other.Prop[i]))
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Prop : Comparison, IEquatable<Prop>
    {
        private string nameField;

        private string typeField;

        private string flagsField;

        private ArrayElementPrototype arrayElementPrototypefield;

        private string lBoundField;

        private string hBoundField;

        private string elementTypeField;

        private Prop[] propField;

        private Attributes attributesField;

        private string typeNameField;

        private List<Value> valueField;

        /// <remarks/>
        /// 
        [XmlElementAttribute("Attributes")]
        public Attributes Attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("Prop")]
        public Prop[] prop
        {
            get
            {
                return this.propField;
            }
            set
            {
                this.propField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Type
        {
            get => this.typeField;
            set => this.typeField = value;
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string TypeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Flags
        {
            get
            {
                return this.flagsField;
            }
            set
            {
                this.flagsField = value;
            }
        }

        [XmlElementAttribute("ArrayElementPrototype")]
        public ArrayElementPrototype ArrayElementPrototype
        {
            get => arrayElementPrototypefield;
            set => arrayElementPrototypefield = value;
        }
        [XmlAttributeAttribute()]
        public string LBound
        {
            get => this.lBoundField;
            set => this.lBoundField = value;
        }
        [XmlAttributeAttribute()]
        public string HBound
        {
            get => this.hBoundField;
            set => this.hBoundField = value;
        }

        [XmlAttributeAttribute()]
        public string ElementType
        {
            get => this.elementTypeField;
            set => this.elementTypeField = value;
        }

        /// <remarks/>
        [XmlElement("Value")]
        public List<Value> Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                valueField = value;
            }
        }

        public object GetSingleValue(string type, object[] value)
        {
            if (value == null)
                return null;
            XmlNode[] xmlNode = value[0] as XmlNode[];
            if (xmlNode == null)
                return null;
            switch (type)
            {
                case "Boolean":
                    return Convert.ChangeType(xmlNode[0].Value, typeof(Boolean));
                case "String":
                    return Convert.ChangeType(xmlNode[0].Value, typeof(String));
                case "Number":
                    return Convert.ChangeType(xmlNode[0].Value.ToString().Replace('.', ','), typeof(double));
                default:
                    throw new Exception("Unknown Type");
            }
        }
        public object[] GetArray(string element, object[] value)
        {
            if (value == null)
                return null;
            List<object> xmlNodes = new List<object>();

            foreach (XmlNode[] item in value)
            {
                if (item.Length == 1)
                    continue;
                //try
                {
                    switch (element)
                    {
                        case "Boolean":
                            xmlNodes.Add(Convert.ChangeType(item[1].Value, typeof(Boolean)));
                            break;
                        case "String":
                            xmlNodes.Add(Convert.ChangeType(item[1].Value, typeof(String)));
                            break;
                        case "Number":
                            xmlNodes.Add(Convert.ChangeType(item[1].Value.ToString().Replace('.', ','), typeof(double)));
                            break;
                        case "Obj":
                            // TODO: Vyřešit vnitří deserializaci
                            {
                                XmlSerializer ser = new XmlSerializer(typeof(Value));
                                using (TextReader reader = new StringReader(item[1].InnerXml))
                                {
                                    Value newValue = (Value)ser.Deserialize(reader);
                                    xmlNodes.Add(Convert.ChangeType(newValue, typeof(Value)));
                                }
                                break;
                            }
                        default:
                            throw new Exception("Unknown Type");
                    }
                }
                //catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            return xmlNodes.ToArray();
        }
        public bool Equals(Prop other)
        {
            if (CompareWithNullHandle<string>(Name, other.Name) &&
                CompareWithNullHandle<string>(Type, other.Type) &&
                CompareWithNullHandle<string>(Flags, other.Flags) &&
                CompareWithNullHandle<string>(LBound, other.LBound) &&
                CompareWithNullHandle<string>(HBound, other.HBound) &&
                CompareWithNullHandle<string>(ElementType, other.ElementType) &&
                CompareWithNullHandle<string>(TypeName, other.TypeName) &&
                CompareWithNullHandle<Attributes>(Attributes, other.Attributes) &&
                CompareWithNullHandle<ArrayElementPrototype>(ArrayElementPrototype, other.ArrayElementPrototype))
            {
                if (Value != null && other.Value != null && Value.Count == other.Value.Count)
                {
                    for (int i = 0; i < Value.Count; i++)
                    {
                        if (!Value[i].Equals(other.Value[i]))
                            return false;
                    }
                }

                if (prop != null && other.prop != null && prop.Length == other.prop.Length)
                {
                    for (int i = 0; i < prop.Length; i++)
                    {
                        if (!prop[i].Equals(other.prop[i]))
                            return false;
                    }
                }

                return true;
            }
            return false;
        }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Attributes : IEquatable<Attributes>
    {
        private Prop propField;
        [XmlElementAttribute("Prop")]
        public Prop prop
        {
            get => propField;
            set => propField = value;
        }

        public bool Equals(Attributes other)
        {
            if (prop.Equals(other.prop))
                return true;
            return false;
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class ArrayElementPrototype : Comparison, IEquatable<ArrayElementPrototype>
    {
        private Prop[] propField;
        private string typeField;
        private string typeNameField;
        private string flagsField;

        [XmlElementAttribute("Prop")]
        public Prop[] prop
        {
            get => propField;
            set => propField = value;
        }

        [XmlAttributeAttribute()]
        public string Type
        {
            get => typeField;
            set => typeField = value;
        }
        [XmlAttributeAttribute()]
        public string TypeName
        {
            get => typeNameField;
            set => typeNameField = value;
        }
        [XmlAttributeAttribute()]
        public string Flags
        {
            get => flagsField;
            set => flagsField = value;
        }

        public bool Equals(ArrayElementPrototype other)
        {
            if (CompareWithNullHandle<string>(Type, other.Type) &&
               CompareWithNullHandle<string>(TypeName, other.TypeName) &&
               CompareWithNullHandle<string>(Flags, other.Flags))
            {
                if (prop != null && other.prop != null && prop.Length == other.prop.Length)
                {
                    for (int i = 0; i < prop.Length; i++)
                    {
                        if (!prop[i].Equals(other.prop[i]))
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Value : Comparison, IEquatable<Value>
    {
        private string iDField;
        private string textField;
        private Prop propField;


        [XmlAttribute("ID")]
        public string ID
        {
            get => iDField;
            set => iDField = value;
        }

        [XmlText]
        public string Text
        {
            get => textField;
            set => textField = value;
        }

        [XmlElementAttribute("Prop")]
        public Prop prop
        {
            get => propField;
            set => propField = value;
        }

        public bool Equals(Value other)
        {
            if (CompareWithNullHandle<string>(ID, other.ID) &&
                CompareWithNullHandle<string>(Text, other.Text) &&
                CompareWithNullHandle<Prop>(prop, other.prop))
                return true;
            return false;
        }
    }
    public class Comparison
    {
        public bool CompareWithNullHandle<T>(T comparable1, T comparable2)
        {
            if (comparable1 == null && comparable2 == null)
                return true;
            else if (comparable1 != null && comparable2 != null)
            {
                bool isEqual;
                if (comparable1.GetType() == typeof(ArrayElementPrototype) && comparable1.GetType() == typeof(ArrayElementPrototype))
                {
                    isEqual = (comparable1 as ArrayElementPrototype).Equals((comparable2 as ArrayElementPrototype));
                }
                else if (comparable1.GetType() == typeof(Attributes) && comparable1.GetType() == typeof(Attributes))
                {
                    isEqual = (comparable1 as Attributes).Equals((comparable2 as Attributes));
                }
                else if (comparable1.GetType() == typeof(Prop) && comparable1.GetType() == typeof(Prop))
                {
                    isEqual = (comparable1 as Prop).Equals((comparable2 as Prop));
                }
                else if (comparable1.GetType() == typeof(Value) && comparable1.GetType() == typeof(Value))
                {
                    isEqual = (comparable1 as Value).Equals((comparable2 as Value));
                }
                else
                {
                    isEqual = comparable1.Equals(comparable2);
                }

                return isEqual;
            }
            return false;
        }
    }
}
