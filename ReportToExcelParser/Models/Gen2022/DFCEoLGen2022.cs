using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ReportToExcelParser.Models.Gen2022
{
    [XmlRoot(ElementName = "TestResultsCollection", Namespace = "urn:IEEE-1636.1:2013:TestResultsCollection")]
    public class TestResultsCollection
    {
        [XmlElement(ElementName = "TestResults", Namespace = "urn:IEEE-1636.1:2013:TestResultsCollection")]
        public List<TestResults> TestResults { get; set; }
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResultsCollection")]
        public ExtensionHeader Extension { get; set; }

        [XmlAttribute(AttributeName = "trc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Trc { get; set; }
        [XmlAttribute(AttributeName = "tr", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tr { get; set; }
        [XmlAttribute(AttributeName = "c", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string C { get; set; }
        [XmlAttribute(AttributeName = "sc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Sc { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "ts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ts { get; set; }
    }

    [XmlRoot(ElementName = "TestResults", Namespace = "urn:IEEE-1636.1:2013:TestResultsCollection")]
    public class TestResults
    {
        [XmlElement(ElementName = "Personnel", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Personnel Personnel { get; set; }
        [XmlElement(ElementName = "ResultSet", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public ResultSet ResultSet { get; set; }
        [XmlElement(ElementName = "TestProgram", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public TestProgram TestProgram { get; set; }
        [XmlElement(ElementName = "TestStation", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public TestStation TestStation { get; set; }
        [XmlElement(ElementName = "UUT", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public UUT UUT { get; set; }
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
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

    [XmlRoot(ElementName = "Personnel", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Personnel
    {
        [XmlElement(ElementName = "SystemOperator", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public SystemOperator SystemOperator { get; set; }
    }

    [XmlRoot(ElementName = "SystemOperator", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class SystemOperator
    {
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }


    [XmlRoot(ElementName = "BlockLevel", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class BlockLevel
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Index", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Index
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TotalTime", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class TotalTime
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ModuleTime", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class ModuleTime
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TSStepProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class TSStepProperties
    {
        [XmlElement(ElementName = "StepType", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public string StepType { get; set; }
        [XmlElement(ElementName = "StepGroup", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public string StepGroup { get; set; }
        [XmlElement(ElementName = "BlockLevel", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public BlockLevel BlockLevel { get; set; }
        [XmlElement(ElementName = "Index", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public Index Index { get; set; }
        [XmlElement(ElementName = "TotalTime", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public TotalTime TotalTime { get; set; }
        [XmlElement(ElementName = "ModuleTime", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public ModuleTime ModuleTime { get; set; }
    }


    [XmlRoot(ElementName = "Outcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Outcome
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "qualifier")]
        public string Qualifier { get; set; }
    }

    [XmlRoot(ElementName = "ActionOutcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class ActionOutcome
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "SessionAction", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class SessionAction
    {
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Extension Extension { get; set; }
        [XmlElement(ElementName = "ActionOutcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public ActionOutcome ActionOutcome { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "startDateTime")]
        public string StartDateTime { get; set; }
        [XmlAttribute(AttributeName = "endDateTime")]
        public string EndDateTime { get; set; }
        [XmlAttribute(AttributeName = "testReferenceID")]
        public string TestReferenceID { get; set; }
        [XmlElement(ElementName = "Data", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Data Data { get; set; }
        [XmlElement(ElementName = "Parameters", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Parameters Parameters { get; set; }
    }

    //[XmlRoot(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
    //[XmlType(TypeName = "TS_double",Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]

    //public class Datum
    //{
    //    [XmlAttribute(AttributeName = "value")]
    //    public string value { get; set; }

    //    [XmlElement(ElementName = "Value", Namespace = "urn:IEEE-1671:2010:Common")]
    //    public string Value { get; set; }

    //    [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    //    public string Type { get; set; }

    //    [XmlAttribute(AttributeName = "flags")]
    //    public string Flags { get; set; }

    //    [XmlAttribute(AttributeName = "nonStandardUnit")]
    //    public string NonStandardUnit { get; set; }

    //    [XmlElement(ElementName = "EnumValue", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    //    public string EnumValue { get; set; }

    //    [XmlElement(ElementName = "NumericValue", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    //    public NumericValue NumericValue { get; set; }

    //    [XmlElement(ElementName = "IsValid", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    //    public IsValid IsValid { get; set; }
    //}

    #region Datum 

    [XmlRoot("Datum", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("Datum", Namespace = "urn:IEEE-1671:2010:Common"),
        XmlInclude(typeof(Datum_TS_double)),
        XmlInclude(typeof(Datum_TS_String)), 
        XmlInclude(typeof(Datum_TS_enum)),
        XmlInclude(typeof(Datum_TS_uLong)),
        XmlInclude(typeof(Datum_TS_boolean)),
        XmlInclude(typeof(Datum_NI_HyperlinkPath))]
    public abstract partial class Datum
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public abstract string Type { get; set; }
    }

    [XmlRoot("Datum-TS_double", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_double", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_TS_double : Datum
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "nonStandardUnit")]
        public string NonStandardUnit { get; set; }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    [XmlRoot("Datum-TS_unsignedLong", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_unsignedLong", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_TS_uLong : Datum
    {
        [XmlAttribute(AttributeName = "value")]
        public string value { get; set; }

        [XmlAttribute(AttributeName = "nonStandardUnit")]
        public string NonStandardUnit { get; set; }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    [XmlRoot("Datum-TS_String", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_string", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_TS_String : Datum
    {
        [XmlElement(ElementName = "Value", Namespace = "urn:IEEE-1671:2010:Common")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }

        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    [XmlRoot("Datum-TS_Boolean", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_boolean", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_TS_boolean : Datum
    {
        private bool _value;

        [XmlElement(ElementName = "Value", Namespace = "urn:IEEE-1671:2010:Common")]
        public string Value { get => _value.ToString(); set => _value = Convert.ToBoolean(value); }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }

        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }

    [XmlRoot("Datum-TS_enum", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_enum", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_TS_enum : Datum
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }

        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }

        [XmlElement(ElementName = "EnumValue", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public string EnumValue { get; set; }

        [XmlElement(ElementName = "NumericValue", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public Limit2 NumericValue { get; set; }

        [XmlElement(ElementName = "IsValid", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public IsValid IsValid { get; set; }
    }

    [XmlRoot("Datum-TS_enum", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("NI_HyperlinkPath", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Datum_NI_HyperlinkPath : Datum
    {
        [XmlElement(ElementName = "Value", Namespace = "urn:IEEE-1671:2010:Common")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }

        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    #endregion

    [XmlRoot(ElementName = "TestData", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestData
    {
        [XmlElement(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
        public Datum Datum { get; set; }
        [XmlElement(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
        public Collection Collection { get; set; }
        [XmlElement(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
        public IndexedArray IndexedArray { get; set; }
    }

    [XmlRoot(ElementName = "Limit", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Limit
    {
        [XmlElement(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
        public Datum Datum { get; set; }
        [XmlAttribute(AttributeName = "comparator")]
        public string Comparator { get; set; }
    }

    [XmlRoot(ElementName = "LimitPair", Namespace = "urn:IEEE-1671:2010:Common")]
    public class LimitPair
    {
        [XmlElement(ElementName = "Limit", Namespace = "urn:IEEE-1671:2010:Common")]
        public List<Limit> Limit { get; set; }
        [XmlAttribute(AttributeName = "operator")]
        public string Operator { get; set; }
    }

    [XmlType(Namespace = "urn:IEEE-1671:2010:Common", TypeName = "double")]
    [XmlRoot(Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Limit2 
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "RawLimits", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class RawLimits
    {
        [XmlElement(ElementName = "Low", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public Limit2 Low { get; set; }
        [XmlElement(ElementName = "High", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public Limit2 High { get; set; }
    }

    [XmlRoot(ElementName = "TSLimitProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class TSLimitProperties
    {
        [XmlElement(ElementName = "RawLimits", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public RawLimits RawLimits { get; set; }
        [XmlElement(ElementName = "ThresholdType", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public string ThresholdType { get; set; }
    }

    [XmlRoot(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Extension
    {
        [XmlElement(ElementName = "TSStepProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public TSStepProperties TSStepProperties { get; set; }
        [XmlElement(ElementName = "TSResultSetProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public TSResultSetProperties TSResultSetProperties { get; set; }
    }

    [XmlRoot(ElementName = "Extension", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Extension2
    {
        [XmlElement(ElementName = "TSLimitProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public TSLimitProperties TSLimitProperties { get; set; }
    }

    [XmlRoot(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResultsCollection")]
    public class ExtensionHeader
    {
        [XmlElement(ElementName = "TSBatchTable", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public TSBatchTable TSBatchTable { get; set; }
    }
    [XmlRoot(ElementName = "TSBatchTable", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class TSBatchTable
    {
        [XmlElement("ReportOptions")]
        public ReportOptions reportOptions { get; set; }
        [XmlElement("UUTHref")]
        public List<UUTHref> uUTHref { get; set; }
    }
    [XmlRoot(ElementName = "ReportOptions")]
    public class ReportOptions
    {
        [XmlElement(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
        public Collection collection { get; set; }
    }
    [XmlRoot("UUTHref")]
    public class UUTHref
    {
        [XmlAttribute(AttributeName = "name")]
        public string socketIndex { get; set; }

        [XmlAttribute(AttributeName = "uutResult")]
        public string uutResult { get; set; }

        [XmlAttribute(AttributeName = "uutURI")]
        public string uutURI { get; set; }

        [XmlAttribute(AttributeName = "uutFileName")]
        public string uutFileName { get; set; }

        [XmlAttribute(AttributeName = "anchorName")]
        public string anchorName { get; set; }

        [XmlAttribute(AttributeName = "linkName")]
        public string linkName { get; set; }
    }



    [XmlRoot(ElementName = "Limits", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Limits
    {
        [XmlElement(ElementName = "LimitPair", Namespace = "urn:IEEE-1671:2010:Common")]
        public LimitPair LimitPair { get; set; }
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1671:2010:Common")]
        public Extension2 Extension2 { get; set; }
        [XmlElement(ElementName = "Expected", Namespace = "urn:IEEE-1671:2010:Common")]
        public Expected Expected { get; set; }
    }

    [XmlRoot(ElementName = "TestLimits", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestLimits
    {
        [XmlElement(ElementName = "Limits", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Limits Limits { get; set; }
    }

    [XmlRoot(ElementName = "TestResult", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestResult
    {
        [XmlElement(ElementName = "TestData", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public TestData TestData { get; set; }
        [XmlElement(ElementName = "TestLimits", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public TestLimits TestLimits { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Test", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Test
    {
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Extension Extension { get; set; }
        [XmlElement(ElementName = "Outcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Outcome Outcome { get; set; }
        [XmlElement(ElementName = "TestResult", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<TestResult> TestResult { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "startDateTime")]
        public string StartDateTime { get; set; }
        [XmlAttribute(AttributeName = "endDateTime")]
        public string EndDateTime { get; set; }
        [XmlAttribute(AttributeName = "testReferenceID")]
        public string TestReferenceID { get; set; }
        [XmlElement(ElementName = "Parameters", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Parameters Parameters { get; set; }
    }

    [XmlRoot(ElementName = "Item", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Item
    {
        [XmlElement(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
        public Datum Datum { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
        public Collection Collection { get; set; }
        [XmlElement(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
        public IndexedArray IndexedArray { get; set; }
    }

    [XmlRoot(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_Collection", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Collection
    {
        [XmlElement(ElementName = "Item", Namespace = "urn:IEEE-1671:2010:Common")]
        public List<Item> Item { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }

    [XmlRoot(ElementName = "Data", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Data
    {
        [XmlElement(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
        public Collection Collection { get; set; }
        [XmlElement(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
        public Datum Datum { get; set; }
        [XmlElement(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
        public IndexedArray IndexedArray { get; set; }
    }

    [XmlRoot(ElementName = "Parameter", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Parameter
    {
        [XmlElement(ElementName = "Data", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Data Data { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Parameters", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Parameters
    {
        [XmlElement(ElementName = "Parameter", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<Parameter> Parameter { get; set; }
    }


    [XmlRoot(ElementName = "Expected", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Expected
    {
        [XmlElement(ElementName = "Datum", Namespace = "urn:IEEE-1671:2010:Common")]
        public Datum Datum { get; set; }
        [XmlAttribute(AttributeName = "comparator")]
        public string Comparator { get; set; }
    }

    [XmlRoot(ElementName = "TestGroup", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestGroup
    {
        [XmlElement(ElementName = "Parameters", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Parameters Parameters { get; set; }
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Extension Extension { get; set; }
        [XmlElement(ElementName = "Outcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Outcome Outcome { get; set; }
        [XmlElement(ElementName = "SessionAction", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<SessionAction> SessionAction { get; set; }
        [XmlElement(ElementName = "Test", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<Test> Test { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "callerName")]
        public string CallerName { get; set; }
        [XmlAttribute(AttributeName = "testReferenceID")]
        public string TestReferenceID { get; set; }
        [XmlAttribute(AttributeName = "startDateTime")]
        public string StartDateTime { get; set; }
        [XmlAttribute(AttributeName = "endDateTime")]
        public string EndDateTime { get; set; }
        [XmlElement(ElementName = "TestResult", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<TestResult> TestResult { get; set; }
        [XmlElement(ElementName = "TestGroup", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<TestGroup> testGroup { get; set; }
    }

    [XmlRoot(ElementName = "NumericValue", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    [XmlType("double",Namespace = "urn:IEEE-1671:2010:Common")]
    public class NumericValue
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "IsValid", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    [XmlType(Namespace = "urn:IEEE-1671:2010:Common", TypeName = "boolean")]
    public class IsValid
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Element", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class Element
    {
        [XmlAttribute(AttributeName = "position")]
        public string Position { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string _Value { get; set; }
        [XmlElement(ElementName = "Value", Namespace = "urn:IEEE-1671:2010:Common")]
        public string Value { get; set; }
    }
    #region IndexedArray

    [XmlRoot(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("IndexedArray", Namespace = "urn:IEEE-1671:2010:Common"),
        XmlInclude(typeof(IndexedArray_TSDouble)),
        XmlInclude(typeof(IndexedArray_TS_hex)),
        XmlInclude(typeof(IndexedArray_TS_string))]
    public abstract partial class IndexedArray {

    }

    [XmlRoot(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_doubleArray",Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class IndexedArray_TSDouble : IndexedArray
    {
        [XmlElement(ElementName = "Element", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public List<Element> Element { get; set; }
        [XmlAttribute(AttributeName = "dimensions")]
        public string Dimensions { get; set; }
        [XmlAttribute(AttributeName = "lowerBounds")]
        public string LowerBounds { get; set; }
        [XmlAttribute(AttributeName = "upperBounds")]
        public string UpperBounds { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }

    [XmlRoot(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_hexadecimalArray", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class IndexedArray_TS_hex : IndexedArray
    {
        [XmlElement(ElementName = "Element", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public List<Element> Element { get; set; }
        [XmlAttribute(AttributeName = "dimensions")]
        public string Dimensions { get; set; }
        [XmlAttribute(AttributeName = "lowerBounds")]
        public string LowerBounds { get; set; }
        [XmlAttribute(AttributeName = "upperBounds")]
        public string UpperBounds { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    [XmlRoot(ElementName = "IndexedArray", Namespace = "urn:IEEE-1671:2010:Common")]
    [XmlType("TS_stringArray", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class IndexedArray_TS_string : IndexedArray
    {
        [XmlElement(ElementName = "Element", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public List<Element> Element { get; set; }
        [XmlAttribute(AttributeName = "dimensions")]
        public string Dimensions { get; set; }
        [XmlAttribute(AttributeName = "lowerBounds")]
        public string LowerBounds { get; set; }
        [XmlAttribute(AttributeName = "upperBounds")]
        public string UpperBounds { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "flags")]
        public string Flags { get; set; }
    }
    #endregion
    
    [XmlRoot(ElementName = "ResultSet", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class ResultSet
    {
        [XmlElement(ElementName = "Extension", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Extension Extension { get; set; }
        [XmlElement(ElementName = "Outcome", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Outcome Outcome { get; set; }
        [XmlElement(ElementName = "SessionAction", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<SessionAction> SessionAction { get; set; }
        [XmlElement(ElementName = "Test", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<Test> Test { get; set; }
        [XmlElement(ElementName = "TestGroup", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public List<TestGroup> TestGroup { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "startDateTime")]
        public string StartDateTime { get; set; }
        [XmlAttribute(AttributeName = "endDateTime")]
        public string EndDateTime { get; set; }
    }

    [XmlRoot(ElementName = "Configuration", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class Configuration
    {
        [XmlElement(ElementName = "Collection", Namespace = "urn:IEEE-1671:2010:Common")]
        public Collection Collection { get; set; }
    }

    [XmlRoot(ElementName = "TestProgram", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestProgram
    {
        [XmlElement(ElementName = "SerialNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public string SerialNumber { get; set; }
        [XmlElement(ElementName = "Configuration", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
        public Configuration Configuration { get; set; }
    }

    [XmlRoot(ElementName = "TestStation", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class TestStation
    {
        [XmlElement(ElementName = "SerialNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public string SerialNumber { get; set; }
    }

    [XmlRoot(ElementName = "IdentificationNumber", Namespace = "urn:IEEE-1671:2010:Common")]
    public class IdentificationNumber
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "qualifier")]
        public string Qualifier { get; set; }
    }

    [XmlRoot(ElementName = "IdentificationNumbers", Namespace = "urn:IEEE-1671:2010:Common")]
    public class IdentificationNumbers
    {
        [XmlElement(ElementName = "IdentificationNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public IdentificationNumber IdentificationNumber { get; set; }
    }

    [XmlRoot(ElementName = "Identification", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Identification
    {
        [XmlElement(ElementName = "ModelName", Namespace = "urn:IEEE-1671:2010:Common")]
        public string ModelName { get; set; }
        [XmlElement(ElementName = "IdentificationNumbers", Namespace = "urn:IEEE-1671:2010:Common")]
        public IdentificationNumbers IdentificationNumbers { get; set; }
    }

    [XmlRoot(ElementName = "Definition", Namespace = "urn:IEEE-1671:2010:Common")]
    public class Definition
    {
        [XmlElement(ElementName = "Identification", Namespace = "urn:IEEE-1671:2010:Common")]
        public Identification Identification { get; set; }
    }

    [XmlRoot(ElementName = "UUT", Namespace = "urn:IEEE-1636.1:2013:TestResults")]
    public class UUT
    {
        [XmlElement(ElementName = "Definition", Namespace = "urn:IEEE-1671:2010:Common")]
        public Definition Definition { get; set; }
        [XmlElement(ElementName = "SerialNumber", Namespace = "urn:IEEE-1671:2010:Common")]
        public string SerialNumber { get; set; }
    }

    [XmlRoot(ElementName = "NumOfResults", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class NumOfResults
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "TSResultSetProperties", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
    public class TSResultSetProperties
    {
        [XmlElement(ElementName = "NumOfResults", Namespace = "www.ni.com/TestStand/ATMLTestResults/3.0")]
        public NumOfResults NumOfResults { get; set; }
        [XmlElement(Namespace = "TestSocketIndex",ElementName = "TestSocketIndex")]
        public Limit2 TestSocketIndex { get; set; }
    }


}