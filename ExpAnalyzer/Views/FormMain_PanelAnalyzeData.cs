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
        /// テストボタンクリックイベント(デバッグ用) → 後で消す
        /// </summary>
        private void ButtonTest_Click(object sender, EventArgs e)
        {
            ClassFirstHitCompProbOnChart FirstHitCompProbOnChart = new ClassFirstHitCompProbOnChart();

            //初当り合成確率をグラフへ表示
            FirstHitCompProbOnChart.FirstHitCompProbOnChart(this.ChartFirstHitCompProb, "ソードアート・オンライン", "0246");
        }
    }
}
