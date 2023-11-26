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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpAnalyzer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        #region 静的フィールド
        //共通変数
        private static ClassCommonVariableDefine CommonVariableDefine;
        //ホールデータ
        internal static ClassHallData HallData;
        //機種スペックデータ
        private static List<ClassModelSpecData> ModelSpecDataList;
        //DataGridViewGrouper(台データ)
        private static Subro.Controls.DataGridViewGrouper DataGridViewUnitDataGrouper = null;
        #endregion

        /// <summary>
        /// メインフォームロードイベント
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                ClassDispDailyData DispDailyData = new ClassDispDailyData();
                ClassReadInitializeFile ReadInitFile = new ClassReadInitializeFile();
                ClassCommonVariableDefine CommonVariableDefine = new ClassCommonVariableDefine();

                //インストーラー作成後、ModelDetailsInfo.iniはAppDataへ格納
                CommonVariableDefine.ModelSpecDataFilePath = @"C:\Users\TakehiroSomekawa\source\repos\ExpAnalyzer\ExpAnalyzer\Servesers\ModelDetailsInfo.ini";

                //コンボボックス設定
                ComboBoxModelName.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboBoxModelName.Items.Clear();

                //デイリー履歴データをグラフへ表示(枠線のみ表示)
                DispDailyData.DisplayDailyDataOnChart(ChartDailyData, null, null, null);

                //設定ファイルから機種詳細情報を読込み
                ModelSpecDataList = ReadInitFile.ReadModelDetailsInfo(CommonVariableDefine.ModelSpecDataFilePath);
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

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
                    TextBoxHallDataFilePath.Text = Ofd.FileName;
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
                    ClassReadExcel ReadExcel = new ClassReadExcel();
                    ClassDispHallData DispHallData = new ClassDispHallData();
                    ClassDispDailyData DispDailyData = new ClassDispDailyData();
                    ClassDispModelDetailsInfo DispModelDetailsInfo = new ClassDispModelDetailsInfo();

                    //Excelからホールデータを読込み
                    HallData = ReadExcel.ReadHallDataFromExcel(CommonVariableDefine.HallDataFilePath);

                    //店舗名をテキストボックスへ表示
                    TextBoxStoreName.Text = HallData.HallName;

                    //機種データをコンボボックスへ表示
                    DispHallData.DisplayModelDataInComboBox(ComboBoxModelName);

                    //テキストボックスへ機種スペック情報を表示
                    DispModelDetailsInfo.DispModelDetailsInfoOnTextBox(this.TextBoxFirstHitProb,
                        this.TextBoxProbVarHitProb, this.TextBoxProbVarHitRashRate, this.TextBoxProbVarHitPersisRate,
                        this.TextBoxSpecialTime, this.TextBoxSavingTime, this.TextBoxCTime,
                        ModelSpecDataList, ComboBoxModelName.SelectedItem.ToString());

                    //台データをDataGridViewへ表示
                    DataGridViewUnitDataGrouper = DispHallData.DisplayUnitDataInDataGridView(
                        this.DataGridViewUnitData, this.ButtonOpenUnitDataGroup, this.ButtonCloseUnitDataGroup, ComboBoxModelName.SelectedItem.ToString());

                    //選択機種の先頭日の履歴データをグラフへ表示
                    DataGridViewUnitData.Rows[1].Selected = true;

                    if (DataGridViewUnitDataGrouper != null)
                    {
                        //Excelデータ読み込みボタン無効化
                        ButtonInportHallData.Enabled = false;

                        //DataGridView操作ボタン有効化
                        ButtonOpenUnitDataGroup.Enabled = true;
                        ButtonCloseUnitDataGroup.Enabled = true;
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
                if (TextBoxHallDataFilePath.Text != null && TextBoxHallDataFilePath.Text != "")
                {
                    //Excelデータ読み込みボタン有効化
                    ButtonInportHallData.Enabled = true;
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
        /// コンボボックス選択アイテム変更イベント
        /// </summary>
        private void ComboBoxModelName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassDispHallData DispHallData = new ClassDispHallData();
                ClassDispModelDetailsInfo DispModelDetailsInfo = new ClassDispModelDetailsInfo();

                //DataGridViewグループのリソース解放
                DataGridViewUnitDataGrouper.Dispose();

                //テキストボックスへ機種スペック情報を表示
                DispModelDetailsInfo.DispModelDetailsInfoOnTextBox(this.TextBoxFirstHitProb,
                    this.TextBoxProbVarHitProb, this.TextBoxProbVarHitRashRate, this.TextBoxProbVarHitPersisRate,
                    this.TextBoxSpecialTime, this.TextBoxSavingTime, this.TextBoxCTime,
                    ModelSpecDataList, ComboBoxModelName.SelectedItem.ToString());

                //台データをDataGridViewへ表示
                DataGridViewUnitDataGrouper = DispHallData.DisplayUnitDataInDataGridView(
                    this.DataGridViewUnitData, this.ButtonOpenUnitDataGroup, this.ButtonCloseUnitDataGroup, ComboBoxModelName.SelectedItem.ToString());

                //選択機種の先頭日の履歴データをグラフへ表示
                DataGridViewUnitData.Rows[1].Selected = true;
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        #region DataGridViewイベント
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
                DataGridViewSelectedCellCollection SelectedCell = DataGridViewUnitData.SelectedCells;
                DataGridViewUnitData.Rows[SelectedCell[0].RowIndex].Selected = true;
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
                ClassDispHallData DispHallData = new ClassDispHallData();

                //DataGridViewの表示設定(更新)
                DispHallData.SetDataGridViewDisplaySetting(this.DataGridViewUnitData);
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
                ClassDispHallData DispHallData = new ClassDispHallData();

                //DataGridViewの表示設定(更新)
                DispHallData.SetDataGridViewDisplaySetting(this.DataGridViewUnitData);
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
        /// </summary
        /// 
        private void DataGridViewUnitData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DataGridViewUnitData.SelectedCells.Count > 0
                    && DataGridViewUnitData.SelectedCells[0].RowIndex > 0
                    && DataGridViewUnitData.SelectedCells[0].ColumnIndex != -1
                    && DataGridViewUnitData.SelectedCells[0].Value != null)
                {
                    ClassDispDailyData DispDailyData = new ClassDispDailyData();
                    int row = DataGridViewUnitData.SelectedCells[0].RowIndex;

                    if (DataGridViewUnitData.Rows[row].Cells[1].Value != null)
                    {
                        //選択されているセルの行ごと色変更
                        DataGridViewUnitData.Rows[row].Selected = true;

                        //機種名
                        string modelName = ComboBoxModelName.SelectedItem.ToString();

                        //台番号
                        string unitNum = Convert.ToString(DataGridViewUnitData.Rows[row].Cells[0].Value);

                        //日付
                        string dateTime = Convert.ToString(DataGridViewUnitData.Rows[row].Cells[1].Value);

                        //デイリー履歴データをグラフへ表示
                        DispDailyData.DisplayDailyDataOnChart(ChartDailyData, modelName, unitNum, dateTime);
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
        #endregion
    }
}
