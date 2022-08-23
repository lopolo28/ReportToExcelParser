using GemBox.Spreadsheet;
using GemBox.Spreadsheet.Charts;
using ReportToExcelParser.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using static ReportToExcelParser.Methods.DataGrabber;

namespace ReportToExcelParser.Methods
{
    public class DataWrapper
    {
        const string headerName = "Test Name";
        const string headerStatus = "Result Status";
        const string headerStation = "Station";
        const string headerProductName = "Production Name";
        const string headerCycletime = "Cycle Time";
        public static Dictionary<string, List<Unite>> ParseXML(Reports reports)
        {
            var ResultList = GetResults(reports.report.Prop);

            var ResultListStep2 = GetResults(GetPropArray(ResultList.Value));

            Dictionary<string, List<Unite>> valuePairs = new();
            foreach (var item in ResultListStep2.Value)
            {
                var stepName = GetStepName(item.prop);
                if (!valuePairs.ContainsKey(stepName))
                    valuePairs.Add(stepName, new List<DataGrabber.Unite>());
                var ResultListStep3 = GetResults(item.prop);
                Validate(ResultListStep3, valuePairs[stepName]);
            }
            return valuePairs;
        }

        #region CSV
        public static List<string> CreateCSV(List<Reports> reports, char sep = ',')
        {

            List<string> output = new List<string>() { "Test Name", "Limits[Units]" };
            CreateHeaderCSV(ParseXML(reports.FirstOrDefault()), output);

            foreach (Reports report in reports)
            {
                var ParsedReport = ParseXML(report);
                string newPart = GetSerialNumber(report.report);
                foreach (var item in ParsedReport.Values)
                    foreach (var item2 in item)
                        newPart += $"{sep}=\"{item2.Value}\"";

                output.Add(newPart);
            }

            return output;
        }
        private static void CreateHeaderCSV(Dictionary<string, List<Unite>> ParsedReport, List<string> output, char sep = ',')
        {
            foreach (var item in ParsedReport.Values)
            {
                foreach (var item2 in item)
                {
                    output[0] += $"{sep}=\"{item2.Name}\"";
                    output[1] += $"{sep}{CreateLimitValueCSV(item2)}";
                }
            }
        }
        private static string CreateLimitValueCSV(Unite unite)
        {
            string output = string.Empty;
            if (unite.Limit != null)
            {
                output += $"=\"{unite.Limit.LimitLow}";

                if (unite.Limit.LimitHigh != null)
                {
                    output += $"- { unite.Limit.LimitHigh}";
                }


                if (unite.Units != null)
                    output += $"[{unite.Units}]";

                output += $"\"";
            }
            return output;
        }
        #endregion

        #region XLSX
        public static Dictionary<string, ExcelFile> CreateXLSXMany(Dictionary<string, List<Reports>> reportDictionary, bool decimalComma)
        {
            Dictionary<string, ExcelFile> excelFileList = new Dictionary<string, ExcelFile>();
            foreach (var reports in reportDictionary)
            {
                excelFileList.Add(reports.Key, CreateXLSX(reports.Value, decimalComma));
            }

            return excelFileList;
        }
        public static ExcelFile CreateXLSX(List<Reports> reports,bool decimalComma)
        {
            ExcelFile excelFile = new ExcelFile();
            SortReports(ref reports);
            foreach (Reports report in reports)
            {
                var serialNumber = GetSerialNumber(report.report);
                var cycleTime = GetCycleTime(report.report);
                var workSheetName = serialNumber.Substring(0, 2);
                AddWorkSheetContent(ref excelFile, workSheetName, report, serialNumber, cycleTime);
            }

            WorkSheetPostProcess(ref excelFile, decimalComma);
            return excelFile;
        }

        private static void SortReports(ref List<Reports> reports)
        {
            List<Reports> sortedReports = new List<Reports>();

            foreach (var item in reports.Where(x=> x.report.UUTResult == "Passed"))
                sortedReports.Add(item);

            foreach (var item in reports.Where(x => x.report.UUTResult == "Failed"))
                sortedReports.Add(item);

            foreach (var item in reports.Where(x => x.report.UUTResult == "Error"))
                sortedReports.Add(item);

            foreach (var item in reports.Where(x => x.report.UUTResult != "Passed" && x.report.UUTResult != "Failed" && x.report.UUTResult != "Error"))
                sortedReports.Add(item);

            reports = sortedReports;
        }

        public static void AddWorkSheetContent(ref ExcelFile excelFile, string workSheetName, Reports Content, string serialNumber, string cycleTime)
        {
            var parsedXML = ParseXML(Content);
            if (!excelFile.Worksheets.Contains(workSheetName))
            {
                var headerXSLX = CreateHeaderXLSX(parsedXML);
                excelFile.Worksheets.Add(workSheetName);
                WorkSheetAddHeader(ref excelFile, workSheetName, headerXSLX.Item1);
                WorkSheetAddLimits(ref excelFile, workSheetName, headerXSLX.Item2);
            }
            var productName = Content.report.Prop.Any(x => x.Name == "ProductName") == true ? Content.report.Prop.Where(x => x.Name == "ProductName").FirstOrDefault().Value.FirstOrDefault().Text : string.Empty;
            var stationName = Content.report.Prop.Where(x => x.Name == "StationName").FirstOrDefault();



            WorkSheetAddContent(ref excelFile, workSheetName, CreatePartsContentXLSX(parsedXML, new string[] 
            { serialNumber, Content.report.UUTResult, stationName != null ? stationName.Value[0].Text : workSheetName, productName, cycleTime }));

        }
        private static (string[], string[]) CreateHeaderXLSX(Dictionary<string, List<Unite>> ParsedReport)
        {
            var headerOut = new List<string>() { "Test Name", "Result Status", "Station" , "Production Name", "Cycle Time" };
            var limitsOut = new List<string>() { "Limits[Units]", "", "","", ""};

            foreach (var uniteList in ParsedReport.Values)
            {
                foreach (var unite in uniteList)
                {
                    headerOut.Add(unite.Name);
                    limitsOut.Add(CreateLimitValueXLSX(unite));
                }
            }
            return (headerOut.ToArray(), limitsOut.ToArray());
        }
        public static void WorkSheetAddHeader(ref ExcelFile excelFile, string workSheetName, string[] workSheetHeader)
        {
            for (int i = 0; i < workSheetHeader.Length; i++)
            {
                excelFile.Worksheets[workSheetName].Rows[0].Cells[i].Value = workSheetHeader[i];
            }
        }
        public static void WorkSheetAddLimits(ref ExcelFile excelFile, string workSheetName, string[] workSheetLimits)
        {
            for (int i = 0; i < workSheetLimits.Length; i++)
            {
                excelFile.Worksheets[workSheetName].Rows[1].Cells[i].Value = workSheetLimits[i];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="workSheetName"></param>
        /// <param name="workSheetContent">string1 = Value; string2 = Column Name; string3 = Data Type</param>
        public static void WorkSheetAddContent(ref ExcelFile excelFile, string workSheetName, (string, string, string)[] workSheetContent)
        {
            var workSheetRowCount = excelFile.Worksheets[workSheetName].Rows.Count;
            for (int j = 0; j < workSheetContent.GetLength(0); j++)
            {
                var index = excelFile.Worksheets[workSheetName].Rows[0].Cells.Where(x => x.GetFormattedValue() == workSheetContent[j].Item2).Select(x => x.Column.Index);
                foreach (int i in index)
                {
                    if (excelFile.Worksheets[workSheetName].Rows[workSheetRowCount].Cells[i].GetFormattedValue() == "")
                    {
                        if (workSheetContent[j].Item3 == "Number")
                        {
                            double numberValue;
                            if (double.TryParse(workSheetContent[j].Item1, NumberStyles.Any, CultureInfo.InvariantCulture, out numberValue))
                            {
                                excelFile.Worksheets[workSheetName].Rows[workSheetRowCount].Cells[i].SetValue(numberValue);
                            }
                            else
                            {
                                excelFile.Worksheets[workSheetName].Rows[workSheetRowCount].Cells[i].SetValue(workSheetContent[j].Item1);
                            }
                        }
                        else
                        {
                            excelFile.Worksheets[workSheetName].Rows[workSheetRowCount].Cells[i].SetValue(workSheetContent[j].Item1);
                        }
                        break;
                    }
                }
            }
        }
        public static void WorkSheetPostProcess(ref ExcelFile excelFile,bool decimalComma)
        {
            RemoveEmptyColumns(ref excelFile);
            foreach (var workSheet in excelFile.Worksheets)
            {
                foreach (var row in workSheet.Rows)
                    row.Height = 300;
                workSheet.Panes = new WorksheetPanes(2, 0);
                var currentCountOfRows = workSheet.Rows.Count;
                workSheet.Columns[3].Cells[currentCountOfRows].Value = "Minimum";
                workSheet.Columns[3].Cells[currentCountOfRows + 1].Value = "Average";
                workSheet.Columns[3].Cells[currentCountOfRows + 2].Value = "Maximum";
                workSheet.Columns[3].Cells[currentCountOfRows + 3].Value = "Failed tests";
                for (int i = 4; i < workSheet.CalculateMaxUsedColumns(); i++)
                {
                    var magicFormula = $"R3C{i + 1}:R{currentCountOfRows}C{i + 1}";
                    var limits = GetLimitsFromExcel(workSheet.Rows[1].Cells[i].Value, magicFormula,decimalComma);
                    workSheet.Columns[i].Cells[currentCountOfRows].FormulaR1C1 = $"=MIN({magicFormula})";
                    workSheet.Columns[i].Cells[currentCountOfRows + 1].FormulaR1C1 = $"=AVERAGE({magicFormula})";
                    workSheet.Columns[i].Cells[currentCountOfRows + 2].FormulaR1C1 = $"=MAX({magicFormula})";
                    if (!string.IsNullOrEmpty(limits))
                        workSheet.Columns[i].Cells[currentCountOfRows + 3].FormulaR1C1 = $"=COUNT({magicFormula}) - {limits}"; // COUNTIF({magicFormula},">=126")
                }

                currentCountOfRows = workSheet.Rows.Count;
                var formula = $"R3C2:R{currentCountOfRows - 4}C2";

                workSheet.Columns[0].Cells[currentCountOfRows].Value = "OK product";
                workSheet.Columns[1].Cells[currentCountOfRows].FormulaR1C1 = $"=COUNTIF({formula},\"Passed\")";
                workSheet.Columns[0].Cells[currentCountOfRows + 1].Value = "NOK product";
                workSheet.Columns[1].Cells[currentCountOfRows + 1].FormulaR1C1 = $"=COUNTA({formula})-R{currentCountOfRows + 1}C2";

                var failedTestRow = currentCountOfRows;

                currentCountOfRows = workSheet.Rows.Count + 1;
                var currentCountOfColumns = workSheet.CalculateMaxUsedColumns();
                workSheet.Columns[0].Cells[currentCountOfRows].Value = "Problem source";
                workSheet.Columns[1].Cells[currentCountOfRows].Value = "Limits";
                workSheet.Columns[2].Cells[currentCountOfRows].Value = "Occurence";
                workSheet.Columns[0].Cells[currentCountOfRows + 1].FormulaR1C1 = $"=TRANSPOSE(R1C4:R1C{currentCountOfColumns})";
                workSheet.Columns[1].Cells[currentCountOfRows + 1].FormulaR1C1 = $"=TRANSPOSE(R2C4:R2C{currentCountOfColumns})";
                workSheet.Columns[2].Cells[currentCountOfRows + 1].FormulaR1C1 = $"=TRANSPOSE(R{failedTestRow}C4:R{failedTestRow}C{currentCountOfColumns})";
            }
        }
        public static (string,string, string)[] CreatePartsContentXLSX(Dictionary<string, List<Unite>> ParsedReport, string[] param)
        {
            List<(string, string, string)> output = new() { (param[0], headerName, "String"), (param[1], headerStatus, "String"), 
                                                            (param[2], headerStation, "String"), (param[3], headerProductName, "String"), 
                                                            (param[4], headerCycletime,"Number") };

            foreach (var uniteList in ParsedReport)
            {
                foreach (var unite in uniteList.Value)
                    output.Add((unite.Value, unite.Name, unite.UnitsType));
            }

            return output.ToArray();
        }
        private static string CreateLimitValueXLSX(Unite unite)
        {
            string output = string.Empty;
            if (unite.Limit != null)
            {
                output += $"{unite.Limit.LimitLow}";

                if (unite.Limit.LimitHigh != null)
                {
                    output += $" - { unite.Limit.LimitHigh}";
                }
                if (unite.Units != null)
                    output += $"[{unite.Units}]";
            }
            return output;
        }

        #endregion

        #region Private

        // Vrací Sériové číslo dílu
        private static string GetSerialNumber(Report Report)
        {
            Prop UUTProp = Report.Prop.Where(x => x.Name == "UUT").FirstOrDefault();
            Prop SerialNumber = UUTProp.prop.Where(x => x.Name == "SerialNumber").FirstOrDefault();

            return SerialNumber.Value.FirstOrDefault().Text;
        }
        // Vrací celkový Čas cyklu
        private static string GetCycleTime(Report Report)
        {
            Prop TEResult = Report.Prop.Where(x => x.Type == "TEResult").FirstOrDefault();
            Prop TS = TEResult.prop.Where(x => x.Name == "TS").FirstOrDefault();
            Prop TotalTime = TS.prop.Where(x => x.Name == "TotalTime").FirstOrDefault();

            return TotalTime.Value.FirstOrDefault().Text;
        }

        private static Prop GetResults(Prop[] prop)
        {
            return prop.Where(x => x.Type == "TEResult").FirstOrDefault()
                .prop.Where(x => x.Name == "TS").FirstOrDefault()
                .prop.Where(x => x.Name == "SequenceCall").FirstOrDefault()
                .prop.Where(x => x.Name == "ResultList").FirstOrDefault();//.Value.Where(x => x.prop.Type == "TEResult").FirstOrDefault().prop;
        }
        //Vrací s název "ResultList". Počáteční Prop musí být s Názvem "TEReports"
        private static Prop GetResults(Prop prop)
        {
            if (prop != null)
            {
                var TS = prop.prop.Where(x => { try { return x.Name == "TS"; } catch (Exception) { return false; } }).FirstOrDefault();
                if (TS != null)
                {
                    var SequenceCall = TS.prop.Where(x => { try { return x.Name == "SequenceCall"; } catch (Exception) { return false; } }).FirstOrDefault();
                    if (SequenceCall != null)
                    {
                        var ResultList = SequenceCall.prop.Where(x => { try { return x.Name == "ResultList"; } catch (Exception) { return false; } }).FirstOrDefault();

                        if (ResultList != null)
                            return ResultList;
                    }
                }
            }
            return null;
        }
        // Vrací string s názvem kroku
        private static string GetStepName(Prop prop)
        {
            return prop.prop.Where(x => x.Name == "TS").FirstOrDefault()
                .prop.Where(x => x.Name == "StepName").FirstOrDefault().Value[0].Text;
        }
        // Vrací Prop[] z List<Value> z metody GetValueList()
        private static Prop[] GetPropArray(List<Value> values)
        {
            List<Prop> props = new List<Prop>();
            values.ForEach(x =>
            {
                if (x.prop != null)
                    props.Add(x.prop);
            });
            return props.ToArray();
        }
        // Kontrola, zda-li Prop[] v Propu odpovídá správné Hierarchii Propu s hodnotami
        private static bool CheckPropForUnite(Prop prop)
        {
            if (prop.prop == null)
                return false;

            string[] checkList = new string[] { "Error", "Status", "PassFail", "ReportText", "Common", "TS" };
            string[] CheckPropWithoutUnits = new string[] { "Error", "Status", "Numeric", "ReportText", "Common", "TS", "Limits", "Comp" };
            string[] CheckPropWithUnits = new string[] { "Error", "Status", "Numeric", "ReportText", "Common", "Units", "TS", "Limits", "Comp" };
            string[] CheckPropDigiInput = new string[] { "Error", "Status", "Numeric", "ReportText", "Common", "TS", "Limits", "Comp", "AdditionalResults" };

            var Check = prop.prop.All(x => checkList.Contains(x.Name)
            || CheckPropWithoutUnits.Contains(x.Name)
            || CheckPropWithUnits.Contains(x.Name)
            || CheckPropDigiInput.Contains(x.Name));

            return Check;
        }
        // Rekurzivní hledání Propů s hodnotami
        private static void Validate(Prop prop, List<DataGrabber.Unite> uniteList)
        {
            if (prop is null)
                return;

            if (prop.Name == "ResultList")
            {
                foreach (var value in prop.Value)
                {
                    Validate(value.prop, uniteList);
                }
            }
            else if (prop.Type == "TEResult")
            {
                if (CheckPropForUnite(prop))
                    uniteList.Add(DataGrabber.GetResult(prop));
                Validate(GetResults(prop), uniteList);
            }
        }
        private static void RemoveEmptyColumns(ref ExcelFile excelFile)
        {
            foreach (var workSheet in excelFile.Worksheets)
            {
                var currentCountOfRows = workSheet.Rows.Count;
                for (int i = 0; i < workSheet.CalculateMaxUsedColumns(); i++)
                {
                    bool removeColumn = true;
                    for (int j = 2; j < currentCountOfRows; j++)
                    {
                        var value = workSheet.Columns[i].Cells[j].Value;
                        if (value != null)
                        {
                            removeColumn = false;
                        }
                        if (removeColumn)
                        {
                            workSheet.Columns.Remove(i);
                            i--;
                        }
                    }
                }
            }
        }
        private static string GetLimitsFromExcel(object input,string magicFormula,bool decimalComma)
        {
            // TODO: Číslo je záporné ?
            string value = input.ToString();

            if (decimalComma)
                value = value.Replace('.', ',');

            bool isNegative = false;
            if(!string.IsNullOrEmpty(value) && value[0] == '-')
            {
                isNegative = true;
                value = value.Remove(0, 1);
            }
            
            if (value.Contains('['))
                value = value.Remove(value.IndexOf('['), value.Length - value.IndexOf('['));

            if(value.Contains('-'))
            {
                value = value.Replace(" ", "");
                string[] splited = value.Split('-');
                if(isNegative)
                    return $"COUNTIFS({magicFormula},\">=-{splited[0]}\",{magicFormula},\"<={splited[1]}\")";
                else
                    return $"COUNTIFS({magicFormula},\">={splited[0]}\",{magicFormula},\"<={splited[1]}\")";
            }

            if (value.Contains("x") || string.IsNullOrEmpty(value))
                return string.Empty;

            return $"COUNTIF({magicFormula},\">={value}\")";
        }
        #endregion
        public static void Init()
        {
            SpreadsheetInfo.SetLicense("SN-2022Apr07-kjD6xRmhe6e7e1MJoQbyI37N4UfIcnJInkq31MrwS26TAgUQdhgDt5vLqjJuv8Z0nWH1WpAG6RgTXfEtRDtdcBcN5Ug==A");

        }
    }
}
