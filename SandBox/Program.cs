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


            Console.WriteLine(passed);

            var indexes = GetErrors(testResultsCollectionNOK);
            indexes.ForEach(index =>
            {
                var collection = testResultsCollectionNOK.TestResults[index].ResultSet.TestGroup.FirstOrDefault().Test.FindAll(y =>
                {
                    return y.Outcome.Value == "Failed";
                }); 

                var NotStarted = testResultsCollectionNOK.TestResults[index].ResultSet.TestGroup.FirstOrDefault().Test.FindAll(y =>
                {
                    return y.Outcome.Value == "NotStarted";
                });
                Console.ReadLine();
            });
            Console.ReadLine();

        }

        static bool TestXML(TestResultsCollection tRC)
        {
            return tRC.Extension.TSBatchTable.uUTHref.TrueForAll(x =>
            {
                return x.uutResult == "Passed";
            });
        }

        static List<int> GetErrors(TestResultsCollection tRC)
        {
            var indexes = tRC.Extension.TSBatchTable.uUTHref.Select((value, index) => new { value, index })
                    .Where(x => x.value.uutResult != "Passed")
                    .Select(x => x.index)
                    .ToList();

            return indexes;
        }
    }
}
