using System; 
using ReportToExcelParser.Methods;
using ReportToExcelParser.Models.Gen2022;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string path = @"input\Report_EoLT_FC[EB03240FFFF1122223001070][1][11.08.2022][09 56 36].xml";
            const string path = @"input\ScrTest_MainTest_FC[E872358][7 12 2022][11 58 02 AM].xml";
            TestResultsCollection testResultsCollection = 
                Unwrapper.UnWrapSync<TestResultsCollection>(path);

            Console.ReadLine();

        }
    }
}
