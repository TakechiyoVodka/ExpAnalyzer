using ExpAnalyzer.Models;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpAnalyzer.Controller.GlaphMapping
{
    internal class ClassFirstHitCompProbOnChart
    {
        /// <summary>
        /// グラフ表示用初当り回転数クラス
        /// </summary>
        private class ClassDispFirstHitRotateCount
        {
            public int RotateCount;
            public int HitType;
            public int ProbVarHitCount;
        }

        /// <summary>
        /// 初当り合成確率をグラフへ表示
        /// </summary>
        internal void FirstHitCompProbOnChart(Chart ChartFirstHitCompProb, string modelName, string unitNum)
        {
            //グラフを初期化
            ChartFirstHitCompProb.Series.Clear();
            ChartFirstHitCompProb.Titles.Clear();
            ChartFirstHitCompProb.Legends.Clear();
            ChartFirstHitCompProb.ChartAreas.Clear();
            ChartFirstHitCompProb.ChartAreas.Add("ChartFirstHitCompProb");
            ChartFirstHitCompProb.ChartAreas[0].BackColor = Color.FromArgb(22, 29, 41);

            //X軸
            ChartFirstHitCompProb.ChartAreas[0].AxisX.Minimum = 0;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.Maximum = 20;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.Interval = 1;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorGrid.Interval = 0;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorGrid.IntervalOffset = 0.5;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Yu Gothic UI", 9, FontStyle.Regular);
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            //Y軸
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MaximumAutoSize = 10;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.Minimum = 0;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.Maximum = 1500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.Interval = 100;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.Interval = 500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.Interval = 100;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.DimGray;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            //棒グラフ            
            Series DataMakers = new Series();
            int dataMakerCount = 0;

            if (modelName != null && unitNum != null)
            {
                //グラフへ表示させるデイリーデータを取得
                List<ClassDispFirstHitRotateCount> DispFirstHitRotateCountList = GetDispFirstHitRotateCount(modelName, unitNum);
                int labelPosition = 1;

                for (int i = 0; i < DispFirstHitRotateCountList.Count; i++)
                {
                    if (DispFirstHitRotateCountList[i].HitType != -1
                        && DispFirstHitRotateCountList[i].RotateCount != -1 && DispFirstHitRotateCountList[i].ProbVarHitCount != -1)
                    {
                        DataMakers.Points.AddXY(Convert.ToDouble(dataMakerCount + 0.5), DispFirstHitRotateCountList[i].RotateCount);

                        switch (DispFirstHitRotateCountList[i].HitType)
                        {
                            case 1:
                                DataMakers.Points[dataMakerCount].Color = Color.Red;
                                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat("単発\n", DispFirstHitRotateCountList[i].RotateCount));
                                break;
                            case 2:
                                DataMakers.Points[dataMakerCount].Color = Color.Orange;
                                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat(DispFirstHitRotateCountList[i].ProbVarHitCount + 1, "連\n", DispFirstHitRotateCountList[i].RotateCount));
                                break;
                            case 3:
                                if (DispFirstHitRotateCountList[i].ProbVarHitCount == 0)
                                {
                                    DataMakers.Points[dataMakerCount].Color = Color.Blue;
                                    ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(
                                        Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat("単発\n", DispFirstHitRotateCountList[i].RotateCount));
                                }
                                else
                                {
                                    DataMakers.Points[dataMakerCount].Color = Color.Blue;
                                    ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(
                                        Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat(DispFirstHitRotateCountList[i].ProbVarHitCount + 1, "連\n", DispFirstHitRotateCountList[i].RotateCount));
                                }
                                break;
                        }
                        labelPosition += 2;
                        dataMakerCount++;
                    }
                }
            }
            else
            {
                DataMakers.Points.AddXY(0.5, 0);
                DataMakers.Points[0].Color = Color.White;
                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(1), Convert.ToDouble(0), " \n ");
            }
            ChartFirstHitCompProb.Series.Add(DataMakers);
            return;
        }

        /// <summary>
        /// グラフへ表示させる初当り回転数を取得
        /// </summary>
        private static List<ClassDispFirstHitRotateCount> GetDispFirstHitRotateCount(string modelName, string unitNum)
        {
            List<ClassDispFirstHitRotateCount> DispFirstHitRotateCountList = new List<ClassDispFirstHitRotateCount>();

            ClassDispFirstHitRotateCount DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();
            int prebVarHitCount = 0;

            foreach (ClassModelData ModelData in FormMain.FormatHallData.ModelDataList)
            {
                if (DispFirstHitRotateCountList.Count != 0) break;

                if (ModelData.ModelName == modelName)
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        if (DispFirstHitRotateCountList.Count != 0) break;

                        if (UnitData.UnitNum == unitNum)
                        {
                            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                            {
                                for (int i = 0; i < DailyData.HistoryDataList.Count; i++)
                                {
                                    switch (DailyData.HistoryDataList[i].HitType)
                                    {
                                        case 1:
                                            //確変当り
                                            if (i < DailyData.HistoryDataList.Count - 1 
                                                && DailyData.HistoryDataList[i + 1].HitType == 2)
                                            {
                                                DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();

                                                DispFirstHitRotateCount.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                DispFirstHitRotateCount.HitType = 2;
                                            }
                                            //単発当り
                                            else
                                            {
                                                DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();

                                                DispFirstHitRotateCount.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                DispFirstHitRotateCount.HitType = 1;
                                                DispFirstHitRotateCount.ProbVarHitCount = 0;
                                                DispFirstHitRotateCountList.Add(DispFirstHitRotateCount);
                                            }
                                            break;

                                        case 2:
                                            //確変継続
                                            if (i < DailyData.HistoryDataList.Count - 1
                                                && DailyData.HistoryDataList[i + 1].HitType == 2)
                                            {
                                                prebVarHitCount++;
                                            }
                                            //確変終了
                                            else
                                            {
                                                DispFirstHitRotateCount.ProbVarHitCount = prebVarHitCount + 1;
                                                DispFirstHitRotateCountList.Add(DispFirstHitRotateCount);

                                                //確変回数をリセット
                                                prebVarHitCount = 0;
                                            }
                                            break;

                                        case 3:
                                            //確変当り
                                            if (i < DailyData.HistoryDataList.Count - 1
                                                && DailyData.HistoryDataList[i + 1].HitType == 2)
                                            {
                                                DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();

                                                DispFirstHitRotateCount.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                DispFirstHitRotateCount.HitType = 3;
                                            }
                                            //単発当り
                                            else
                                            {
                                                DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();

                                                DispFirstHitRotateCount.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                DispFirstHitRotateCount.HitType = 3;
                                                DispFirstHitRotateCount.ProbVarHitCount = 0;
                                                DispFirstHitRotateCountList.Add(DispFirstHitRotateCount);
                                            }
                                            break;

                                        default:
                                            //初当りがない場合は除外(定休日または故障台含む)
                                            if (DailyData.HistoryDataList[i].HitType == -1)
                                            {
                                                DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();
                                                DispFirstHitRotateCount.RotateCount = -1;
                                                DispFirstHitRotateCount.HitType = -1;
                                                DispFirstHitRotateCount.ProbVarHitCount = -1;
                                                DispFirstHitRotateCountList.Add(DispFirstHitRotateCount);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return DispFirstHitRotateCountList;
        }
    }
}
