﻿using ExpAnalyzer.Controller.Calculate;
using ExpAnalyzer.Controller.Common;
using ExpAnalyzer.Controller.GlaphMapping;
using ExpAnalyzer.Controller.Inport;
using ExpAnalyzer.Models;
using Subro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpAnalyzer
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 参照ボタンクリックイベント
        /// </summary>
        private void ButtonReference_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenFileダイアログ表示
                OpenFileDialog Ofd = new OpenFileDialog();

                Ofd.FileName = "";
                Ofd.InitialDirectory = @"%UserProfile%\Documents";
                Ofd.Filter = "Excelブック(*.xlsx)|*.xlsx|Excelマクロ有効ブック(*.xlsm)|*.xlsm|すべてのファイル(*.*)|*.*";
                Ofd.FilterIndex = 1;
                Ofd.Title = "読込むファイルを選択してください";
                Ofd.RestoreDirectory = true;
                Ofd.CheckFileExists = true;
                Ofd.CheckPathExists = true;

                if (Ofd.ShowDialog() == DialogResult.OK)
                {
                    CommonVariableDefine = new ClassCommonVariableDefine();

                    CommonVariableDefine.HallDataFilePath = Ofd.FileName;
                    this.TextBoxHallDataFilePath.Text = Ofd.FileName;
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// ホールデータ読込みボタンクリックイベント
        /// </summary>
        private void ButtonInportHallData_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CommonVariableDefine.HallDataFilePath) == true)
                {
                    ClassInportHallDataFile InportHallDataFile = new ClassInportHallDataFile();
                    ClassUnitDataOnDataGridView UnitDataOnDataGridView = new ClassUnitDataOnDataGridView();
                    ClassDailyDataOnChart DailyDataOnChart = new ClassDailyDataOnChart();
                    ClassModelSpecDataOnTextBox ModelSpecDataOnTextBox = new ClassModelSpecDataOnTextBox();
                    ClassModelDataOnComboBox ModelDataOnComboBox = new ClassModelDataOnComboBox();
                    ClassFormattingHallData FormattingHallData = new ClassFormattingHallData();

                    //Excelからホールデータを読込み
                    HallData = InportHallDataFile.InportHallDataFromExcel(CommonVariableDefine.HallDataFilePath);

                    //店舗名をテキストボックスへ表示
                    this.TextBoxStoreName.Text = HallData.HallName;

                    //機種データをコンボボックスへ表示
                    ModelDataOnComboBox.DispModelDataOnComboBox(this.ComboBoxModelName);

                    if (DataGridViewUnitDataGrouper != null)
                    {
                        //DataGridViewグループのリソース解放
                        DataGridViewUnitDataGrouper.Dispose();
                    }
                    //テキストボックスへ機種スペック情報を表示
                    ModelSpecDataOnTextBox.DispModelSpecDataOnTextBox(
                        this.TextBoxFirstHitProb,
                        this.TextBoxProbVarHitProb,
                        this.TextBoxProbVarHitRashRate,
                        this.TextBoxProbVarHitPersisRate,
                        this.TextBoxSpecialTime,
                        this.TextBoxSavingTime,
                        this.TextBoxCTime,
                        ModelSpecDataList,
                        this.ComboBoxModelName.SelectedItem.ToString());

                    //台データをDataGridViewへ表示
                    DataGridViewUnitDataGrouper = UnitDataOnDataGridView.DispUnitDataOnDataGridView(
                        this.DataGridViewUnitData,
                        this.ButtonOpenUnitDataGroup,
                        this.ButtonCloseUnitDataGroup,
                        this.ComboBoxModelName.SelectedItem.ToString());

                    //選択機種の先頭日の履歴データをグラフへ表示
                    this.DataGridViewUnitData.Rows[1].Selected = true;

                    if (DataGridViewUnitDataGrouper != null)
                    {
                        //Excelデータ読み込みボタン無効化
                        this.ButtonInportHallData.Enabled = false;

                        //DataGridView操作ボタン有効化
                        this.ButtonOpenUnitDataGroup.Enabled = true;
                        this.ButtonCloseUnitDataGroup.Enabled = true;
                    }
                    //ホールデータの整形

                    FormatHallData = FormattingHallData.FormattingHallData(this.ComboBoxHallDataSource.SelectedItem.ToString());

                    if (FormatHallData != null)
                    {
                        //データ分析ボタン有効化
                        this.ButtonDispAnalyzeDataPanel.Enabled = true;
                    }
                }
                else
                {
                    throw new Exception("指定されたExcelデータファイルが存在しません。");
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// テキストボックス(ホールデータファイル)テキスト変更イベント
        /// </summary>
        private void TextBoxHallDataFilePath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TextBoxHallDataFilePath.Text != null && this.TextBoxHallDataFilePath.Text != "")
                {
                    //Excelデータ読み込みボタン有効化
                    this.ButtonInportHallData.Enabled = true;
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// コンボボックス(機種名)選択アイテム変更イベント
        /// </summary>
        private void ComboBoxModelName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassUnitDataOnDataGridView UnitDataOnDataGridView = new ClassUnitDataOnDataGridView();
                ClassModelSpecDataOnTextBox ModelSpecDataOnTextBox = new ClassModelSpecDataOnTextBox();

                //DataGridViewグループのリソース解放
                DataGridViewUnitDataGrouper.Dispose();

                //テキストボックスへ機種スペックデータを表示
                ModelSpecDataOnTextBox.DispModelSpecDataOnTextBox(
                    this.TextBoxFirstHitProb,
                    this.TextBoxProbVarHitProb,
                    this.TextBoxProbVarHitRashRate,
                    this.TextBoxProbVarHitPersisRate,
                    this.TextBoxSpecialTime,
                    this.TextBoxSavingTime,
                    this.TextBoxCTime,
                    ModelSpecDataList,
                    this.ComboBoxModelName.SelectedItem.ToString());

                //台データをDataGridViewへ表示
                DataGridViewUnitDataGrouper = UnitDataOnDataGridView.DispUnitDataOnDataGridView(
                    this.DataGridViewUnitData,
                    this.ButtonOpenUnitDataGroup,
                    this.ButtonCloseUnitDataGroup,
                    this.ComboBoxModelName.SelectedItem.ToString());

                //選択機種の先頭日の履歴データをグラフへ表示
                this.DataGridViewUnitData.Rows[1].Selected = true;
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// コンボボックス(データソース)選択アイテム変更イベント
        /// </summary>
        private void ComboBoxHallDataSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.TextBoxHallDataFilePath.Text != null && this.TextBoxHallDataFilePath.Text != "")
                {
                    //Excelデータ読み込みボタン有効化
                    this.ButtonInportHallData.Enabled = true;
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// 台データグループ開くボタンクリックイベント
        /// </summary>
        private void ButtonOpenUnitDataGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //表示中のグループを全て開く
                DataGridViewUnitDataGrouper.ExpandAll();

                //選択されているセルの行ごと色変更
                DataGridViewSelectedCellCollection SelectedCell = this.DataGridViewUnitData.SelectedCells;
                this.DataGridViewUnitData.Rows[SelectedCell[0].RowIndex].Selected = true;
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// 台データグループ閉じるボタンクリックイベント
        /// </summary>
        private void ButtonCloseUnitDataGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //表示中のグループを全て閉じる
                DataGridViewUnitDataGrouper.CollapseAll();
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// DataGridView行追加イベント
        /// </summary>
        private void DataGridViewUnitData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                ClassUnitDataOnDataGridView UnitDataOnDataGridView = new ClassUnitDataOnDataGridView();

                //DataGridViewの表示設定(更新)
                UnitDataOnDataGridView.SetDataGridViewDisplaySetting(this.DataGridViewUnitData);
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// DataGridViewソートイベント
        /// </summary>
        private void DataGridViewUnitData_Sorted(object sender, EventArgs e)
        {
            try
            {
                ClassUnitDataOnDataGridView UnitDataOnDataGridView = new ClassUnitDataOnDataGridView();

                //DataGridViewの表示設定(更新)
                UnitDataOnDataGridView.SetDataGridViewDisplaySetting(this.DataGridViewUnitData);
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// DataGridView選択セル変更イベント
        /// </summary>
        private void DataGridViewUnitData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DataGridViewUnitData.SelectedCells.Count > 0
                    && this.DataGridViewUnitData.SelectedCells[0].RowIndex > 0
                    && this.DataGridViewUnitData.SelectedCells[0].ColumnIndex != -1
                    && this.DataGridViewUnitData.SelectedCells[0].Value != null)
                {
                    ClassDailyDataOnChart DailyDataOnChart = new ClassDailyDataOnChart();
                    int row = this.DataGridViewUnitData.SelectedCells[0].RowIndex;

                    if (this.DataGridViewUnitData.Rows[row].Cells[1].Value != null)
                    {
                        //選択されているセルの行ごと色変更
                        this.DataGridViewUnitData.Rows[row].Selected = true;

                        //機種名
                        string modelName = this.ComboBoxModelName.SelectedItem.ToString();

                        //台番号
                        string unitNum = Convert.ToString(this.DataGridViewUnitData.Rows[row].Cells[0].Value);

                        //日付
                        string dateTime = Convert.ToString(this.DataGridViewUnitData.Rows[row].Cells[1].Value);

                        //デイリーデータをグラフへ表示
                        DailyDataOnChart.DispDailyDataOnChart(this.ChartDailyData, modelName, unitNum, dateTime);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }
    }
}
