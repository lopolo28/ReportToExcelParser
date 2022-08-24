using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReportToExcelParser.Models.Old
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(ElementName = "TestResultsCollection", Namespace = "urn:IEEE-1636.1:2011:01:TestResultsCollection")]
    public class TestResultsCollection
    {
        private TestResults testResults;
        [XmlElementAttribute(ElementName = "TestResults")]
        public TestResults TestResults { get => testResults; set => testResults = value; }


        [XmlAttribute(AttributeName = "trc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Trc { get; set; }
        [XmlAttribute(AttributeName = "tr", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tr { get; set; }
        [XmlAttribute(AttributeName = "c", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string C { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "ts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ts { get; set; }
    }

    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRoot(ElementName = "TestResults", Namespace = "urn:IEEE-1636.1:2011:01:TestResultsCollection")]
    public class TestResults
    {
        [XmlElement(ElementName = "Personnel", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public Personnel Personnel { get; set; }
        [XmlElement(ElementName = "ResultSet", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public ResultSet ResultSet { get; set; }
        [XmlElement(ElementName = "TestProgram", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public TestProgram TestProgram { get; set; }
        [XmlElement(ElementName = "TestStation", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public TestStation TestStation { get; set; }
        [XmlElement(ElementName = "UUT", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public UUT UUT { get; set; }
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public Extension Extension { get; set; }
        [XmlAttribute(AttributeName = "uuid")]
        public string Uuid { get; set; }
        [XmlAttribute(AttributeName = "trc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Trc { get; set; }
        [XmlAttribute(AttributeName = "tr", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tr { get; set; }
        [XmlAttribute(AttributeName = "c", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string C { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "ts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ts { get; set; }
    }

    #region Personnel
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Personnel
    {
        private SystemOperator systemOperator;
        [XmlElementAttribute("SystemOperator")]
        public SystemOperator SystemOperator
        {
            get => systemOperator;
            set => systemOperator = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class SystemOperator
    {
        private string ID;
        private string Name;
        [XmlAttributeAttribute("ID")]
        public string id
        {
            get => ID;
            set => ID = value;
        }
        [XmlAttributeAttribute("name")]
        public string name
        {
            get => Name;
            set => Name = value;
        }
    }
    #endregion

    #region ResultSet
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class ResultSet
    {
        private string id;
        private string name;
        private string startDateTime;
        private string endDateTime;
        private string testReferenceID;
        private Extension extension;
        private Outcome outcome;
        private SessionAction[] sessionActions;
        private Test[] test;
        private TestGroup[] testGroup;

        [XmlElementAttribute("Extention")]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }

        [XmlElementAttribute("Outcome")]
        public Outcome Outcome
        {
            get => outcome;
            set => outcome = value;
        }

        [XmlElementAttribute("SessionAction")]
        public SessionAction[] SessionActions
        {
            get => sessionActions;
            set => sessionActions = value;
        }

        [XmlElementAttribute("Test")]
        public Test[] Test
        {
            get => test;
            set => test = value;
        }
        [XmlElementAttribute("TestGroup")]
        public TestGroup[] TestGroup
        {
            get => testGroup;
            set => testGroup = value;
        }
        [XmlAttributeAttribute("ID")]
        public string ID { get => id; set => id = value; }

        [XmlAttributeAttribute("name")]
        public string Name { get => name; set => name = value; }

        [XmlAttributeAttribute("startDateTime")]
        public string StartDateTime { get => startDateTime; set => startDateTime = value; }

        [XmlAttributeAttribute("endDateTime")]
        public string EndDateTime { get => endDateTime; set => endDateTime = value; }

        [XmlAttributeAttribute("testReferenceID")]
        public string TestReferenceID { get => testReferenceID; set => testReferenceID = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Extension
    {
        private TSStepProperties? tSStepProperties;
        private TSLimitProperties? tSLimitProperties;
        private TSResultSetProperties? tSResultSetProperties;

        [XmlElement(ElementName = "TSStepProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/2.0")]
        public TSStepProperties? TSStepProperties
        {
            get => tSStepProperties;
            set => tSStepProperties = value;
        }

        [XmlElement(ElementName = "TSLimitProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/2.0")]
        public TSLimitProperties? TSLimitProperties
        {
            get => tSLimitProperties;
            set => tSLimitProperties = value;
        }
        [XmlElement(ElementName = "TSResultSetProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/2.0")]
        public TSResultSetProperties? TSResultSetProperties 
        { 
            get => tSResultSetProperties; 
            set => tSResultSetProperties = value; 
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Outcome
    {
        private string value;
        [XmlAttributeAttribute("value")]
        public string Value { get => value; set => this.value = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TSStepProperties
    {
        private string stepType;
        private string stepGroup;
        private string blockLevel;
        private string index;
        private string totalTime;
        private string? moduleTime;

        [XmlElementAttribute("StepType")]
        public string StepType
        {
            get => stepType;
            set => stepType = value;
        }
        [XmlElementAttribute("StepGroup")]
        public string StepGroup
        {
            get => stepGroup;
            set => stepGroup = value;
        }

        [XmlElementAttribute("BlockLevel")]
        public string BlockLevel
        {
            get => blockLevel;
            set => blockLevel = value;
        }
        [XmlElementAttribute("Index")]
        public string Index
        {
            get => index;
            set => index = value;
        }

        [XmlElementAttribute("TotalTime")]
        public string TotalTime
        {
            get => totalTime;
            set => totalTime = value;
        }
        [XmlElementAttribute("ModuleTime")]
        public string? ModuleTime
        {
            get => moduleTime;
            set => moduleTime = value;
        }
    }

    public class TSResultSetProperties
    {
        private NumOfResults numOfResults;
        private TestSocketIndex testSocketIndex;

        [XmlElementAttribute("NumOfResults")]
        public NumOfResults NumOfResults { get => numOfResults; set => numOfResults = value; }

        [XmlElementAttribute("TestSocketIndex")]
        public TestSocketIndex TestSocketIndex { get => testSocketIndex; set => testSocketIndex = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class SessionAction
    {
        private Extension extension;

        [XmlElementAttribute("Extension")]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Test
    {
        private Extension extension;
        private string outcome;
        private TestResult testResult;

        [XmlElementAttribute("Extension")]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }

        [XmlElementAttribute()]
        public string Outcome
        {
            get => outcome;
            set => outcome = value;
        }

        [XmlElementAttribute()]
        public TestResult TestResult
        {
            get => testResult;
            set => testResult = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestResult
    {
        private TestData testData;
        private TestLimits testLimits;

        [XmlElementAttribute("TestData")]
        public TestData TestData
        {
            get => testData;
            set => testData = value;
        }

        [XmlElementAttribute("TestLimits")]
        public TestLimits TestLimits
        {
            get => testLimits;
            set => testLimits = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestData
    {
        private Datum datum;

        [XmlElementAttribute("Datum")]
        public Datum Datum
        {
            get => datum;
            set => datum = value;
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Datum
    {
        private string value;
        [XmlAttributeAttribute("value")]
        public string Value { get => value; set => this.value = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestLimits
    {
        private Limits limits;

        [XmlElementAttribute("Limits")]
        public Limits Limits
        {
            get => limits;
            set => limits = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Limits
    {
        private LimitPair limitPair;
        private Extension extension;

        [XmlElementAttribute("LimitPair")]
        public LimitPair LimitPair
        {
            get => limitPair;
            set => limitPair = value;
        }

        [XmlElementAttribute("Extension")]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class LimitPair
    {
        private string _operator;
        private Limit[] limit;

        [XmlAttributeAttribute("operator")]
        public string Operator
        {
            get => _operator;
            set => _operator = value;
        }
        [XmlElementAttribute("Limit")]
        public Limit[] Limit
        {
            get => limit;
            set => limit = value;
        }

    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Limit
    {
        private string comparator;
        private Datum datum;

        [XmlAttributeAttribute("comparator")]
        public string Comparator
        {
            get => comparator;
            set => comparator = value;
        }
        [XmlElementAttribute()]
        public Datum Datum
        {
            get => datum;
            set => datum = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TSLimitProperties
    {
        private RawLimits rawLimits;

        [XmlElementAttribute("RawLimits")]
        public RawLimits RawLimits
        {
            get => rawLimits;
            set => rawLimits = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class RawLimits
    {
        private double low;
        private double high;

        [XmlElementAttribute("Low")]
        public double Low
        {
            get => low;
            set => low = value;
        }
        [XmlElementAttribute("High")]
        public double High
        {
            get => high;
            set => high = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestGroup
    {
        private Parameters parameters;
        private Extension extension;
        private string outcome;
        private SessionAction[] sessionAction;
        private Test[] test;



        [XmlElementAttribute("Parameters")]
        public Parameters Parameters
        {
            get => parameters;
            set => parameters = value;
        }

        [XmlElementAttribute("Extension")]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }
        [XmlElementAttribute("Outcome")]
        public string Outcome
        {
            get => outcome;
            set => outcome = value;
        }
        [XmlElementAttribute("SessionAction")]
        public SessionAction[] SessionAction
        {
            get => sessionAction;
            set => sessionAction = value;
        }

        [XmlElementAttribute("Test")]
        public Test[] Test
        {
            get => test;
            set => test = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Parameters
    {
        private Parameter[] parameter;

        [XmlElementAttribute("Parameter")]
        public Parameter[] Parameter
        {
            get => parameter;
            set => parameter = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Parameter
    {
        private string id;
        private string name;
        private Data data;

        [XmlAttributeAttribute("ID")]
        public string Id
        {
            get => id;
            set => id = value;
        }

        [XmlAttributeAttribute("name")]
        public string Name
        {
            get => name;
            set => name = value;
        }
        [XmlElementAttribute("Data")]
        public Data Data { get => data; set => data = value; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Data
    {
        private Datum datum;
        [XmlElementAttribute("Datum")]
        public Datum Datum { get => datum; set => datum = value; }
    }
    #endregion

    #region TestProgram
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestProgram
    {
        private string serialNumber;
        private Configuration configuration;

        [XmlAttributeAttribute()]
        public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }
        public Configuration Configuration { get => configuration; set => configuration = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Configuration
    {
        private Collection collection;
        [XmlElementAttribute("Collection")]
        public Collection Collection { get => collection; set => collection = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Collection
    {
        private Item[] items;

        [XmlElementAttribute("Item")]
        public Item[] Items { get => items; set => items = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Item
    {
        private string name;
        private Datum datum;
        [XmlAttributeAttribute("Name")]
        public string Name { get => name; set => name = value; }
        [XmlElementAttribute("Datum")]
        public Datum Datum { get => datum; set => datum = value; }
    }
    #endregion

    #region TestStation

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestStation
    {
        private string serialNumber;
        private Configuration configuration;

        [XmlElement(ElementName = "SerialNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }

        [XmlElement(ElementName = "Configuration", Namespace = "urn:IEEE-1636.1:2011:01:TestResults")]
        public Configuration Configuration { get => configuration; set => configuration = value; }
    }

    #endregion

    #region UUT

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class UUT
    {
        private Definition definition;
        private string serialNumber;
        [XmlElementAttribute("Definition", Namespace = "urn:IEEE-1671:2010:Common")]
        public Definition Definition { get => definition; set => definition = value; }
        [XmlElementAttribute("SerialNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
    }

    public class Definition
    {
        private Identification identification;
        [XmlElementAttribute("Identification")]
        public Identification Identification { get => identification; set => identification = value; }
    }

    public class Identification
    {
        private string modelName;
        private IdentificationNumbers identificationNumbers;
        [XmlElementAttribute("ModelName")]
        public string ModelName { get => modelName; set => modelName = value; }
        [XmlElementAttribute("IdentificationNumbers")]
        public IdentificationNumbers IdentificationNumbers { get => identificationNumbers; set => identificationNumbers = value; }
    }

    public class IdentificationNumbers
    {
        private IdentificationNumber[] identificationNumber;
        [XmlElementAttribute("IdentificationNumber")]
        public IdentificationNumber[] IdentificationNumber { get => identificationNumber; set => identificationNumber = value; }
    }

    public class IdentificationNumber
    {
        private string number;
        private string qualifier;
        private string type;

        [XmlAttributeAttribute("number")]
        public string Number { get => number; set => number = value; }

        [XmlAttributeAttribute("qualifier")]
        public string Qualifier { get => qualifier; set => qualifier = value; }

        [XmlAttributeAttribute("type")]
        public string Type { get => type; set => type = value; }
    }
    #endregion
    
    #region Others
    [XmlRoot(ElementName = "NumOfResults", Namespace = "www.ni.com/TestStand/ATMLTestResults/2.0")]
    public class NumOfResults
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TestSocketIndex", Namespace = "www.ni.com/TestStand/ATMLTestResults/2.0")]
    [XmlTypeAttribute(Namespace = "urn:IEEE-1671:2010:Common", TypeName = "double")]
    public class TestSocketIndex
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }
    #endregion
}
