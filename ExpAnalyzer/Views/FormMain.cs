using ExpAnalyzer.Controller.GlaphMapping;
using ExpAnalyzer.Controller.Inport;
using ExpAnalyzer.Models;
using Subro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static ClassDefine Define;
        public static ClassHallData HallData;
        //public static List<ClassHallData> HallDataList;
        public static Subro.Controls.DataGridViewGrouper DataGridViewUnitDataGrouper = null;
        #endregion

        /// <summary>
        /// メインフォームロードイベント
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                ClassDispDailyData DispDailyData = new ClassDispDailyData();

                //コンボボックス設定
                ComboBoxModelName.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboBoxModelName.Items.Clear();

                //デイリー履歴データをグラフへ表示(枠線のみ表示)
                DispDailyData.DisplayDailyDataOnChart(ChartDailyData, null, null, null);
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
                    Define = new ClassDefine();

                    Define.InputWorkbookPath = Ofd.FileName;
                    TextBoxReadExcelPath.Text = Ofd.FileName;
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
        /// Excelデータ読み込みボタンクリックイベント
        /// </summary>
        private void ButtonReadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Define.InputWorkbookPath) == true)
                {
                    ClassReadExcel ReadExcel = new ClassReadExcel();
                    ClassDispHallData DispHallData = new ClassDispHallData();
                    ClassDispDailyData DispDailyData = new ClassDispDailyData();

                    //Excelからホールデータを読込み
                    HallData = ReadExcel.ReadHallDataFromExcel(Define.InputWorkbookPath);

                    //店舗名をテキストボックスへ表示
                    TextBoxStoreName.Text = HallData.HallName;

                    //機種データをコンボボックスへ表示
                    DispHallData.DisplayModelDataInComboBox(ComboBoxModelName, HallData);

                    //台データをDataGridViewへ表示
                    DataGridViewUnitDataGrouper = DispHallData.DisplayUnitDataInDataGridView(
                        this.DataGridViewUnitData, this.ButtonOpenGroup, this.ButtonCloseGroup, HallData, ComboBoxModelName.SelectedItem.ToString());

                    //選択機種の先頭日の履歴データをグラフへ表示
                    foreach (ClassModelData ModelData in HallData.ModelDataList)
                    {
                        if (ModelData.ModelName == ComboBoxModelName.SelectedItem.ToString())
                        {
                            string modelName = ModelData.ModelName;

                            foreach(ClassUnitData UnitData in ModelData.UnitDataList)
                            {
                                string unitNum = UnitData.UnitNum;
                                
                                foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                                {
                                    string date = DailyData.Date.ToString("yyyy/MM/dd");

                                    //デイリー履歴データをグラフへ表示
                                    DispDailyData.DisplayDailyDataOnChart(ChartDailyData, modelName, unitNum, date);
                                    break;
                                }
                                break;
                            }
                        }
                    }

                    if (DataGridViewUnitDataGrouper != null)
                    {
                        //Excelデータ読み込みボタン無効化
                        ButtonReadExcel.Enabled = false;

                        //DataGridView操作ボタン有効化
                        ButtonOpenGroup.Enabled = true;
                        ButtonCloseGroup.Enabled = true;
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
        /// テキストボックス(読み込みExcelデータファイル)テキスト変更イベント
        /// </summary>
        private void TextBoxReadExcelPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxReadExcelPath.Text != null && TextBoxReadExcelPath.Text != "")
                {
                    //Excelデータ読み込みボタン有効化
                    ButtonReadExcel.Enabled = true;
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
                ClassDispDailyData DispDailyData = new ClassDispDailyData();

                //DataGridViewグループのリソース解放
                DataGridViewUnitDataGrouper.Dispose();

                //台データをDataGridViewへ表示
                DataGridViewUnitDataGrouper = DispHallData.DisplayUnitDataInDataGridView(
                    this.DataGridViewUnitData, this.ButtonOpenGroup, this.ButtonCloseGroup, HallData, ComboBoxModelName.SelectedItem.ToString());

                //選択機種の先頭日の履歴データをグラフへ表示
                foreach (ClassModelData ModelData in HallData.ModelDataList)
                {
                    if (ModelData.ModelName == ComboBoxModelName.SelectedItem.ToString())
                    {
                        string modelName = ModelData.ModelName;

                        foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                        {
                            string unitNum = UnitData.UnitNum;

                            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                            {
                                string date = DailyData.Date.ToString("yyyy/MM/dd");

                                //デイリー履歴データをグラフへ表示
                                DispDailyData.DisplayDailyDataOnChart(ChartDailyData, modelName, unitNum, date);
                                break;
                            }
                            break;
                        }
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

        #region DataGridViewイベント
        /// <summary>
        /// DataGridViewグループ開くボタンクリックイベント
        /// </summary>
        private void ButtonOpenGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //表示中のグループを全て開く
                DataGridViewUnitDataGrouper.ExpandAll();
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// DataGridViewグループ閉じるボタンクリックイベント
        /// </summary>
        private void ButtonCloseGroup_Click(object sender, EventArgs e)
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
        /// DataGridViewセルクリックイベント
        /// </summary>
        private void DataGridViewUnitData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //クリックされたセルの値
                string cellValue = Convert.ToString(DataGridViewUnitData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (cellValue != "")
                {
                    ClassDispDailyData DispDailyData = new ClassDispDailyData();

                    //機種名
                    string modelName = ComboBoxModelName.SelectedItem.ToString();

                    //台番号
                    string unitNum = Convert.ToString(DataGridViewUnitData.Rows[e.RowIndex].Cells[0].Value);

                    //日付
                    string date = Convert.ToString(DataGridViewUnitData.Rows[e.RowIndex].Cells[1].Value);

                    //デイリー履歴データをグラフへ表示
                    DispDailyData.DisplayDailyDataOnChart(ChartDailyData, modelName, unitNum, date);
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
