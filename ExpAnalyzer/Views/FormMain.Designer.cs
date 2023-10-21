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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonAnalysData = new System.Windows.Forms.Button();
            this.TextBoxProbVarHitPersisRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxProbVarHitRashRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxFirstHitProb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonReadExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBoxModelName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxStoreName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonReference = new System.Windows.Forms.Button();
            this.TextBoxReadExcelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridViewUnitData = new System.Windows.Forms.DataGridView();
            this.ButtonOpenGroup = new System.Windows.Forms.Button();
            this.ButtonCloseGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUnitData)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonAnalysData
            // 
            this.ButtonAnalysData.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonAnalysData.Location = new System.Drawing.Point(648, 515);
            this.ButtonAnalysData.Name = "ButtonAnalysData";
            this.ButtonAnalysData.Size = new System.Drawing.Size(160, 46);
            this.ButtonAnalysData.TabIndex = 38;
            this.ButtonAnalysData.Text = "データ解析/レポート出力";
            this.ButtonAnalysData.UseVisualStyleBackColor = true;
            // 
            // TextBoxProbVarHitPersisRate
            // 
            this.TextBoxProbVarHitPersisRate.Location = new System.Drawing.Point(648, 262);
            this.TextBoxProbVarHitPersisRate.Name = "TextBoxProbVarHitPersisRate";
            this.TextBoxProbVarHitPersisRate.Size = new System.Drawing.Size(155, 19);
            this.TextBoxProbVarHitPersisRate.TabIndex = 36;
            this.TextBoxProbVarHitPersisRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(648, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "確変継続率";
            // 
            // TextBoxProbVarHitRashRate
            // 
            this.TextBoxProbVarHitRashRate.Location = new System.Drawing.Point(648, 217);
            this.TextBoxProbVarHitRashRate.Name = "TextBoxProbVarHitRashRate";
            this.TextBoxProbVarHitRashRate.Size = new System.Drawing.Size(155, 19);
            this.TextBoxProbVarHitRashRate.TabIndex = 34;
            this.TextBoxProbVarHitRashRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(648, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "確変突入率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(648, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "初当り確率";
            // 
            // TextBoxFirstHitProb
            // 
            this.TextBoxFirstHitProb.Location = new System.Drawing.Point(648, 172);
            this.TextBoxFirstHitProb.Name = "TextBoxFirstHitProb";
            this.TextBoxFirstHitProb.Size = new System.Drawing.Size(155, 19);
            this.TextBoxFirstHitProb.TabIndex = 31;
            this.TextBoxFirstHitProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(645, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "台スペック";
            // 
            // ButtonReadExcel
            // 
            this.ButtonReadExcel.Enabled = false;
            this.ButtonReadExcel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonReadExcel.Location = new System.Drawing.Point(648, 454);
            this.ButtonReadExcel.Name = "ButtonReadExcel";
            this.ButtonReadExcel.Size = new System.Drawing.Size(160, 46);
            this.ButtonReadExcel.TabIndex = 37;
            this.ButtonReadExcel.Text = "Excelデータ読み込み";
            this.ButtonReadExcel.UseVisualStyleBackColor = true;
            this.ButtonReadExcel.Click += new System.EventHandler(this.ButtonReadExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "台データ";
            // 
            // ComboBoxModelName
            // 
            this.ComboBoxModelName.BackColor = System.Drawing.Color.White;
            this.ComboBoxModelName.FormattingEnabled = true;
            this.ComboBoxModelName.Location = new System.Drawing.Point(289, 71);
            this.ComboBoxModelName.Name = "ComboBoxModelName";
            this.ComboBoxModelName.Size = new System.Drawing.Size(262, 20);
            this.ComboBoxModelName.TabIndex = 27;
            this.ComboBoxModelName.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxModelName_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(290, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "機種名";
            // 
            // TextBoxStoreName
            // 
            this.TextBoxStoreName.Location = new System.Drawing.Point(12, 72);
            this.TextBoxStoreName.Name = "TextBoxStoreName";
            this.TextBoxStoreName.ReadOnly = true;
            this.TextBoxStoreName.Size = new System.Drawing.Size(262, 19);
            this.TextBoxStoreName.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "店舗名";
            // 
            // ButtonReference
            // 
            this.ButtonReference.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonReference.Location = new System.Drawing.Point(557, 25);
            this.ButtonReference.Name = "ButtonReference";
            this.ButtonReference.Size = new System.Drawing.Size(75, 23);
            this.ButtonReference.TabIndex = 23;
            this.ButtonReference.Text = "参照";
            this.ButtonReference.UseVisualStyleBackColor = true;
            this.ButtonReference.Click += new System.EventHandler(this.ButtonReference_Click);
            // 
            // TextBoxReadExcelPath
            // 
            this.TextBoxReadExcelPath.Location = new System.Drawing.Point(12, 28);
            this.TextBoxReadExcelPath.Name = "TextBoxReadExcelPath";
            this.TextBoxReadExcelPath.ReadOnly = true;
            this.TextBoxReadExcelPath.Size = new System.Drawing.Size(539, 19);
            this.TextBoxReadExcelPath.TabIndex = 22;
            this.TextBoxReadExcelPath.TextChanged += new System.EventHandler(this.TextBoxReadExcelPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "読み込みExcelデータファイル";
            // 
            // DataGridViewUnitData
            // 
            this.DataGridViewUnitData.AllowUserToAddRows = false;
            this.DataGridViewUnitData.AllowUserToResizeColumns = false;
            this.DataGridViewUnitData.AllowUserToResizeRows = false;
            this.DataGridViewUnitData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewUnitData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewUnitData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewUnitData.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridViewUnitData.Location = new System.Drawing.Point(12, 123);
            this.DataGridViewUnitData.Name = "DataGridViewUnitData";
            this.DataGridViewUnitData.ReadOnly = true;
            this.DataGridViewUnitData.RowHeadersVisible = false;
            this.DataGridViewUnitData.RowTemplate.Height = 21;
            this.DataGridViewUnitData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewUnitData.Size = new System.Drawing.Size(620, 318);
            this.DataGridViewUnitData.TabIndex = 29;
            this.DataGridViewUnitData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewUnitData_RowsAdded);
            this.DataGridViewUnitData.Sorted += new System.EventHandler(this.DataGridViewUnitData_Sorted);
            // 
            // ButtonOpenGroup
            // 
            this.ButtonOpenGroup.Enabled = false;
            this.ButtonOpenGroup.Location = new System.Drawing.Point(582, 98);
            this.ButtonOpenGroup.Name = "ButtonOpenGroup";
            this.ButtonOpenGroup.Size = new System.Drawing.Size(22, 22);
            this.ButtonOpenGroup.TabIndex = 39;
            this.ButtonOpenGroup.Text = "▲";
            this.ButtonOpenGroup.UseVisualStyleBackColor = true;
            this.ButtonOpenGroup.Click += new System.EventHandler(this.ButtonOpenGroup_Click);
            // 
            // ButtonCloseGroup
            // 
            this.ButtonCloseGroup.Enabled = false;
            this.ButtonCloseGroup.Location = new System.Drawing.Point(610, 98);
            this.ButtonCloseGroup.Name = "ButtonCloseGroup";
            this.ButtonCloseGroup.Size = new System.Drawing.Size(22, 22);
            this.ButtonCloseGroup.TabIndex = 40;
            this.ButtonCloseGroup.Text = "▼";
            this.ButtonCloseGroup.UseVisualStyleBackColor = true;
            this.ButtonCloseGroup.Click += new System.EventHandler(this.ButtonCloseGroup_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 573);
            this.Controls.Add(this.ButtonCloseGroup);
            this.Controls.Add(this.ButtonOpenGroup);
            this.Controls.Add(this.ButtonAnalysData);
            this.Controls.Add(this.TextBoxProbVarHitPersisRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TextBoxProbVarHitRashRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBoxFirstHitProb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ButtonReadExcel);
            this.Controls.Add(this.DataGridViewUnitData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboBoxModelName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxStoreName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonReference);
            this.Controls.Add(this.TextBoxReadExcelPath);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "ExpAnalyzer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUnitData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button ButtonAnalysData;
        private System.Windows.Forms.TextBox TextBoxProbVarHitPersisRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxProbVarHitRashRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxFirstHitProb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonReadExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboBoxModelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxStoreName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonReference;
        private System.Windows.Forms.TextBox TextBoxReadExcelPath;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DataGridView DataGridViewUnitData;
        private System.Windows.Forms.Button ButtonOpenGroup;
        private System.Windows.Forms.Button ButtonCloseGroup;
    }
}

