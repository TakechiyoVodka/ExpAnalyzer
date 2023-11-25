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
    /// 表示用デイリーデータクラス
    /// </summary>
    internal class ClassDispDailyData
    {
        /// <summary>
        /// 対象デイリーデータクラス
        /// </summary>
        public class ClassTargetDailyData
        {
            public int RotateCount;
            public int HitStatus;
            public int ProbVarHitCount;
        }

        /// <summary>
        /// デイリー履歴データをグラフへ表示
        /// </summary>
        public void DisplayDailyDataOnChart(Chart ChartDailyData, string modelName, string unitNum, string date)
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

            if (modelName != null && unitNum != null && date != null)
            {
                //対象デイリーデータを取得
                List<ClassTargetDailyData> TargetDailyDataList = GetTargetDailyData(modelName, unitNum, date);

                if (TargetDailyDataList[0].RotateCount != -1
                    && TargetDailyDataList[0].HitStatus != -1 && TargetDailyDataList[0].ProbVarHitCount != -1)
                {
                    int labelPosition = 1;

                    for (int i = 0; i < TargetDailyDataList.Count; i++)
                    {
                        DataMakers.Points.AddXY(Convert.ToDouble(i + 0.5), TargetDailyDataList[i].RotateCount);

                        switch (TargetDailyDataList[i].HitStatus)
                        {
                            case 1:
                                DataMakers.Points[i].Color = Color.Red;
                                ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat("単発\n", TargetDailyDataList[i].RotateCount));
                                break;
                            case 2:
                                DataMakers.Points[i].Color = Color.Orange;
                                ChartDailyData.ChartAreas[0].AxisX.CustomLabels.Add(
                                    Convert.ToDouble(labelPosition), Convert.ToDouble(0), string.Concat(TargetDailyDataList[i].ProbVarHitCount + 1, "連\n", TargetDailyDataList[i].RotateCount));
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
        /// 対象デイリーデータを取得
        /// </summary>
        private static List<ClassTargetDailyData> GetTargetDailyData(string modelName, string unitNum, string date)
        {
            List<ClassTargetDailyData> TargetDailyDataList = new List<ClassTargetDailyData>();

            ClassTargetDailyData TargetDailyData = new ClassTargetDailyData(); ;
            int prebVarHitCount = 0;

            foreach (ClassModelData ModelData in FormMain.HallData.ModelDataList)
            {
                if (TargetDailyDataList.Count != 0) break;

                if (ModelData.ModelName == modelName)
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        if (TargetDailyDataList.Count != 0) break;

                        if (UnitData.UnitNum == unitNum)
                        {
                            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                            {
                                if (TargetDailyDataList.Count != 0) break;

                                if (DailyData.Date.ToString("yyyy/MM/dd") == date)
                                {
                                    for (int i = 0; i < DailyData.HistoryDataList.Count; i++)
                                    {
                                        switch (DailyData.HistoryDataList[i].HitStatus)
                                        {
                                            case 1:
                                                //確変当り
                                                if (DailyData.HistoryDataList[i + 1].HitStatus == 2)
                                                {
                                                    TargetDailyData = new ClassTargetDailyData();
                                                    
                                                    if (TargetDailyDataList.Count == 0)
                                                    {
                                                        TargetDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount + GetBeforeRemainRotateCount(UnitData, date);
                                                    }
                                                    else
                                                    {
                                                        TargetDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                    }
                                                    TargetDailyData.HitStatus = 2;
                                                }
                                                //単発当り
                                                else
                                                {
                                                    TargetDailyData = new ClassTargetDailyData();

                                                    if (TargetDailyDataList.Count == 0)
                                                    {
                                                        TargetDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount + GetBeforeRemainRotateCount(UnitData, date);
                                                    }
                                                    else
                                                    {
                                                        TargetDailyData.RotateCount = DailyData.HistoryDataList[i].RotateCount;
                                                    }
                                                    TargetDailyData.HitStatus = 1;
                                                    TargetDailyData.ProbVarHitCount = 0;
                                                    TargetDailyDataList.Add(TargetDailyData);
                                                }
                                                break;

                                            case 2:
                                                //確変継続
                                                if (DailyData.HistoryDataList[i + 1].HitStatus != 0
                                                    && DailyData.HistoryDataList[i + 1].HitStatus != 1)
                                                {
                                                    prebVarHitCount++;
                                                }
                                                //確変終了
                                                else
                                                {
                                                    TargetDailyData.ProbVarHitCount = prebVarHitCount + 1;
                                                    TargetDailyDataList.Add(TargetDailyData);
                                                    
                                                    //確変回数をリセット
                                                    prebVarHitCount = 0;
                                                }
                                                break;
                                            default:
                                                //初当りがない場合は除外(定休日または故障台含む)
                                                if (TargetDailyDataList.Count == 0)
                                                {
                                                    TargetDailyData = new ClassTargetDailyData();
                                                    TargetDailyData.RotateCount = -1;
                                                    TargetDailyData.HitStatus = -1;
                                                    TargetDailyData.ProbVarHitCount = -1;
                                                    TargetDailyDataList.Add(TargetDailyData);
                                                    return TargetDailyDataList;
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
            return TargetDailyDataList;
        }

        /// <summary>
        /// 前日の残り回転数を取得
        /// </summary>
        private static int GetBeforeRemainRotateCount(ClassUnitData UnitData, string date)
        {
            int remainRotateCount = 0;

            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
            {
                if (DailyData.Date.ToString("yyyy/MM/dd") != date)
                {
                    foreach (ClassHistoryData HistoryData in DailyData.HistoryDataList)
                    {
                        if (HistoryData.HitStatus == 0)
                        {
                            //残り回転数
                            remainRotateCount += HistoryData.RotateCount;
                            break;
                        }
                        else if (HistoryData.HitStatus == -1)
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
