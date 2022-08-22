
namespace ParserWF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gBStep1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCesta = new System.Windows.Forms.Label();
            this.btnFindSource = new System.Windows.Forms.Button();
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.tbFileSelectionPath = new System.Windows.Forms.TextBox();
            this.gBStep2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbProcessInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBFailedItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBErrorItems = new System.Windows.Forms.ComboBox();
            this.btProcessFiles = new System.Windows.Forms.Button();
            this.gBStep3 = new System.Windows.Forms.GroupBox();
            this.btExportData = new System.Windows.Forms.Button();
            this.btDirectorySelection = new System.Windows.Forms.Button();
            this.lbCesta2 = new System.Windows.Forms.Label();
            this.tbExportPath = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.cbDecimalComma = new System.Windows.Forms.CheckBox();
            this.gBStep1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gBStep2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBStep3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBStep1
            // 
            this.gBStep1.Controls.Add(this.groupBox4);
            this.gBStep1.Controls.Add(this.lbCesta);
            this.gBStep1.Controls.Add(this.btnFindSource);
            this.gBStep1.Controls.Add(this.btnLoadFiles);
            this.gBStep1.Controls.Add(this.tbFileSelectionPath);
            this.gBStep1.Location = new System.Drawing.Point(12, 39);
            this.gBStep1.Name = "gBStep1";
            this.gBStep1.Size = new System.Drawing.Size(834, 209);
            this.gBStep1.TabIndex = 0;
            this.gBStep1.TabStop = false;
            this.gBStep1.Text = "Krok 1 - Načtení souborů";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(625, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 177);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Počet souborů: ";
            // 
            // lbCesta
            // 
            this.lbCesta.AutoSize = true;
            this.lbCesta.Location = new System.Drawing.Point(18, 31);
            this.lbCesta.Name = "lbCesta";
            this.lbCesta.Size = new System.Drawing.Size(45, 20);
            this.lbCesta.TabIndex = 3;
            this.lbCesta.Text = "Cesta";
            // 
            // btnFindSource
            // 
            this.btnFindSource.Location = new System.Drawing.Point(231, 163);
            this.btnFindSource.Name = "btnFindSource";
            this.btnFindSource.Size = new System.Drawing.Size(207, 29);
            this.btnFindSource.TabIndex = 2;
            this.btnFindSource.Text = "Vyhledat soubory";
            this.btnFindSource.UseVisualStyleBackColor = true;
            this.btnFindSource.Click += new System.EventHandler(this.btnFindSource_Click);
            // 
            // btnLoadFiles
            // 
            this.btnLoadFiles.Location = new System.Drawing.Point(18, 163);
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.Size = new System.Drawing.Size(207, 29);
            this.btnLoadFiles.TabIndex = 1;
            this.btnLoadFiles.Text = "Načíst Soubory ze složky";
            this.btnLoadFiles.UseVisualStyleBackColor = true;
            this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
            // 
            // tbFileSelectionPath
            // 
            this.tbFileSelectionPath.Location = new System.Drawing.Point(18, 57);
            this.tbFileSelectionPath.Name = "tbFileSelectionPath";
            this.tbFileSelectionPath.Size = new System.Drawing.Size(601, 27);
            this.tbFileSelectionPath.TabIndex = 0;
            // 
            // gBStep2
            // 
            this.gBStep2.Controls.Add(this.label4);
            this.gBStep2.Controls.Add(this.rtbProcessInfo);
            this.gBStep2.Controls.Add(this.groupBox1);
            this.gBStep2.Controls.Add(this.btProcessFiles);
            this.gBStep2.Enabled = false;
            this.gBStep2.Location = new System.Drawing.Point(12, 259);
            this.gBStep2.Name = "gBStep2";
            this.gBStep2.Size = new System.Drawing.Size(834, 209);
            this.gBStep2.TabIndex = 1;
            this.gBStep2.TabStop = false;
            this.gBStep2.Text = "Krok 2 - Zpracování souborů";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Info";
            // 
            // rtbProcessInfo
            // 
            this.rtbProcessInfo.Location = new System.Drawing.Point(6, 52);
            this.rtbProcessInfo.Name = "rtbProcessInfo";
            this.rtbProcessInfo.ReadOnly = true;
            this.rtbProcessInfo.Size = new System.Drawing.Size(228, 151);
            this.rtbProcessInfo.TabIndex = 10;
            this.rtbProcessInfo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cBFailedItems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cBErrorItems);
            this.groupBox1.Location = new System.Drawing.Point(557, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Error:";
            // 
            // cBFailedItems
            // 
            this.cBFailedItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBFailedItems.FormattingEnabled = true;
            this.cBFailedItems.Items.AddRange(new object[] {
            "Zahrnout",
            "Vynechat",
            "Separovat"});
            this.cBFailedItems.Location = new System.Drawing.Point(126, 26);
            this.cBFailedItems.Name = "cBFailedItems";
            this.cBFailedItems.Size = new System.Drawing.Size(139, 28);
            this.cBFailedItems.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Failed:";
            // 
            // cBErrorItems
            // 
            this.cBErrorItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBErrorItems.FormattingEnabled = true;
            this.cBErrorItems.Items.AddRange(new object[] {
            "Zahrnout",
            "Vynechat",
            "Separovat"});
            this.cBErrorItems.Location = new System.Drawing.Point(126, 60);
            this.cBErrorItems.Name = "cBErrorItems";
            this.cBErrorItems.Size = new System.Drawing.Size(139, 28);
            this.cBErrorItems.TabIndex = 7;
            // 
            // btProcessFiles
            // 
            this.btProcessFiles.Location = new System.Drawing.Point(734, 164);
            this.btProcessFiles.Name = "btProcessFiles";
            this.btProcessFiles.Size = new System.Drawing.Size(94, 29);
            this.btProcessFiles.TabIndex = 5;
            this.btProcessFiles.Text = "Zpracovat";
            this.btProcessFiles.UseVisualStyleBackColor = true;
            this.btProcessFiles.Click += new System.EventHandler(this.btProcessFiles_Click);
            // 
            // gBStep3
            // 
            this.gBStep3.Controls.Add(this.cbDecimalComma);
            this.gBStep3.Controls.Add(this.btExportData);
            this.gBStep3.Controls.Add(this.btDirectorySelection);
            this.gBStep3.Controls.Add(this.lbCesta2);
            this.gBStep3.Controls.Add(this.tbExportPath);
            this.gBStep3.Enabled = false;
            this.gBStep3.Location = new System.Drawing.Point(12, 479);
            this.gBStep3.Name = "gBStep3";
            this.gBStep3.Size = new System.Drawing.Size(834, 209);
            this.gBStep3.TabIndex = 2;
            this.gBStep3.TabStop = false;
            this.gBStep3.Text = "Krok 3 - Export Souborů";
            // 
            // btExportData
            // 
            this.btExportData.Enabled = false;
            this.btExportData.Location = new System.Drawing.Point(734, 164);
            this.btExportData.Name = "btExportData";
            this.btExportData.Size = new System.Drawing.Size(94, 29);
            this.btExportData.TabIndex = 7;
            this.btExportData.Text = "Exportovat";
            this.btExportData.UseVisualStyleBackColor = true;
            this.btExportData.Click += new System.EventHandler(this.btExportData_Click);
            // 
            // btDirectorySelection
            // 
            this.btDirectorySelection.Location = new System.Drawing.Point(18, 90);
            this.btDirectorySelection.Name = "btDirectorySelection";
            this.btDirectorySelection.Size = new System.Drawing.Size(144, 29);
            this.btDirectorySelection.TabIndex = 6;
            this.btDirectorySelection.Text = "Vyhledat složku";
            this.btDirectorySelection.UseVisualStyleBackColor = true;
            this.btDirectorySelection.Click += new System.EventHandler(this.btDirectorySelection_Click);
            // 
            // lbCesta2
            // 
            this.lbCesta2.AutoSize = true;
            this.lbCesta2.Location = new System.Drawing.Point(18, 31);
            this.lbCesta2.Name = "lbCesta2";
            this.lbCesta2.Size = new System.Drawing.Size(45, 20);
            this.lbCesta2.TabIndex = 5;
            this.lbCesta2.Text = "Cesta";
            // 
            // tbExportPath
            // 
            this.tbExportPath.Location = new System.Drawing.Point(18, 57);
            this.tbExportPath.Name = "tbExportPath";
            this.tbExportPath.Size = new System.Drawing.Size(601, 27);
            this.tbExportPath.TabIndex = 4;
            this.tbExportPath.TextChanged += new System.EventHandler(this.tbExportPath_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(88, 24);
            this.toolStripMenuItem1.Text = "Nastavení";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageComboBox});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(126, 26);
            this.toolStripMenuItem2.Text = "Jazyk";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "Čeština",
            "English"});
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(121, 28);
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // cbDecimalComma
            // 
            this.cbDecimalComma.AutoSize = true;
            this.cbDecimalComma.Location = new System.Drawing.Point(18, 125);
            this.cbDecimalComma.Name = "cbDecimalComma";
            this.cbDecimalComma.Size = new System.Drawing.Size(187, 24);
            this.cbDecimalComma.TabIndex = 4;
            this.cbDecimalComma.Text = "Použít desetinnou čárku";
            this.cbDecimalComma.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 693);
            this.Controls.Add(this.gBStep3);
            this.Controls.Add(this.gBStep2);
            this.Controls.Add(this.gBStep1);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(875, 740);
            this.MinimumSize = new System.Drawing.Size(875, 740);
            this.Name = "Form1";
            this.Text = "Valeo SmartBar XML Parser";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.gBStep1.ResumeLayout(false);
            this.gBStep1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gBStep2.ResumeLayout(false);
            this.gBStep2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBStep3.ResumeLayout(false);
            this.gBStep3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBStep1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbCesta;
        private System.Windows.Forms.Button btnFindSource;
        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.TextBox tbFileSelectionPath;
        private System.Windows.Forms.GroupBox gBStep2;
        private System.Windows.Forms.GroupBox gBStep3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btProcessFiles;
        private System.Windows.Forms.ComboBox cBErrorItems;
        private System.Windows.Forms.ComboBox cBFailedItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbProcessInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDirectorySelection;
        private System.Windows.Forms.Label lbCesta2;
        private System.Windows.Forms.TextBox tbExportPath;
        private System.Windows.Forms.Button btExportData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripComboBox LanguageComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbDecimalComma;
    }
}

