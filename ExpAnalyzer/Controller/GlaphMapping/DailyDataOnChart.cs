using ExpAnalyzer.Models;
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
    /// <summary>
    /// デイリーデータのグラフクラス
    /// </summary>
    internal class ClassDailyDataOnChart
    {
        /// <summary>
        /// グラフ表示用デイリーデータクラス
        /// </summary>
        private class ClassDispDailyData
        {
            public int RotateCount;
            public int HitType;
            public int ProbVarHitCount;
        }

        /// <summary>
        /// デイリーデータをグラフへ表示
        /// </summary>
        internal void DispDailyDataOnChart(Chart ChartDailyData, string modelName, string unitNum, string dateTime)
        {
            //グラフを初期化
            ChartDailyData.Series.Clear();
            ChartDailyData.Titles.Clear();
            ChartDailyData.Legends.Clear();
            ChartDailyData.ChartAreas.Clear();
            ChartDailyData.ChartAreas.Add("ChartDailyData");
            ChartDailyData.ChartAreas[0].BackColor = Color.FromArgb(22, 29, 41);
            
            //X軸
            ChartDailyData.ChartAreas[0].AxisX.Minimum = 0;
            ChartDailyData.ChartAreas[0].AxisX.Maximum = 15;
            ChartDailyData.ChartAreas[0].AxisX.Interval = 1;
            ChartDailyData.ChartAreas[0].AxisX.MajorGrid.Interval = 0;
            ChartDailyData.ChartAreas[0].AxisX.MinorGrid.IntervalOffset = 0.5;
            ChartDailyData.ChartAreas[0].AxisX.LineColor = Color.White;
            ChartDailyData.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            ChartDailyData.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            ChartDailyData.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            ChartDailyData.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Yu Gothic UI", 9, FontStyle.Regular);
            ChartDailyData.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            //Y軸
            ChartDailyData.ChartAreas[0].AxisY.MaximumAutoSize = 10;
            ChartDailyData.ChartAreas[0].AxisY.Minimum = 0;
            ChartDailyData.ChartAreas[0].AxisY.Maximum = 1500;
            ChartDailyData.ChartAreas[0].AxisY.Interval = 100;
            ChartDailyData.ChartAreas[0].AxisY.MajorGrid.Interval = 500;
            ChartDailyData.ChartAreas[0].AxisY.MinorGrid.Interval = 100;
            ChartDailyData.ChartAreas[0].AxisY.LineColor = Color.White;
            ChartDailyData.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            ChartDailyData.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.DimGray;
            ChartDailyData.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            ChartDailyData.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            ChartDailyData.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            ChartDailyData.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            ChartDailyData.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            //棒グラフ            
            Series DataMakers = new Series();
            DataMakers.ChartType = SeriesChartType.Column;

            if (modelName != null && unitNum != null && dateTime != null)
            {
                //グラフへ表示させるデイリーデータを取得
                List<ClassDispDailyData> DispDailyDataList = GetDispDailyData(modelName, unitNum, dateTime);

                if (DispDailyDataList[0].RotateCount != -1
                    && DispDailyDataList[0].HitType != -1 && DispDailyDataList[0].ProbVarHitCount != -1)
                {
                    int labelPosition = 1;

                    for (int i = 0; i < DispDailyDataList.Count; i++)
                    {
                        DataMakers.Points.AddXY(Convert.ToDouble(i + 0.5), DispDailyDataList[i].RotateCount);

                        switch (DispDailyDataList[i].HitType)
                        {
                            case 1:
                                DataMakers.Points[i].Color = Color.Red;
                                ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat("単発\n", DispDailyDataList[i].RotateCount));
                                break;
                            case 2:
                                DataMakers.Points[i].Color = Color.Orange;
                                ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat(DispDailyDataList[i].ProbVarHitCount + 1, "連\n", DispDailyDataList[i].RotateCount));
                                break;
                        }
                        labelPosition += 2;
                    }
                }
                else
                {
                    DataMakers.Points.AddXY(0.5, 0);
                    ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(1), Convert.ToDouble(0), " \n ");
                }
            }
            else
            {
                DataMakers.Points.AddXY(0.5, 0);
                DataMakers.Points[0].Color = Color.White;
                ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(1), Convert.ToDouble(0), " \n ");
            }
            ChartDailyData.Series.Add(DataMakers);
            return;
        }

        /// <summary>
        /// グラフへ表示させるデイリーデータを取得
        /// </summary>
        private static List<ClassDispDailyData> GetDispDailyData(string modelName, string unitNum, string dateTime)
        {
            List<ClassDispDailyData> DispDailyDataList = new List<ClassDispDailyData>();

            ClassDispDailyData DispDailyData = new ClassDispDailyData(); ;
            int prebVarHitCount = 0;

            foreach (ClassModelData ModelData in FormMain.HallData.ModelDataList)
            {
                if (DispDailyDataList.Count != 0) break;

                if (ModelData.ModelName == modelName)
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        if (DispDailyDataList.Count != 0) break;

                        if (UnitData.UnitNum == unitNum)
                        {
                            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                            {
                                if (DispDailyDataList.Count != 0) break;

                                if (DailyData.DateTime.ToString("yyyy/MM/dd") == dateTime)
                                {
                                    for (int i = 0; i < DailyData.HistoryDataList.Count; i++)
                                    {
                                        switch (DailyData.HistoryDataList[i].HitType)
                                        {
                                            case 1:
                                                //確変当り
                                                if (DailyData.HistoryDataList[i + 1].HitType == 2)
                                                {
                                                    DispDailyData = new ClassDispDailyData();
                                                    
                                                    if (DispDailyDataList.Count == 0)
                                                    {
                                                        DispDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount + GetBeforeDayRemainRotateCount(UnitData, dateTime);
                                                    }
                                                    else
                                                    {
                                                        DispDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                    }
                                                    DispDailyData.HitType = 2;
                                                }
                                                //単発当り
                                                else
                                                {
                                                    DispDailyData = new ClassDispDailyData();

                                                    if (DispDailyDataList.Count == 0)
                                                    {
                                                        DispDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount + GetBeforeDayRemainRotateCount(UnitData, dateTime);
                                                    }
                                                    else
                                                    {
                                                        DispDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                    }
                                                    DispDailyData.HitType = 1;
                                                    DispDailyData.ProbVarHitCount = 0;
                                                    DispDailyDataList.Add(DispDailyData);
                                                }
                                                break;

                                            case 2:
                                                //確変継続
                                                if (DailyData.HistoryDataList[i + 1].HitType != 0
                                                    && DailyData.HistoryDataList[i + 1].HitType != 1)
                                                {
                                                    prebVarHitCount++;
                                                }
                                                //確変終了
                                                else
                                                {
                                                    DispDailyData.ProbVarHitCount = prebVarHitCount + 1;
                                                    DispDailyDataList.Add(DispDailyData);
                                                    
                                                    //確変回数をリセット
                                                    prebVarHitCount = 0;
                                                }
                                                break;
                                            default:
                                                //初当りがない場合は除外(定休日または故障台含む)
                                                if (DispDailyDataList.Count == 0)
                                                {
                                                    DispDailyData = new ClassDispDailyData();
                                                    DispDailyData.RotateCount = -1;
                                                    DispDailyData.HitType = -1;
                                                    DispDailyData.ProbVarHitCount = -1;
                                                    DispDailyDataList.Add(DispDailyData);
                                                    return DispDailyDataList;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return DispDailyDataList;
        }

        /// <summary>
        /// 前日の残り回転数を取得
        /// </summary>
        private static int GetBeforeDayRemainRotateCount(ClassUnitData UnitData, string dateTime)
        {
            int remainRotateCount = 0;

            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
            {
                if (DailyData.DateTime.ToString("yyyy/MM/dd") != dateTime)
                {
                    foreach (ClassHistoryData HistoryData in DailyData.HistoryDataList)
                    {
                        if (HistoryData.HitType == 0)
                        {
                            //残り回転数
                            remainRotateCount += HistoryData.RotateCount;
                            break;
                        }
                        else if (HistoryData.HitType == -1)
                        {
                            //定休日または故障台
                            break;
                        }
                        else
                        {
                            //大当り時に残り回転数リセット
                            remainRotateCount = 0;
                            continue;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return remainRotateCount;
        }
    }
}
