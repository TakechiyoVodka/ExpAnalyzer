using System;

namespace ExpAnalyzer
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PanelInportData = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxHallDataSource = new System.Windows.Forms.ComboBox();
            this.ChartDailyData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ButtonCloseUnitDataGroup = new System.Windows.Forms.Button();
            this.ButtonInportHallData = new System.Windows.Forms.Button();
            this.groupBoxColor1 = new ExpAnalyzer.Views.GroupBoxColor();
            this.TextBoxProbVarHitProb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBoxCTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxSavingTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBoxSpecialTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxProbVarHitPersisRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxProbVarHitRashRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxFirstHitProb = new System.Windows.Forms.TextBox();
            this.ButtonOpenUnitDataGroup = new System.Windows.Forms.Button();
            this.DataGridViewUnitData = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBoxModelName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxStoreName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonReference = new System.Windows.Forms.Button();
            this.TextBoxHallDataFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelAnalyzeData = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.ChartFirstHitCompProb = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PanelAnalyzeDataOperate = new System.Windows.Forms.Panel();
            this.groupBoxColor3 = new ExpAnalyzer.Views.GroupBoxColor();
            this.CheckBoxMA2Enable = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.NumUpDownMA2SampleNum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.ComboBoxMA2Type = new System.Windows.Forms.ComboBox();
            this.groupBoxColor2 = new ExpAnalyzer.Views.GroupBoxColor();
            this.CheckBoxMA1Enable = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.NumUpDownMA1SampleNum = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.ComboBoxMA1Type = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ComboBoxDispUnitNum = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ComboBoxDispModelName = new System.Windows.Forms.ComboBox();
            this.ButtonDispInportDataPanel = new System.Windows.Forms.Button();
            this.ButtonDispAnalyzeDataPanel = new System.Windows.Forms.Button();
            this.ButtonDispExportReportPanel = new System.Windows.Forms.Button();
            this.ButtonDispUserSettingsPanel = new System.Windows.Forms.Button();
            this.PanelExportReport = new System.Windows.Forms.Panel();
            this.label_PanelExportReport = new System.Windows.Forms.Label();
            this.PanelUserSettings = new System.Windows.Forms.Panel();
            this.label_PanelUserSettings = new System.Windows.Forms.Label();
            this.PanelInportData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartDailyData)).BeginInit();
            this.groupBoxColor1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUnitData)).BeginInit();
            this.PanelAnalyzeData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstHitCompProb)).BeginInit();
            this.PanelAnalyzeDataOperate.SuspendLayout();
            this.groupBoxColor3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMA2SampleNum)).BeginInit();
            this.groupBoxColor2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMA1SampleNum)).BeginInit();
            this.PanelExportReport.SuspendLayout();
            this.PanelUserSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelInportData
            // 
            this.PanelInportData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelInportData.Controls.Add(this.label5);
            this.PanelInportData.Controls.Add(this.ComboBoxHallDataSource);
            this.PanelInportData.Controls.Add(this.ChartDailyData);
            this.PanelInportData.Controls.Add(this.ButtonCloseUnitDataGroup);
            this.PanelInportData.Controls.Add(this.ButtonInportHallData);
            this.PanelInportData.Controls.Add(this.groupBoxColor1);
            this.PanelInportData.Controls.Add(this.ButtonOpenUnitDataGroup);
            this.PanelInportData.Controls.Add(this.DataGridViewUnitData);
            this.PanelInportData.Controls.Add(this.label4);
            this.PanelInportData.Controls.Add(this.ComboBoxModelName);
            this.PanelInportData.Controls.Add(this.label3);
            this.PanelInportData.Controls.Add(this.TextBoxStoreName);
            this.PanelInportData.Controls.Add(this.label2);
            this.PanelInportData.Controls.Add(this.ButtonReference);
            this.PanelInportData.Controls.Add(this.TextBoxHallDataFilePath);
            this.PanelInportData.Controls.Add(this.label1);
            this.PanelInportData.ForeColor = System.Drawing.Color.DimGray;
            this.PanelInportData.Location = new System.Drawing.Point(202, 1);
            this.PanelInportData.Name = "PanelInportData";
            this.PanelInportData.Size = new System.Drawing.Size(840, 708);
            this.PanelInportData.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(571, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 68;
            this.label5.Text = "データソース";
            // 
            // ComboBoxHallDataSource
            // 
            this.ComboBoxHallDataSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxHallDataSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxHallDataSource.DropDownWidth = 256;
            this.ComboBoxHallDataSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxHallDataSource.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxHallDataSource.ForeColor = System.Drawing.Color.White;
            this.ComboBoxHallDataSource.FormattingEnabled = true;
            this.ComboBoxHallDataSource.Location = new System.Drawing.Point(571, 71);
            this.ComboBoxHallDataSource.Name = "ComboBoxHallDataSource";
            this.ComboBoxHallDataSource.Size = new System.Drawing.Size(256, 23);
            this.ComboBoxHallDataSource.TabIndex = 67;
            this.ComboBoxHallDataSource.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxHallDataSource_SelectionChangeCommitted);
            // 
            // ChartDailyData
            // 
            this.ChartDailyData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            chartArea1.Name = "ChartArea1";
            this.ChartDailyData.ChartAreas.Add(chartArea1);
            this.ChartDailyData.Location = new System.Drawing.Point(15, 471);
            this.ChartDailyData.Name = "ChartDailyData";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.ChartDailyData.Series.Add(series1);
            this.ChartDailyData.Size = new System.Drawing.Size(632, 234);
            this.ChartDailyData.TabIndex = 65;
            this.ChartDailyData.Text = "ChartDailyData";
            // 
            // ButtonCloseUnitDataGroup
            // 
            this.ButtonCloseUnitDataGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.ButtonCloseUnitDataGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCloseUnitDataGroup.Enabled = false;
            this.ButtonCloseUnitDataGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonCloseUnitDataGroup.ForeColor = System.Drawing.Color.IndianRed;
            this.ButtonCloseUnitDataGroup.Location = new System.Drawing.Point(619, 111);
            this.ButtonCloseUnitDataGroup.Name = "ButtonCloseUnitDataGroup";
            this.ButtonCloseUnitDataGroup.Size = new System.Drawing.Size(22, 22);
            this.ButtonCloseUnitDataGroup.TabIndex = 64;
            this.ButtonCloseUnitDataGroup.Text = "▼";
            this.ButtonCloseUnitDataGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCloseUnitDataGroup.UseVisualStyleBackColor = false;
            this.ButtonCloseUnitDataGroup.Click += new System.EventHandler(this.ButtonCloseUnitDataGroup_Click);
            // 
            // ButtonInportHallData
            // 
            this.ButtonInportHallData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.ButtonInportHallData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonInportHallData.Enabled = false;
            this.ButtonInportHallData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonInportHallData.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonInportHallData.ForeColor = System.Drawing.Color.White;
            this.ButtonInportHallData.Location = new System.Drawing.Point(663, 638);
            this.ButtonInportHallData.Name = "ButtonInportHallData";
            this.ButtonInportHallData.Size = new System.Drawing.Size(154, 46);
            this.ButtonInportHallData.TabIndex = 61;
            this.ButtonInportHallData.Text = "ホールデータ読込み";
            this.ButtonInportHallData.UseVisualStyleBackColor = false;
            this.ButtonInportHallData.Click += new System.EventHandler(this.ButtonInportHallData_Click);
            // 
            // groupBoxColor1
            // 
            this.groupBoxColor1.BorderColor = System.Drawing.Color.DimGray;
            this.groupBoxColor1.Controls.Add(this.TextBoxProbVarHitProb);
            this.groupBoxColor1.Controls.Add(this.label12);
            this.groupBoxColor1.Controls.Add(this.TextBoxCTime);
            this.groupBoxColor1.Controls.Add(this.label11);
            this.groupBoxColor1.Controls.Add(this.TextBoxSavingTime);
            this.groupBoxColor1.Controls.Add(this.label10);
            this.groupBoxColor1.Controls.Add(this.TextBoxSpecialTime);
            this.groupBoxColor1.Controls.Add(this.label9);
            this.groupBoxColor1.Controls.Add(this.TextBoxProbVarHitPersisRate);
            this.groupBoxColor1.Controls.Add(this.label8);
            this.groupBoxColor1.Controls.Add(this.TextBoxProbVarHitRashRate);
            this.groupBoxColor1.Controls.Add(this.label7);
            this.groupBoxColor1.Controls.Add(this.label6);
            this.groupBoxColor1.Controls.Add(this.TextBoxFirstHitProb);
            this.groupBoxColor1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxColor1.ForeColor = System.Drawing.Color.White;
            this.groupBoxColor1.Location = new System.Drawing.Point(653, 118);
            this.groupBoxColor1.Name = "groupBoxColor1";
            this.groupBoxColor1.Size = new System.Drawing.Size(174, 350);
            this.groupBoxColor1.TabIndex = 66;
            this.groupBoxColor1.TabStop = false;
            this.groupBoxColor1.Text = "機種スペック";
            // 
            // TextBoxProbVarHitProb
            // 
            this.TextBoxProbVarHitProb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxProbVarHitProb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxProbVarHitProb.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxProbVarHitProb.ForeColor = System.Drawing.Color.White;
            this.TextBoxProbVarHitProb.Location = new System.Drawing.Point(10, 91);
            this.TextBoxProbVarHitProb.Name = "TextBoxProbVarHitProb";
            this.TextBoxProbVarHitProb.ReadOnly = true;
            this.TextBoxProbVarHitProb.Size = new System.Drawing.Size(154, 23);
            this.TextBoxProbVarHitProb.TabIndex = 76;
            this.TextBoxProbVarHitProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(10, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 75;
            this.label12.Text = "確変当り確率";
            // 
            // TextBoxCTime
            // 
            this.TextBoxCTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxCTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxCTime.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxCTime.ForeColor = System.Drawing.Color.White;
            this.TextBoxCTime.Location = new System.Drawing.Point(10, 311);
            this.TextBoxCTime.Name = "TextBoxCTime";
            this.TextBoxCTime.ReadOnly = true;
            this.TextBoxCTime.Size = new System.Drawing.Size(154, 23);
            this.TextBoxCTime.TabIndex = 74;
            this.TextBoxCTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(10, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 15);
            this.label11.TabIndex = 73;
            this.label11.Text = "CT";
            // 
            // TextBoxSavingTime
            // 
            this.TextBoxSavingTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxSavingTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxSavingTime.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxSavingTime.ForeColor = System.Drawing.Color.White;
            this.TextBoxSavingTime.Location = new System.Drawing.Point(10, 267);
            this.TextBoxSavingTime.Name = "TextBoxSavingTime";
            this.TextBoxSavingTime.ReadOnly = true;
            this.TextBoxSavingTime.Size = new System.Drawing.Size(154, 23);
            this.TextBoxSavingTime.TabIndex = 72;
            this.TextBoxSavingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(10, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 71;
            this.label10.Text = "時短";
            // 
            // TextBoxSpecialTime
            // 
            this.TextBoxSpecialTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxSpecialTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxSpecialTime.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxSpecialTime.ForeColor = System.Drawing.Color.White;
            this.TextBoxSpecialTime.Location = new System.Drawing.Point(10, 223);
            this.TextBoxSpecialTime.Name = "TextBoxSpecialTime";
            this.TextBoxSpecialTime.ReadOnly = true;
            this.TextBoxSpecialTime.Size = new System.Drawing.Size(154, 23);
            this.TextBoxSpecialTime.TabIndex = 70;
            this.TextBoxSpecialTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(10, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 15);
            this.label9.TabIndex = 69;
            this.label9.Text = "ST";
            // 
            // TextBoxProbVarHitPersisRate
            // 
            this.TextBoxProbVarHitPersisRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxProbVarHitPersisRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxProbVarHitPersisRate.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxProbVarHitPersisRate.ForeColor = System.Drawing.Color.White;
            this.TextBoxProbVarHitPersisRate.Location = new System.Drawing.Point(10, 179);
            this.TextBoxProbVarHitPersisRate.Name = "TextBoxProbVarHitPersisRate";
            this.TextBoxProbVarHitPersisRate.ReadOnly = true;
            this.TextBoxProbVarHitPersisRate.Size = new System.Drawing.Size(154, 23);
            this.TextBoxProbVarHitPersisRate.TabIndex = 68;
            this.TextBoxProbVarHitPersisRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(10, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 67;
            this.label8.Text = "確変継続率";
            // 
            // TextBoxProbVarHitRashRate
            // 
            this.TextBoxProbVarHitRashRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxProbVarHitRashRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxProbVarHitRashRate.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxProbVarHitRashRate.ForeColor = System.Drawing.Color.White;
            this.TextBoxProbVarHitRashRate.Location = new System.Drawing.Point(10, 135);
            this.TextBoxProbVarHitRashRate.Name = "TextBoxProbVarHitRashRate";
            this.TextBoxProbVarHitRashRate.ReadOnly = true;
            this.TextBoxProbVarHitRashRate.Size = new System.Drawing.Size(154, 23);
            this.TextBoxProbVarHitRashRate.TabIndex = 66;
            this.TextBoxProbVarHitRashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(10, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 65;
            this.label7.Text = "確変突入率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 64;
            this.label6.Text = "初当り確率";
            // 
            // TextBoxFirstHitProb
            // 
            this.TextBoxFirstHitProb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxFirstHitProb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxFirstHitProb.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxFirstHitProb.ForeColor = System.Drawing.Color.White;
            this.TextBoxFirstHitProb.Location = new System.Drawing.Point(10, 46);
            this.TextBoxFirstHitProb.Name = "TextBoxFirstHitProb";
            this.TextBoxFirstHitProb.ReadOnly = true;
            this.TextBoxFirstHitProb.Size = new System.Drawing.Size(154, 23);
            this.TextBoxFirstHitProb.TabIndex = 63;
            this.TextBoxFirstHitProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ButtonOpenUnitDataGroup
            // 
            this.ButtonOpenUnitDataGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.ButtonOpenUnitDataGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOpenUnitDataGroup.Enabled = false;
            this.ButtonOpenUnitDataGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonOpenUnitDataGroup.ForeColor = System.Drawing.Color.LimeGreen;
            this.ButtonOpenUnitDataGroup.Location = new System.Drawing.Point(591, 111);
            this.ButtonOpenUnitDataGroup.Name = "ButtonOpenUnitDataGroup";
            this.ButtonOpenUnitDataGroup.Size = new System.Drawing.Size(22, 22);
            this.ButtonOpenUnitDataGroup.TabIndex = 63;
            this.ButtonOpenUnitDataGroup.Text = "▲";
            this.ButtonOpenUnitDataGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonOpenUnitDataGroup.UseVisualStyleBackColor = false;
            this.ButtonOpenUnitDataGroup.Click += new System.EventHandler(this.ButtonOpenUnitDataGroup_Click);
            // 
            // DataGridViewUnitData
            // 
            this.DataGridViewUnitData.AllowUserToAddRows = false;
            this.DataGridViewUnitData.AllowUserToResizeColumns = false;
            this.DataGridViewUnitData.AllowUserToResizeRows = false;
            this.DataGridViewUnitData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.DataGridViewUnitData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewUnitData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewUnitData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewUnitData.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewUnitData.GridColor = System.Drawing.Color.DimGray;
            this.DataGridViewUnitData.Location = new System.Drawing.Point(21, 136);
            this.DataGridViewUnitData.Name = "DataGridViewUnitData";
            this.DataGridViewUnitData.ReadOnly = true;
            this.DataGridViewUnitData.RowHeadersVisible = false;
            this.DataGridViewUnitData.RowTemplate.Height = 21;
            this.DataGridViewUnitData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewUnitData.Size = new System.Drawing.Size(619, 318);
            this.DataGridViewUnitData.TabIndex = 60;
            this.DataGridViewUnitData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewUnitData_RowsAdded);
            this.DataGridViewUnitData.SelectionChanged += new System.EventHandler(this.DataGridViewUnitData_SelectionChanged);
            this.DataGridViewUnitData.Sorted += new System.EventHandler(this.DataGridViewUnitData_Sorted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 59;
            this.label4.Text = "台データ";
            // 
            // ComboBoxModelName
            // 
            this.ComboBoxModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxModelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxModelName.DropDownWidth = 256;
            this.ComboBoxModelName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxModelName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxModelName.ForeColor = System.Drawing.Color.White;
            this.ComboBoxModelName.FormattingEnabled = true;
            this.ComboBoxModelName.Location = new System.Drawing.Point(296, 71);
            this.ComboBoxModelName.Name = "ComboBoxModelName";
            this.ComboBoxModelName.Size = new System.Drawing.Size(256, 23);
            this.ComboBoxModelName.TabIndex = 58;
            this.ComboBoxModelName.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxModelName_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(296, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "機種名";
            // 
            // TextBoxStoreName
            // 
            this.TextBoxStoreName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxStoreName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxStoreName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxStoreName.ForeColor = System.Drawing.Color.White;
            this.TextBoxStoreName.Location = new System.Drawing.Point(21, 71);
            this.TextBoxStoreName.Name = "TextBoxStoreName";
            this.TextBoxStoreName.ReadOnly = true;
            this.TextBoxStoreName.Size = new System.Drawing.Size(256, 23);
            this.TextBoxStoreName.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 55;
            this.label2.Text = "店舗名";
            // 
            // ButtonReference
            // 
            this.ButtonReference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.ButtonReference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonReference.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonReference.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonReference.ForeColor = System.Drawing.Color.White;
            this.ButtonReference.Location = new System.Drawing.Point(752, 26);
            this.ButtonReference.Name = "ButtonReference";
            this.ButtonReference.Size = new System.Drawing.Size(75, 23);
            this.ButtonReference.TabIndex = 54;
            this.ButtonReference.Text = "参照";
            this.ButtonReference.UseVisualStyleBackColor = false;
            this.ButtonReference.Click += new System.EventHandler(this.ButtonReference_Click);
            // 
            // TextBoxHallDataFilePath
            // 
            this.TextBoxHallDataFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.TextBoxHallDataFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxHallDataFilePath.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxHallDataFilePath.ForeColor = System.Drawing.Color.White;
            this.TextBoxHallDataFilePath.Location = new System.Drawing.Point(21, 26);
            this.TextBoxHallDataFilePath.Name = "TextBoxHallDataFilePath";
            this.TextBoxHallDataFilePath.ReadOnly = true;
            this.TextBoxHallDataFilePath.Size = new System.Drawing.Size(725, 23);
            this.TextBoxHallDataFilePath.TabIndex = 53;
            this.TextBoxHallDataFilePath.TextChanged += new System.EventHandler(this.TextBoxHallDataFilePath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "ホールデータファイル";
            // 
            // PanelAnalyzeData
            // 
            this.PanelAnalyzeData.AutoScroll = true;
            this.PanelAnalyzeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAnalyzeData.Controls.Add(this.label15);
            this.PanelAnalyzeData.Controls.Add(this.ChartFirstHitCompProb);
            this.PanelAnalyzeData.Enabled = false;
            this.PanelAnalyzeData.ForeColor = System.Drawing.Color.DimGray;
            this.PanelAnalyzeData.Location = new System.Drawing.Point(202, 153);
            this.PanelAnalyzeData.Name = "PanelAnalyzeData";
            this.PanelAnalyzeData.Size = new System.Drawing.Size(840, 555);
            this.PanelAnalyzeData.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(20, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 15);
            this.label15.TabIndex = 72;
            this.label15.Text = "初当り合成確率推移";
            // 
            // ChartFirstHitCompProb
            // 
            this.ChartFirstHitCompProb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ChartFirstHitCompProb.BorderlineColor = System.Drawing.Color.DimGray;
            this.ChartFirstHitCompProb.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.ChartFirstHitCompProb.ChartAreas.Add(chartArea2);
            this.ChartFirstHitCompProb.Location = new System.Drawing.Point(20, 33);
            this.ChartFirstHitCompProb.Name = "ChartFirstHitCompProb";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.ChartFirstHitCompProb.Series.Add(series2);
            this.ChartFirstHitCompProb.Size = new System.Drawing.Size(760, 400);
            this.ChartFirstHitCompProb.TabIndex = 66;
            this.ChartFirstHitCompProb.Text = "ChartFirstHitCompProb";
            // 
            // PanelAnalyzeDataOperate
            // 
            this.PanelAnalyzeDataOperate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAnalyzeDataOperate.Controls.Add(this.groupBoxColor3);
            this.PanelAnalyzeDataOperate.Controls.Add(this.groupBoxColor2);
            this.PanelAnalyzeDataOperate.Controls.Add(this.label14);
            this.PanelAnalyzeDataOperate.Controls.Add(this.ComboBoxDispUnitNum);
            this.PanelAnalyzeDataOperate.Controls.Add(this.label13);
            this.PanelAnalyzeDataOperate.Controls.Add(this.ComboBoxDispModelName);
            this.PanelAnalyzeDataOperate.Enabled = false;
            this.PanelAnalyzeDataOperate.ForeColor = System.Drawing.Color.DimGray;
            this.PanelAnalyzeDataOperate.Location = new System.Drawing.Point(202, 1);
            this.PanelAnalyzeDataOperate.Name = "PanelAnalyzeDataOperate";
            this.PanelAnalyzeDataOperate.Size = new System.Drawing.Size(840, 153);
            this.PanelAnalyzeDataOperate.TabIndex = 62;
            // 
            // groupBoxColor3
            // 
            this.groupBoxColor3.BorderColor = System.Drawing.Color.DimGray;
            this.groupBoxColor3.Controls.Add(this.CheckBoxMA2Enable);
            this.groupBoxColor3.Controls.Add(this.label18);
            this.groupBoxColor3.Controls.Add(this.NumUpDownMA2SampleNum);
            this.groupBoxColor3.Controls.Add(this.label19);
            this.groupBoxColor3.Controls.Add(this.ComboBoxMA2Type);
            this.groupBoxColor3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxColor3.ForeColor = System.Drawing.Color.White;
            this.groupBoxColor3.Location = new System.Drawing.Point(357, 61);
            this.groupBoxColor3.Name = "groupBoxColor3";
            this.groupBoxColor3.Size = new System.Drawing.Size(331, 75);
            this.groupBoxColor3.TabIndex = 81;
            this.groupBoxColor3.TabStop = false;
            this.groupBoxColor3.Text = "移動平均線２";
            // 
            // CheckBoxMA2Enable
            // 
            this.CheckBoxMA2Enable.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxMA2Enable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.CheckBoxMA2Enable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckBoxMA2Enable.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxMA2Enable.ForeColor = System.Drawing.Color.White;
            this.CheckBoxMA2Enable.Location = new System.Drawing.Point(276, 41);
            this.CheckBoxMA2Enable.Name = "CheckBoxMA2Enable";
            this.CheckBoxMA2Enable.Size = new System.Drawing.Size(43, 23);
            this.CheckBoxMA2Enable.TabIndex = 81;
            this.CheckBoxMA2Enable.Text = "OFF";
            this.CheckBoxMA2Enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxMA2Enable.UseVisualStyleBackColor = false;
            this.CheckBoxMA2Enable.CheckedChanged += new System.EventHandler(this.CheckBoxMA2Enable_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(143, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 15);
            this.label18.TabIndex = 79;
            this.label18.Text = "標本数";
            // 
            // NumUpDownMA2SampleNum
            // 
            this.NumUpDownMA2SampleNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.NumUpDownMA2SampleNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumUpDownMA2SampleNum.ForeColor = System.Drawing.Color.White;
            this.NumUpDownMA2SampleNum.Location = new System.Drawing.Point(143, 41);
            this.NumUpDownMA2SampleNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownMA2SampleNum.Name = "NumUpDownMA2SampleNum";
            this.NumUpDownMA2SampleNum.Size = new System.Drawing.Size(120, 23);
            this.NumUpDownMA2SampleNum.TabIndex = 78;
            this.NumUpDownMA2SampleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumUpDownMA2SampleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownMA2SampleNum.ValueChanged += new System.EventHandler(this.NumUpDownMA2SampleNum_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(12, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 15);
            this.label19.TabIndex = 77;
            this.label19.Text = "種別";
            // 
            // ComboBoxMA2Type
            // 
            this.ComboBoxMA2Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxMA2Type.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxMA2Type.DropDownWidth = 256;
            this.ComboBoxMA2Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxMA2Type.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxMA2Type.ForeColor = System.Drawing.Color.White;
            this.ComboBoxMA2Type.FormattingEnabled = true;
            this.ComboBoxMA2Type.Location = new System.Drawing.Point(12, 41);
            this.ComboBoxMA2Type.Name = "ComboBoxMA2Type";
            this.ComboBoxMA2Type.Size = new System.Drawing.Size(120, 23);
            this.ComboBoxMA2Type.TabIndex = 76;
            this.ComboBoxMA2Type.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxMA2Type_SelectionChangeCommitted);
            // 
            // groupBoxColor2
            // 
            this.groupBoxColor2.BorderColor = System.Drawing.Color.DimGray;
            this.groupBoxColor2.Controls.Add(this.CheckBoxMA1Enable);
            this.groupBoxColor2.Controls.Add(this.label17);
            this.groupBoxColor2.Controls.Add(this.NumUpDownMA1SampleNum);
            this.groupBoxColor2.Controls.Add(this.label16);
            this.groupBoxColor2.Controls.Add(this.ComboBoxMA1Type);
            this.groupBoxColor2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxColor2.ForeColor = System.Drawing.Color.White;
            this.groupBoxColor2.Location = new System.Drawing.Point(11, 61);
            this.groupBoxColor2.Name = "groupBoxColor2";
            this.groupBoxColor2.Size = new System.Drawing.Size(331, 75);
            this.groupBoxColor2.TabIndex = 80;
            this.groupBoxColor2.TabStop = false;
            this.groupBoxColor2.Text = "移動平均線１";
            // 
            // CheckBoxMA1Enable
            // 
            this.CheckBoxMA1Enable.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxMA1Enable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.CheckBoxMA1Enable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckBoxMA1Enable.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckBoxMA1Enable.ForeColor = System.Drawing.Color.White;
            this.CheckBoxMA1Enable.Location = new System.Drawing.Point(276, 41);
            this.CheckBoxMA1Enable.Name = "CheckBoxMA1Enable";
            this.CheckBoxMA1Enable.Size = new System.Drawing.Size(43, 23);
            this.CheckBoxMA1Enable.TabIndex = 80;
            this.CheckBoxMA1Enable.Text = "OFF";
            this.CheckBoxMA1Enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxMA1Enable.UseVisualStyleBackColor = false;
            this.CheckBoxMA1Enable.CheckedChanged += new System.EventHandler(this.CheckBoxMA1Enable_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(144, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 15);
            this.label17.TabIndex = 79;
            this.label17.Text = "標本数";
            // 
            // NumUpDownMA1SampleNum
            // 
            this.NumUpDownMA1SampleNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.NumUpDownMA1SampleNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumUpDownMA1SampleNum.ForeColor = System.Drawing.Color.White;
            this.NumUpDownMA1SampleNum.Location = new System.Drawing.Point(144, 41);
            this.NumUpDownMA1SampleNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownMA1SampleNum.Name = "NumUpDownMA1SampleNum";
            this.NumUpDownMA1SampleNum.Size = new System.Drawing.Size(120, 23);
            this.NumUpDownMA1SampleNum.TabIndex = 78;
            this.NumUpDownMA1SampleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumUpDownMA1SampleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownMA1SampleNum.ValueChanged += new System.EventHandler(this.NumUpDownMA1SampleNum_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(12, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 15);
            this.label16.TabIndex = 77;
            this.label16.Text = "種別";
            // 
            // ComboBoxMA1Type
            // 
            this.ComboBoxMA1Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxMA1Type.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxMA1Type.DropDownWidth = 256;
            this.ComboBoxMA1Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxMA1Type.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxMA1Type.ForeColor = System.Drawing.Color.White;
            this.ComboBoxMA1Type.FormattingEnabled = true;
            this.ComboBoxMA1Type.Location = new System.Drawing.Point(12, 41);
            this.ComboBoxMA1Type.Name = "ComboBoxMA1Type";
            this.ComboBoxMA1Type.Size = new System.Drawing.Size(120, 23);
            this.ComboBoxMA1Type.TabIndex = 76;
            this.ComboBoxMA1Type.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxMA1Type_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(287, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 15);
            this.label14.TabIndex = 75;
            this.label14.Text = "台番号";
            // 
            // ComboBoxDispUnitNum
            // 
            this.ComboBoxDispUnitNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxDispUnitNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxDispUnitNum.DropDownWidth = 256;
            this.ComboBoxDispUnitNum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxDispUnitNum.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxDispUnitNum.ForeColor = System.Drawing.Color.White;
            this.ComboBoxDispUnitNum.FormattingEnabled = true;
            this.ComboBoxDispUnitNum.Location = new System.Drawing.Point(286, 26);
            this.ComboBoxDispUnitNum.Name = "ComboBoxDispUnitNum";
            this.ComboBoxDispUnitNum.Size = new System.Drawing.Size(256, 23);
            this.ComboBoxDispUnitNum.TabIndex = 74;
            this.ComboBoxDispUnitNum.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxDispUnitNum_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 73;
            this.label13.Text = "機種名";
            // 
            // ComboBoxDispModelName
            // 
            this.ComboBoxDispModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.ComboBoxDispModelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxDispModelName.DropDownWidth = 256;
            this.ComboBoxDispModelName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxDispModelName.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxDispModelName.ForeColor = System.Drawing.Color.White;
            this.ComboBoxDispModelName.FormattingEnabled = true;
            this.ComboBoxDispModelName.Location = new System.Drawing.Point(11, 26);
            this.ComboBoxDispModelName.Name = "ComboBoxDispModelName";
            this.ComboBoxDispModelName.Size = new System.Drawing.Size(256, 23);
            this.ComboBoxDispModelName.TabIndex = 72;
            this.ComboBoxDispModelName.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxDispModelName_SelectionChangeCommitted);
            // 
            // ButtonDispInportDataPanel
            // 
            this.ButtonDispInportDataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.ButtonDispInportDataPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDispInportDataPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonDispInportDataPanel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDispInportDataPanel.ForeColor = System.Drawing.Color.White;
            this.ButtonDispInportDataPanel.Location = new System.Drawing.Point(1, 1);
            this.ButtonDispInportDataPanel.Name = "ButtonDispInportDataPanel";
            this.ButtonDispInportDataPanel.Size = new System.Drawing.Size(200, 70);
            this.ButtonDispInportDataPanel.TabIndex = 55;
            this.ButtonDispInportDataPanel.Text = "データ入力";
            this.ButtonDispInportDataPanel.UseVisualStyleBackColor = false;
            this.ButtonDispInportDataPanel.Click += new System.EventHandler(this.ButtonDispInportDataPanel_Click);
            // 
            // ButtonDispAnalyzeDataPanel
            // 
            this.ButtonDispAnalyzeDataPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.ButtonDispAnalyzeDataPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDispAnalyzeDataPanel.Enabled = false;
            this.ButtonDispAnalyzeDataPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonDispAnalyzeDataPanel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDispAnalyzeDataPanel.ForeColor = System.Drawing.Color.White;
            this.ButtonDispAnalyzeDataPanel.Location = new System.Drawing.Point(1, 72);
            this.ButtonDispAnalyzeDataPanel.Name = "ButtonDispAnalyzeDataPanel";
            this.ButtonDispAnalyzeDataPanel.Size = new System.Drawing.Size(200, 70);
            this.ButtonDispAnalyzeDataPanel.TabIndex = 56;
            this.ButtonDispAnalyzeDataPanel.Text = "データ分析";
            this.ButtonDispAnalyzeDataPanel.UseVisualStyleBackColor = false;
            this.ButtonDispAnalyzeDataPanel.Click += new System.EventHandler(this.ButtonDispAnalyzeDataPanel_Click);
            // 
            // ButtonDispExportReportPanel
            // 
            this.ButtonDispExportReportPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.ButtonDispExportReportPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDispExportReportPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonDispExportReportPanel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDispExportReportPanel.ForeColor = System.Drawing.Color.White;
            this.ButtonDispExportReportPanel.Location = new System.Drawing.Point(1, 143);
            this.ButtonDispExportReportPanel.Name = "ButtonDispExportReportPanel";
            this.ButtonDispExportReportPanel.Size = new System.Drawing.Size(200, 70);
            this.ButtonDispExportReportPanel.TabIndex = 57;
            this.ButtonDispExportReportPanel.Text = "レポート出力";
            this.ButtonDispExportReportPanel.UseVisualStyleBackColor = false;
            this.ButtonDispExportReportPanel.Click += new System.EventHandler(this.ButtonDispExportReportPanel_Click);
            // 
            // ButtonDispUserSettingsPanel
            // 
            this.ButtonDispUserSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.ButtonDispUserSettingsPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDispUserSettingsPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonDispUserSettingsPanel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonDispUserSettingsPanel.ForeColor = System.Drawing.Color.White;
            this.ButtonDispUserSettingsPanel.Location = new System.Drawing.Point(1, 639);
            this.ButtonDispUserSettingsPanel.Name = "ButtonDispUserSettingsPanel";
            this.ButtonDispUserSettingsPanel.Size = new System.Drawing.Size(200, 70);
            this.ButtonDispUserSettingsPanel.TabIndex = 58;
            this.ButtonDispUserSettingsPanel.Text = "設定";
            this.ButtonDispUserSettingsPanel.UseVisualStyleBackColor = false;
            this.ButtonDispUserSettingsPanel.Click += new System.EventHandler(this.ButtonDispUserSettingsPanel_Click);
            // 
            // PanelExportReport
            // 
            this.PanelExportReport.Controls.Add(this.label_PanelExportReport);
            this.PanelExportReport.Location = new System.Drawing.Point(1394, 1);
            this.PanelExportReport.Name = "PanelExportReport";
            this.PanelExportReport.Size = new System.Drawing.Size(340, 693);
            this.PanelExportReport.TabIndex = 60;
            // 
            // label_PanelExportReport
            // 
            this.label_PanelExportReport.AutoSize = true;
            this.label_PanelExportReport.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_PanelExportReport.Location = new System.Drawing.Point(105, 306);
            this.label_PanelExportReport.Name = "label_PanelExportReport";
            this.label_PanelExportReport.Size = new System.Drawing.Size(148, 42);
            this.label_PanelExportReport.TabIndex = 1;
            this.label_PanelExportReport.Text = "PanelExportReport\r\n開発中";
            this.label_PanelExportReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelUserSettings
            // 
            this.PanelUserSettings.Controls.Add(this.label_PanelUserSettings);
            this.PanelUserSettings.Location = new System.Drawing.Point(1740, 1);
            this.PanelUserSettings.Name = "PanelUserSettings";
            this.PanelUserSettings.Size = new System.Drawing.Size(340, 708);
            this.PanelUserSettings.TabIndex = 61;
            // 
            // label_PanelUserSettings
            // 
            this.label_PanelUserSettings.AutoSize = true;
            this.label_PanelUserSettings.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_PanelUserSettings.Location = new System.Drawing.Point(100, 306);
            this.label_PanelUserSettings.Name = "label_PanelUserSettings";
            this.label_PanelUserSettings.Size = new System.Drawing.Size(142, 42);
            this.label_PanelUserSettings.TabIndex = 2;
            this.label_PanelUserSettings.Text = "PanelUserSettings\r\n開発中";
            this.label_PanelUserSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(2085, 711);
            this.Controls.Add(this.PanelAnalyzeDataOperate);
            this.Controls.Add(this.PanelAnalyzeData);
            this.Controls.Add(this.PanelUserSettings);
            this.Controls.Add(this.PanelExportReport);
            this.Controls.Add(this.ButtonDispUserSettingsPanel);
            this.Controls.Add(this.ButtonDispExportReportPanel);
            this.Controls.Add(this.ButtonDispAnalyzeDataPanel);
            this.Controls.Add(this.ButtonDispInportDataPanel);
            this.Controls.Add(this.PanelInportData);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximumSize = new System.Drawing.Size(2101, 750);
            this.MinimumSize = new System.Drawing.Size(1060, 750);
            this.Name = "FormMain";
            this.Text = "ExpAnalyzer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.PanelInportData.ResumeLayout(false);
            this.PanelInportData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartDailyData)).EndInit();
            this.groupBoxColor1.ResumeLayout(false);
            this.groupBoxColor1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUnitData)).EndInit();
            this.PanelAnalyzeData.ResumeLayout(false);
            this.PanelAnalyzeData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartFirstHitCompProb)).EndInit();
            this.PanelAnalyzeDataOperate.ResumeLayout(false);
            this.PanelAnalyzeDataOperate.PerformLayout();
            this.groupBoxColor3.ResumeLayout(false);
            this.groupBoxColor3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMA2SampleNum)).EndInit();
            this.groupBoxColor2.ResumeLayout(false);
            this.groupBoxColor2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownMA1SampleNum)).EndInit();
            this.PanelExportReport.ResumeLayout(false);
            this.PanelExportReport.PerformLayout();
            this.PanelUserSettings.ResumeLayout(false);
            this.PanelUserSettings.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartDailyData;
        private System.Windows.Forms.Button ButtonCloseUnitDataGroup;
        private System.Windows.Forms.Button ButtonInportHallData;
        private Views.GroupBoxColor groupBoxColor1;
        private System.Windows.Forms.TextBox TextBoxProbVarHitProb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextBoxCTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxSavingTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBoxSpecialTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBoxProbVarHitPersisRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxProbVarHitRashRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxFirstHitProb;
        private System.Windows.Forms.Button ButtonOpenUnitDataGroup;
        protected System.Windows.Forms.DataGridView DataGridViewUnitData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboBoxModelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxStoreName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonReference;
        protected System.Windows.Forms.TextBox TextBoxHallDataFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonDispInportDataPanel;
        private System.Windows.Forms.Button ButtonDispAnalyzeDataPanel;
        private System.Windows.Forms.Button ButtonDispExportReportPanel;
        private System.Windows.Forms.Button ButtonDispUserSettingsPanel;
        internal System.Windows.Forms.Panel PanelInportData;
        internal System.Windows.Forms.Panel PanelAnalyzeData;
        internal System.Windows.Forms.Panel PanelExportReport;
        internal System.Windows.Forms.Panel PanelUserSettings;
        private System.Windows.Forms.Label label_PanelExportReport;
        private System.Windows.Forms.Label label_PanelUserSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxHallDataSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartFirstHitCompProb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel PanelAnalyzeDataOperate;
        private System.Windows.Forms.ComboBox ComboBoxMA1Type;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ComboBoxDispUnitNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ComboBoxDispModelName;
        private System.Windows.Forms.Label label16;
        private Views.GroupBoxColor groupBoxColor2;
        private System.Windows.Forms.NumericUpDown NumUpDownMA1SampleNum;
        private System.Windows.Forms.Label label17;
        private Views.GroupBoxColor groupBoxColor3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown NumUpDownMA2SampleNum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox ComboBoxMA2Type;
        private System.Windows.Forms.CheckBox CheckBoxMA2Enable;
        private System.Windows.Forms.CheckBox CheckBoxMA1Enable;
    }
}

