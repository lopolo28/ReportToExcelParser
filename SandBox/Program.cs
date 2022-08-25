using ReportToExcelParser.Methods;
using ReportToExcelParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"input\Report_EoLT_FC[EB03240FFFF1122223001070][1][11.08.2022][09 56 36].xml";
            TestResultsCollection testResultsCollection = 
                Unwrapper.UnWrapSync<TestResultsCollection>(path);

            Console.ReadLine();


        }
    }
}
