using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ReportToExcelParser.Models.Gen2022;
using ReportToExcelParser.Methods;
namespace EoLTester
{
    public partial class Form1 : Form
    {
        public List<string> Tests;
        public int Index;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "XML Files (*.xml)|*.xml";
            oFD.InitialDirectory = "C:\\";
            DialogResult result = oFD.ShowDialog();

            if (result != DialogResult.OK)
                return;
            try
            {
                var file = Unwrapper.UnWrapSync<TestResultsCollection>(oFD.FileName);
                var output = TestXML(file);
                lbFileName.Text = oFD.SafeFileName;
                if (output.result)
                {
                    MessageBox.Show("Soubor je v pořádku");
                    return;
                }

                MessageBox.Show($"Bylo nalezeno {output.tests.Count} Failed Testů");

                List<string> errors = new List<string>();
                foreach (var item in output.tests)
                    errors.Add(GetMessage(item));
                Index = 0;
                Tests = errors;
                updateText();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error :c");
                tbResults.Text = err.Message;
            }
        }
        static string GetMessage(Test item)
        {
            var x = item.TestResult.FirstOrDefault();
            var type = x.TestData.Datum.Type;
            switch (type)
            {
                case "ts:TS_double":
                    return @$"Test: {item.Name}
Result: {item.Outcome.Value}
Value: {(x.TestData.Datum as Datum_TS_double).Value}
Type: {(x.TestData.Datum as Datum_TS_double).NonStandardUnit}
Limit1: {(x.TestLimits.Limits.LimitPair.Limit[0].Datum as Datum_TS_double).Value}
Limit2: {(x.TestLimits.Limits.LimitPair.Limit[1].Datum as Datum_TS_double).Value}";
                case "ts:TS_boolean":
                    return @$"Test: {item.Name}
Result: {item.Outcome.Value}
Value: {(x.TestData.Datum as Datum_TS_boolean).Value}";
                case "ts:TS_string":
                    return @$"Test: {item.Name}
Result: {item.Outcome.Value}
Value: {(x.TestData.Datum as Datum_TS_String).Value}";
                default:
                    return @$"Test: {item.Name}
Result: {item.Outcome.Value}
Type: {type}";
            }
        }
        static (bool result, List<Test>? tests) TestXML(TestResultsCollection tRC)
        {
            var IsOkay = tRC.Extension.TSBatchTable.uUTHref.TrueForAll(x =>
            {
                return x.uutResult == "Passed";
            });

            if (IsOkay)
                return (true, null);
            var x = GetTests(tRC, GetErrors(tRC));

            return (false, x);
        }

        static List<int> GetErrors(TestResultsCollection tRC)
        {
            var indexes = tRC.Extension.TSBatchTable.uUTHref.Select((value, index) => new { value, index })
                    .Where(x => x.value.uutResult == "Failed")
                    .Select(x => x.index)
                    .ToList();
            return indexes;
        }
        private static List<Test> GetTests(TestResultsCollection tRC, List<int> indexes)
        {
            List<Test> tests = new();
            indexes.ForEach(index =>
            {
                tests = tRC.TestResults[index].ResultSet.TestGroup.FirstOrDefault().Test.FindAll(y =>
                {
                    return y.Outcome.Value == "Failed";
                });
            });
            return tests;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Tests.Count == 0)
                return;
            if (Index == Tests.Count - 1)
                Index = 0;
            else
                Index++;
            updateText();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (Tests.Count == 0)
                return;
            if (Index == 0)
                Index = Tests.Count - 1;
            else
                Index--;
            updateText();
        }
        private void updateText()
        {
            lbIndex.Text = $"{Index+1}/{Tests.Count}";
            tbResults.Text = Tests[Index];
        }
    }
}
