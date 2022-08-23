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
            const string path = @"C:\Users\jaugusta\Downloads\!DFC EoL reports\EB03240FFFF1122223001048\2022-08-11_09-56-36\Report_EoLT_FC[EB03240FFFF1122223001048][7][11.08.2022][09 56 36].xml";
            var x = Unwrapper.UnWrapSync<ReportToExcelParser.Models.Old.TestResultsCollection>(path);

            Console.ReadLine();
        }
    }
}
