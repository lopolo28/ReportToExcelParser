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
    [XmlRootAttribute(ElementName = "TestResultsCollection",Namespace ="",IsNullable = false)]
    public class TestResultsCollection
    {
        private TestResult testResult;
        [XmlElementAttribute(ElementName = "TestResults")]
        public TestResult TestResult { get => testResult; set => testResult = value; }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(ElementName = "TestResults")]
    public class TestResults
    {
        private Personnel personnel;
        private ResultSet resultSet;
        private TestProgram testProgram;
        private TestStation testStation;
        private Extension extension;
        [XmlElementAttribute()]
        public Personnel Personnel
        {
            get => personnel;
            set => personnel = value;
        }

        [XmlElementAttribute()]
        public ResultSet ResultSet
        {
            get => resultSet;
            set => resultSet = value;
        }

        [XmlElementAttribute()]
        public TestProgram TestProgram
        {
            get => testProgram;
            set => testProgram = value;
        }
        [XmlElementAttribute()]
        public TestStation TestStation
        {
            get => testStation;
            set => testStation = value;
        }
        [XmlElementAttribute()]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }
    }

    #region Personnel
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Personnel
    {
        private SystemOperator systemOperator;
        [XmlAttributeAttribute()]
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
        [XmlAttributeAttribute()]
        public string id
        {
            get => ID;
            set => ID = value;
        }
        [XmlAttributeAttribute()]
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
        private Extension extension;
        private string outcome;
        private SessionAction[] sessionActions;
        private Test[] test;
        private TestGroup[] testGroup;

        [XmlAttributeAttribute()]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }

        [XmlAttributeAttribute()]
        public string Outcome
        {
            get => outcome;
            set => outcome = value;
        }

        [XmlAttributeAttribute()]
        public SessionAction[] SessionActions
        {
            get => sessionActions;
            set => sessionActions = value;
        }

        [XmlAttributeAttribute()]
        public Test[] Test
        {
            get => test;
            set => test = value;
        }
        [XmlAttributeAttribute()]
        public TestGroup[] TestGroup
        {
            get => testGroup;
            set => testGroup = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Extension
    {
        private TSStepProperties? tSStepProperties;
        private TSLimitProperties? tSLimitProperties;

        [XmlAttributeAttribute()]
        public TSStepProperties? TSStepProperties
        {
            get => tSStepProperties;
            set => tSStepProperties = value;
        }

        [XmlAttributeAttribute()]
        public TSLimitProperties? TSLimitProperties
        {
            get => tSLimitProperties;
            set => tSLimitProperties = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TSStepProperties
    {
        private string stepType;
        private string stepGroup;
        private int blockLevel;
        private int index;
        private double totalTime;
        private double moduleTime;

        [XmlAttributeAttribute()]
        public string StepType
        {
            get => stepType;
            set => stepType = value;
        }
        [XmlAttributeAttribute()]
        public string StepGroup
        {
            get => stepGroup;
            set => stepGroup = value;
        }

        [XmlAttributeAttribute()]
        public int BlockLevel
        {
            get => blockLevel;
            set => blockLevel = value;
        }
        [XmlAttributeAttribute()]
        public int Index
        {
            get => index;
            set => index= value;
        }

        [XmlAttributeAttribute()]
        public double TotalTime
        {
            get => totalTime;
            set => totalTime = value;
        }
        [XmlAttributeAttribute()]
        public double ModuleTime
        {
            get => moduleTime;
            set => moduleTime = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class SessionAction
    {
        private Extension extension;

        [XmlAttributeAttribute()]
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

        [XmlAttributeAttribute()]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }

        [XmlAttributeAttribute()]
        public string Outcome
        {
            get => outcome;
            set => outcome = value;
        }

        [XmlAttributeAttribute()]
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

        [XmlAttributeAttribute()]
        public TestData TestData
        {
            get => testData;
            set => testData = value;
        }

        [XmlAttributeAttribute()]
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
        private double datum;

        [XmlAttributeAttribute()]
        public double Datum
        {
            get => datum;
            set => datum = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestLimits
    {
        private Limits limits;

        [XmlAttributeAttribute()]
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

        [XmlAttributeAttribute()]
        public LimitPair LimitPair
        {
            get => limitPair;
            set => limitPair = value;
        }

        [XmlAttributeAttribute()]
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
        private Limit limit;
        private Limit limit2;

        [XmlAttributeAttribute()]
        public Limit Limit
        {
            get => limit;
            set => limit = value;
        }

        [XmlAttributeAttribute()]
        public Limit Limit2
        {
            get => limit2;
            set => limit2 = value;
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Limit
    {
        private double datum;

        [XmlAttributeAttribute()]
        public double Datum
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

        [XmlAttributeAttribute()]
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

        [XmlAttributeAttribute()]
        public double Low
        {
            get => low;
            set => low = value;
        }
        [XmlAttributeAttribute()]
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



        [XmlAttributeAttribute()]
        public Parameters Parameters
        {
            get => parameters;
            set => parameters = value;
        }

        [XmlAttributeAttribute()]
        public Extension Extension
        {
            get => extension;
            set => extension = value;
        }
        [XmlAttributeAttribute()]
        public string Outcome
        {
            get => outcome;
            set => outcome = value;
        }
        [XmlAttributeAttribute()]
        public SessionAction[] SessionAction
        {
            get => sessionAction;
            set => sessionAction = value;
        }

        [XmlAttributeAttribute()]
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

        [XmlAttributeAttribute()]
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


        [XmlAttributeAttribute()]
        public string Id
        {
            get => id;
            set => id = value;
        }

        [XmlAttributeAttribute()]
        public string Name
        {
            get => name;
            set => name = value;
        }
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
        [XmlAttributeAttribute()]
        public Collection Collection { get => collection; set => collection = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Collection
    {
        private Item[] items;

        public Item[] Items { get => items; set => items = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Item
    {
        private string name;
        private Datum datum;
        [XmlAttributeAttribute()]
        public string Name { get => name; set => name = value; }
        [XmlAttributeAttribute()]
        public Datum Datum { get => datum; set => datum = value; }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Datum
    {
        private string _value;
        [XmlAttributeAttribute()]
        public string Value
        {
            get => _value;
            set => _value = value;
        }

    }
    #endregion

    #region TestStation

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class TestStation
    {
        private string serialNumber;

        public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }
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
        [XmlElementAttribute()]
        public Definition Definition { get => definition; set => definition = value; }
        [XmlElementAttribute()]
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
    }

    public class Definition
    {
        private Identification identification;
        [XmlElementAttribute()]
        public Identification Identification { get => identification; set => identification = value; }
    }

    public class Identification
    {
        private string model;
        private IdentificationNumbers identificationNumbers;
        [XmlElementAttribute()]
        public string Model { get => model; set => model = value; }
        [XmlElementAttribute()]
        public IdentificationNumbers IdentificationNumbers { get => identificationNumbers; set => identificationNumbers = value; }
    }

    public class IdentificationNumbers
    {
        private IdentificationNumber[] identificationNumber;
        [XmlElementAttribute()]
        public IdentificationNumber[] IdentificationNumber { get => identificationNumber; set => identificationNumber = value; }
    }

    public class IdentificationNumber
    {
        private string number;
        private string qualifier;
    }
    #endregion

}
