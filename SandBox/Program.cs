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
            if (!Directory.Exists(@"input\"))
                Directory.CreateDirectory(@"input\");

            if (!Directory.Exists(@"output\"))
                Directory.CreateDirectory(@"output\");

            string path = @"input\";

            Console.WriteLine("Zadejte cestu k souborů [Enter pro defaultní složku input\\ ve složce s programem]:");
            var input = Console.ReadLine();
            if (System.IO.Directory.Exists(input))
                path = input;

            Console.WriteLine("Chcete použít desetinnou čárku [Y/N] ? x.xx -> x,xx");
            var decimalComma = Console.ReadLine();

            bool useDecComma = false;
            if (decimalComma.ToLower() == "y")
                useDecComma = true;

            Dictionary<string, List<Reports>> ReportDictionary = new();

            Console.Clear();
            Console.WriteLine($"Načítám soubory z {path}");

            var unwrap = Unwrapper.UnWrapFilesAsync<Reports>(path).Result.ToList();

            Console.WriteLine("DataWrapper Init...");
            DataWrapper.Init();

            Console.WriteLine("Vytvářím excelFile...");
            var excelFile = DataWrapper.CreateXLSX(unwrap, useDecComma);

            Console.WriteLine($@"Ukládám output\file.xlsx");
            excelFile.Save(@"output\Output.xlsx");


            Console.WriteLine("Hotovo - Program můžete ukončit");
            Console.ReadKey();
        }
    }
}
