using ReportToExcelParser.Methods;
using ReportToExcelParser.Models;
using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\jaugusta\Downloads\!DFC EoL reports\EB03240FFFF1122223001044\2022-08-11_09-56-36\Report_EoLT_FC[EB03240FFFF1122223001044][2][11.08.2022][09 56 36].xml";
            Unwrapper unwrapper = new Unwrapper();


            var trc = Unwrapper.UnWrapSync<TestResultsCollection>(path);

            Console.ReadLine();
        }
    }
}
