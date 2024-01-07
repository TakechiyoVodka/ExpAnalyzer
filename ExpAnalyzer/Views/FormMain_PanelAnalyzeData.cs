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
        /// コンボボックス(グラフ表示機種名)選択アイテム変更イベント
        /// </summary> 
        private void ComboBoxDispModelName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();
                this.ComboBoxDispUnitNum.Items.Clear();

                foreach (ClassModelData ModelData in FormatHallData.ModelDataList)
                {
                    if (ModelData.ModelName == this.ComboBoxDispModelName.SelectedItem.ToString())
                    {
                        foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                        {
                            this.ComboBoxDispUnitNum.Items.Add(UnitData.UnitNum);
                        }
                    }
                }
                this.ComboBoxDispUnitNum.SelectedIndex = 0;

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
        /// コンボボックス(グラフ表示台番号)選択アイテム変更イベント
        /// </summary>
        private void ComboBoxDispUnitNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
        /// チェックボックス(移動平均線１)チェック変更イベント
        /// </summary>
        private void CheckBoxMA1Enable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckBoxMA1Enable.Checked == true)
                {
                    this.CheckBoxMA1Enable.Text = "ON";
                    this.CheckBoxMA1Enable.ForeColor = Color.Black;
                    this.CheckBoxMA1Enable.BackColor = Color.LimeGreen;
                }
                else
                {
                    this.CheckBoxMA1Enable.Text = "OFF";
                    this.CheckBoxMA1Enable.ForeColor = Color.White;
                    this.CheckBoxMA1Enable.BackColor = Color.FromArgb(74, 84, 96);
                }

                if (this.PanelAnalyzeData.Enabled == true && this.PanelAnalyzeDataOperate.Enabled == true)
                {
                    ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// チェックボックス(移動平均線２)チェック変更イベント
        /// </summary>
        private void CheckBoxMA2Enable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckBoxMA2Enable.Checked == true)
                {
                    this.CheckBoxMA2Enable.Text = "ON";
                    this.CheckBoxMA2Enable.ForeColor = Color.Black;
                    this.CheckBoxMA2Enable.BackColor = Color.LimeGreen;
                }
                else
                {
                    this.CheckBoxMA2Enable.Text = "OFF";
                    this.CheckBoxMA2Enable.ForeColor = Color.White;
                    this.CheckBoxMA2Enable.BackColor = Color.FromArgb(74, 84, 96);
                }

                if (this.PanelAnalyzeData.Enabled == true && this.PanelAnalyzeDataOperate.Enabled == true)
                {
                    ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// コンボボックス(移動平均線１-種別)選択アイテム変更イベント
        /// </summary>
        private void ComboBoxMA1Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
        /// コンボボックス(移動平均線２-種別)選択アイテム変更イベント
        /// </summary> 
        private void ComboBoxMA2Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
        /// 数値コントロール(移動平均線１)値変更イベント
        /// </summary>
        private void NumUpDownMA1SampleNum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.PanelAnalyzeData.Enabled == true && this.PanelAnalyzeDataOperate.Enabled == true)
                {
                    ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }

        /// <summary>
        /// 数値コントロール(移動平均線２)値変更イベント
        /// </summary>
        private void NumUpDownMA2SampleNum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.PanelAnalyzeData.Enabled == true && this.PanelAnalyzeDataOperate.Enabled == true)
                {
                    ClassAnalyzeDataOnChart AnalyzeDataOnChart = new ClassAnalyzeDataOnChart();

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
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }
    }
}
