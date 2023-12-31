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
            ClassFirstHitCompProbOnChart FirstHitCompProbOnChart = new ClassFirstHitCompProbOnChart();
            ComboBoxDispUnitNum.Items.Clear();

            foreach (ClassModelData ModelData in FormatHallData.ModelDataList)
            {
                if (ModelData.ModelName == ComboBoxDispModelName.SelectedItem.ToString())
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        ComboBoxDispUnitNum.Items.Add(UnitData.UnitNum);
                    }
                }
            }
            ComboBoxDispUnitNum.SelectedIndex = 0;

            //初当り合成確率をグラフへ表示
            FirstHitCompProbOnChart.FirstHitCompProbOnChart(this.ChartFirstHitCompProb, ComboBoxDispModelName.SelectedItem.ToString(), ComboBoxDispUnitNum.SelectedItem.ToString());
        }

        /// <summary>
        /// コンボボックス(グラフ表示台番号)選択アイテム変更イベント
        /// </summary>
        private void ComboBoxDispUnitNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClassFirstHitCompProbOnChart FirstHitCompProbOnChart = new ClassFirstHitCompProbOnChart();

            //初当り合成確率をグラフへ表示
            FirstHitCompProbOnChart.FirstHitCompProbOnChart(this.ChartFirstHitCompProb, ComboBoxDispModelName.SelectedItem.ToString(), ComboBoxDispUnitNum.SelectedItem.ToString());
        }
    }
}
