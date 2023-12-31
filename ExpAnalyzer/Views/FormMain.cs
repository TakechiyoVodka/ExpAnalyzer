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
                    this.PanelExportReport.Visible = false;
                    this.PanelUserSettings.Visible = false;
                }
                //パネルを最前面に移動
                this.PanelInportData.BringToFront();

                //コンボボックス設定
                ComboBoxModelName.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboBoxModelName.Items.Clear();
                ComboBoxHallDataSource.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboBoxHallDataSource.Items.Clear();
                ComboBoxHallDataSource.Items.Add("マルハンアプリ");
                ComboBoxHallDataSource.Items.Add("データロボサイトセブン");
                ComboBoxHallDataSource.Items.Add("台データオンライン");
                ComboBoxHallDataSource.SelectedIndex = 0;

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
                //パネルスタック後削除
                {
                    //データ分析パネルのみ表示
                    this.PanelInportData.Visible = false;
                    this.PanelAnalyzeData.Visible = true;
                    this.PanelExportReport.Visible = false;
                    this.PanelUserSettings.Visible = false;
                }
                //パネルを最前面に移動
                this.PanelAnalyzeData.BringToFront();

                if (ComboBoxDispModelName.Items.Count == 0)
                {
                    ClassFirstHitCompProbOnChart FirstHitCompProbOnChart = new ClassFirstHitCompProbOnChart();

                    foreach (ClassModelData ModelData in FormatHallData.ModelDataList)
                    {
                        ComboBoxDispModelName.Items.Add(ModelData.ModelName);

                        if (ComboBoxDispUnitNum.Items.Count == 0)
                        {
                            foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                            {
                                ComboBoxDispUnitNum.Items.Add(UnitData.UnitNum);
                            }
                        }
                    }
                    ComboBoxDispModelName.Enabled = true;
                    ComboBoxDispUnitNum.Enabled = true;
                    ComboBoxDispModelName.SelectedIndex = 0;
                    ComboBoxDispUnitNum.SelectedIndex = 0;

                    //初当り合成確率をグラフへ表示
                    FirstHitCompProbOnChart.FirstHitCompProbOnChart(this.ChartFirstHitCompProb, ComboBoxDispModelName.SelectedItem.ToString(), ComboBoxDispUnitNum.SelectedItem.ToString());
                }
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
                this.PanelExportReport.Visible = false;
                this.PanelUserSettings.Visible = true;
            }
            //パネルを最前面に移動
            this.PanelUserSettings.BringToFront();
        }
    }
}
