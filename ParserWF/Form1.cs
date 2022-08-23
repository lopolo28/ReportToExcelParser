using GemBox.Spreadsheet;
using ReportToExcelParser.Methods;
using ReportToExcelParser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserWF
{
    public partial class Form1 : Form
    {
        public List<string> files;
        public Dictionary<string, List<Reports>> ReportDictionary;
        static string[] languageDictionary = new string[] { "Vyberte složku s díly", "Nebyl vybrán žádný soubor", "Zpráva", "Zpracováno dílů", "Nezpracovaných souborů", "Nezpracováno", "Vyexportováno" };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            var defaultLanguage = ConfigurationManager.AppSettings["defaultLanguage"];
            if (!string.IsNullOrEmpty(defaultLanguage) && (defaultLanguage == "en" || defaultLanguage == "cz"))
                Translate(defaultLanguage);
        }

        #region Step1 - Import

        private void btnFindSource_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog() { Title = languageDictionary[0], Multiselect = true, Filter = "XML Files (*.xml)|*.xml" })
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    files = fbd.FileNames.ToList();

                    tbFileSelectionPath.Text = new FileInfo(files[0]).DirectoryName;

                    label5.Text = $"{files.Count}";

                    if (files.Count > 0)
                        gBStep2.Enabled = true;
                }
                else if (result == DialogResult.Cancel || result == DialogResult.Abort)
                {
                    MessageBox.Show(languageDictionary[1], languageDictionary[2], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            if (tbFileSelectionPath.Text != string.Empty && Directory.Exists(tbFileSelectionPath.Text))
            {
                files = Directory.GetFiles(tbFileSelectionPath.Text, "*.xml").ToList();
                label5.Text = $"{files.Count}";

                if (files.Count > 0)
                    gBStep2.Enabled = true;
            }
        }

        #endregion

        #region Step2 - Process Data
        private async void btProcessFiles_Click(object sender, EventArgs e)
        {
            ReportDictionary = new Dictionary<string, List<Reports>>();
            rtbProcessInfo.Text = string.Empty;
            if (files.Count > 0)
            {
                List<FileInfo> fileInfos = new();

                files.ForEach(x => fileInfos.Add(new FileInfo(x)));

                files.Clear();

                var proccessed = (await ReportsAsync(fileInfos)).ToList();

                fileInfos.Clear();

                rtbProcessInfo.Text += $"{languageDictionary[3]}: {proccessed.Count} \r\n{languageDictionary[4]}: {fileInfos.Count - proccessed.Count}";

                switch (cBFailedItems.SelectedIndex)
                {
                    case 1:
                        proccessed.RemoveAll(x => x.report.UUTResult == "Failed");
                        break;
                    case 2:
                        var Failed = proccessed.Where(x => x.report.UUTResult == "Failed").ToList();
                        proccessed.RemoveAll(x => x.report.UUTResult == "Failed");
                        ReportDictionary.Add("Failed", Failed);
                        break;
                    default:
                        break;
                }
                switch (cBErrorItems.SelectedIndex)
                {
                    case 1:
                        proccessed.RemoveAll(x => x.report.UUTResult == "Error");
                        break;
                    case 2:
                        var Errors = proccessed.Where(x => x.report.UUTResult == "Error").ToList();
                        proccessed.RemoveAll(x => x.report.UUTResult == "Error");
                        ReportDictionary.Add("Error", Errors);
                        break;
                    default:
                        break;
                }
                ReportDictionary.Add("Passed", proccessed);

                gBStep3.Enabled = true;
            }
        }

        private async Task<Reports[]> ReportsAsync(List<FileInfo> fileInfos)
        {
            try
            {
                var reports = await Unwrapper.UnWrapFilesAsync<Reports>(fileInfos);
                return reports;
            }
            catch (Exception)
            {
                List<Reports> reports = new List<Reports>();
                rtbProcessInfo.Text += "Bulk Failed\r\n"+ "Starting one by one operation\r\n";
                for (int i = 0; i < fileInfos.Count; i++)
                {
                    try
                    {
                        var report = await Unwrapper.UnWrapAsync<Reports>(fileInfos[i].FullName);
                        reports.Add(report);
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        rtbProcessInfo.Text += ex.Message + "\r\n";
#else
                        rtbProcessInfo.Text += $"{languageDictionary[5]}: {fileInfos[i].Name}\r\n";
#endif
                    }
                }
                return reports.ToArray();
            }
        }

#endregion

#region Step3 - Export
        private void btDirectorySelection_Click(object sender, EventArgs e)
        {
            using (var fdb = new FolderBrowserDialog())
            {
                var result = fdb.ShowDialog();

                if (result == DialogResult.OK && fdb.SelectedPath != string.Empty)
                {
                    tbExportPath.Text = fdb.SelectedPath;
                }
            }
        }
        private void tbExportPath_TextChanged(object sender, EventArgs e)
        {
            btExportData.Enabled = (!string.IsNullOrEmpty(tbExportPath.Text) && Directory.Exists(tbExportPath.Text));
        }
        private void btExportData_Click(object sender, EventArgs e)
        {
            try
            {
                var excelFileDictionary = DataWrapper.CreateXLSXMany(ReportDictionary,cbDecimalComma.Checked);

                ReportDictionary.Clear();

                foreach (var item in excelFileDictionary)
                {
                    item.Value.Save($@"{tbExportPath.Text}\{item.Key}.xlsx");
                }

                MessageBox.Show(languageDictionary[6]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
#endregion

#region Translation
        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ToolStripComboBox;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    Translate("cz");
                    break;
                case 1:
                default:
                    Translate("en");
                    break;
            }
        }
        private void Translate(string language)
        {

            switch (language)
            {
                case "cz":
                    toolStripMenuItem1.Text = "Nastavení";
                    toolStripMenuItem2.Text = "Jazyk";
                    gBStep1.Text = "Krok 1 - Načtení souborů";
                    gBStep2.Text = "Krok 2 - Zpracování souborů";
                    gBStep3.Text = "Krok 3 - Export Souborů";
                    lbCesta.Text = lbCesta2.Text = "Cesta";
                    btnLoadFiles.Text = "Načíst Soubory ze složky";
                    btnFindSource.Text = "Vyhledat Soubory";
                    label1.Text = "Počet souborů:";
                    btDirectorySelection.Text = "Vyhledat složku";
                    btProcessFiles.Text = "Zpracovat";
                    btExportData.Text = "Exportovat";
                    cBErrorItems.Items[0] = cBFailedItems.Items[0] = "Zahrnout";
                    cBErrorItems.Items[1] = cBFailedItems.Items[1] = "Vynechat";
                    cBErrorItems.Items[2] = cBFailedItems.Items[2] = "Separovat";
                    cbDecimalComma.Text = "Použít desetinnou čárku";
                    languageDictionary = new string[] { "Vyberte složku s díly", "Nebyl vybrán žádný soubor", "Zpráva", "Zpracováno dílů"
                        , "Nezpracovaných souborů", "Nezpracováno", "Vyexportováno" };
                    break;
                case "en":
                    toolStripMenuItem1.Text = "Options";
                    toolStripMenuItem2.Text = "Language";
                    gBStep1.Text = "Step 1 - Load Files";
                    gBStep2.Text = "Step 2 - Process Data";
                    gBStep3.Text = "Step 3 - Export Data";
                    lbCesta.Text = lbCesta2.Text = "Path";
                    btnLoadFiles.Text = "Get files from directory";
                    btnFindSource.Text = "Select Files";
                    label1.Text = "Files Loaded:";
                    btDirectorySelection.Text = "Select directory";
                    btProcessFiles.Text = "Process";
                    btExportData.Text = "Export";
                    cBErrorItems.Items[0] = cBFailedItems.Items[0] = "Include";
                    cBErrorItems.Items[1] = cBFailedItems.Items[1] = "Exclude";
                    cBErrorItems.Items[2] = cBFailedItems.Items[2] = "Separate";
                    cbDecimalComma.Text = "Use decimal comma";
                    languageDictionary = new string[] { "Select folder with Reports", "No files selected", "Error", "Parts processed"
                        , "Parts not processed", "Not Processed", "Exported" };
                    break;
            }
        }
#endregion


    }
}
