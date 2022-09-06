using System;
using System.Collections.Generic;
using System.Linq;
using ReportToExcelParser.Methods;
using ReportToExcelParser.Models.Gen2022;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string path = @"input\Report_EoLT_FC[EB03240FFFF1122223001070][1][11.08.2022][09 56 36].xml";
            const string OKpath = @"input\ScrTest_MainTest_FC[E872358][7 12 2022][11 58 02 AM].xml";
            const string NOKpath = @"input\ScrTest_MainTest_FC[EB03321][8 22 2022][6 37 36 AM].xml";

            TestResultsCollection testResultsCollection =
                Unwrapper.UnWrapSync<TestResultsCollection>(OKpath);
            TestResultsCollection testResultsCollectionNOK =
    Unwrapper.UnWrapSync<TestResultsCollection>(NOKpath);

            var passed = TestXML(testResultsCollectionNOK);

            if(passed.result == true)
            {
                Console.WriteLine("Soubor je v pořádku");
            }
            else
            {
                Console.WriteLine("Soubor není v pořádku");
                Console.ReadLine();
            }

        }

        static (bool result,List<Test>? tests) TestXML(TestResultsCollection tRC)
        {
            var IsOkay =  tRC.Extension.TSBatchTable.uUTHref.TrueForAll(x =>
            {
                return x.uutResult == "Passed";
            });

            if (IsOkay)
                return (true,null);
            var x = GetTests(tRC, GetErrors(tRC));

            return (false,x);
        }

        static List<int> GetErrors(TestResultsCollection tRC)
        {
            var indexes = tRC.Extension.TSBatchTable.uUTHref.Select((value, index) => new { value, index })
                    .Where(x => x.value.uutResult != "Passed")
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
    }
}
