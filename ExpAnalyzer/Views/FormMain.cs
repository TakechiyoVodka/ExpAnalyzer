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
        public FormMain()
        {
            InitializeComponent();
        }
        #region 静的フィールド
        //共通変数
        private static ClassCommonVariableDefine CommonVariableDefine;
        //ホールデータ
        internal static ClassHallData HallData;
        //ホールデータ(整形後)
        internal static ClassHallData FormatHallData;
        //機種スペックデータ
        internal static List<ClassModelSpecData> ModelSpecDataList;
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
                ClassDailyDataOnChart DailyDataOnChart = new ClassDailyDataOnChart();
                ClassInportModelSpecDataFile InportModelSpecDataFile = new ClassInportModelSpecDataFile();
                ClassCommonVariableDefine CommonVariableDefine = new ClassCommonVariableDefine();

                //インストーラー作成後、ModelSpecData.iniはAppDataへ格納
                CommonVariableDefine.ModelSpecDataFilePath = @"C:\Users\TakehiroSomekawa\source\repos\ExpAnalyzer\ExpAnalyzer\Servesers\ModelSpecData.ini";

                //設定ファイルから機種スペックデータを読込み
                ModelSpecDataList = InportModelSpecDataFile.InportModelSpecDataFromTextFile(CommonVariableDefine.ModelSpecDataFilePath);

                //パネルスタック後削除
                {
                    //データ入力パネルのみ表示
                    this.PanelInportData.Visible = true;
                    this.PanelAnalyzeData.Visible = false;
                    this.PanelAnalyzeDataOperate.Visible = false;
                    this.PanelExportReport.Visible = false;
                    this.PanelUserSettings.Visible = false;
                }
                //パネルを最前面に移動
                this.PanelInportData.BringToFront();

                //コンボボックス設定
                this.ComboBoxModelName.DropDownStyle = ComboBoxStyle.DropDownList;
                this.ComboBoxModelName.Items.Clear();
                this.ComboBoxHallDataSource.DropDownStyle = ComboBoxStyle.DropDownList;
                this.ComboBoxHallDataSource.Items.Clear();
                this.ComboBoxHallDataSource.Items.Add("マルハンアプリ");
                this.ComboBoxHallDataSource.Items.Add("データロボサイトセブン");
                this.ComboBoxHallDataSource.Items.Add("台データオンライン");
                this.ComboBoxHallDataSource.SelectedIndex = 0;

                //デイリーデータをグラフへ表示 ※枠線のみ表示
                DailyDataOnChart.DispDailyDataOnChart(this.ChartDailyData, null, null, null);
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// データ入力ボタンクリックイベント
        /// </summary>
        private void ButtonDispInportDataPanel_Click(object sender, EventArgs e)
        {
            //パネルスタック後削除
            {
                //データ入力パネルのみ表示
                this.PanelInportData.Visible = true;
                this.PanelAnalyzeData.Visible = false;
                this.PanelAnalyzeDataOperate.Visible = false;
                this.PanelExportReport.Visible = false;
                this.PanelUserSettings.Visible = false;
            }
            //パネルを最前面に移動
            this.PanelInportData.BringToFront();
        }

        /// <summary>
        /// データ分析ボタンクリックイベント
        /// </summary>
        private void ButtonDispAnalyzeDataPanel_Click(object sender, EventArgs e)
        {
            try
            {
                ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

                //パネルスタック後削除
                {
                    //データ分析パネルのみ表示
                    this.PanelInportData.Visible = false;
                    this.PanelAnalyzeData.Visible = true;
                    this.PanelAnalyzeDataOperate.Visible = true;
                    this.PanelExportReport.Visible = false;
                    this.PanelUserSettings.Visible = false;
                }
                //パネルを最前面に移動
                this.PanelAnalyzeData.BringToFront();
                this.PanelAnalyzeDataOperate.BringToFront();

                if (this.PanelAnalyzeData.Enabled == false && this.PanelAnalyzeDataOperate.Enabled == false)
                {
                    //コンボボックスの初期設定
                    if (this.ComboBoxDispModelName.Items.Count == 0)
                    {
                        foreach (ClassModelData ModelData in FormatHallData.ModelDataList)
                        {
                            this.ComboBoxDispModelName.Items.Add(ModelData.ModelName);

                            if (this.ComboBoxDispUnitNum.Items.Count == 0)
                            {
                                foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                                {
                                    this.ComboBoxDispUnitNum.Items.Add(UnitData.UnitNum);
                                }
                            }
                        }
                        this.ComboBoxDispModelName.SelectedIndex = 0;
                        this.ComboBoxDispUnitNum.SelectedIndex = 0;
                    }

                    //移動平均線1の初期設定
                    this.ComboBoxMA1Type.Items.Clear();
                    this.ComboBoxMA1Type.Items.Add("SMA");
                    this.ComboBoxMA1Type.Items.Add("EMA");
                    this.ComboBoxMA1Type.Items.Add("WMA");
                    this.ComboBoxMA1Type.SelectedIndex = 0;
                    this.NumUpDownMA1SampleNum.Value = 5;
                    this.CheckBoxMA1Enable.Checked = true;

                    //移動平均線2の初期設定
                    this.ComboBoxMA2Type.Items.Clear();
                    this.ComboBoxMA2Type.Items.Add("SMA");
                    this.ComboBoxMA2Type.Items.Add("EMA");
                    this.ComboBoxMA2Type.Items.Add("WMA");
                    this.ComboBoxMA2Type.SelectedIndex = 0;
                    this.NumUpDownMA2SampleNum.Value = 20;
                    this.CheckBoxMA2Enable.Checked = true;

                    //データ分析パネル有効化
                    this.PanelAnalyzeData.Enabled = true;
                    this.PanelAnalyzeDataOperate.Enabled = true;
                }

                //初当り合成確率をグラフへ表示
                AnalyzeDataOnChart.FirstHitCompProbOnChart(
                    this.ChartFirstHitCompProb,
                    this.ComboBoxDispModelName.SelectedItem.ToString(),
                    this.ComboBoxDispUnitNum.SelectedItem.ToString(),
                    this.CheckBoxMA1Enable.Checked,
                    this.CheckBoxMA2Enable.Checked,
                    this.ComboBoxMA1Type.SelectedItem.ToString(),
                    this.ComboBoxMA2Type.SelectedItem.ToString(),
                    int.Parse(this.NumUpDownMA1SampleNum.Value.ToString()),
                    int.Parse(this.NumUpDownMA2SampleNum.Value.ToString()));
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// レポート出力ボタンクリックイベント
        /// </summary>
        private void ButtonDispExportReportPanel_Click(object sender, EventArgs e)
        {
            //パネルスタック後削除
            {
                //レポート出力パネルのみ表示
                this.PanelInportData.Visible = false;
                this.PanelAnalyzeData.Visible = false;
                this.PanelAnalyzeDataOperate.Visible = false;
                this.PanelExportReport.Visible = true;
                this.PanelUserSettings.Visible = false;
            }
            //パネルを最前面に移動
            this.PanelExportReport.BringToFront();
        }

        /// <summary>
        /// 設定ボタンクリックイベント
        /// </summary>
        private void ButtonDispUserSettingsPanel_Click(object sender, EventArgs e)
        {
            //パネルスタック後削除
            {
                //設定パネルのみ表示
                this.PanelInportData.Visible = false;
                this.PanelAnalyzeData.Visible = false;
                this.PanelAnalyzeDataOperate.Visible = false;
                this.PanelExportReport.Visible = false;
                this.PanelUserSettings.Visible = true;
            }
            //パネルを最前面に移動
            this.PanelUserSettings.BringToFront();
        }
    }
}
