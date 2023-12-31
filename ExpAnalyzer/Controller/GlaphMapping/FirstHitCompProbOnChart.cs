using ExpAnalyzer.Controller.Calculate;
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
using static ExpAnalyzer.Controller.Calculate.ClassCalcFirstHitCompProb;

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
            ChartFirstHitCompProb.ChartAreas[0].BackColor = Color.FromArgb(15, 20, 28);

            //グラフへ表示させるデイリーデータを取得
            List<ClassDispFirstHitRotateCount> DispFirstHitRotateCountList = GetDispFirstHitRotateCount(modelName, unitNum);

            #region グラフX軸設定
            //グラフX軸領域設定
            ChartFirstHitCompProb.ChartAreas[0].AxisX.Minimum = 0;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.Maximum = DispFirstHitRotateCountList.Count;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LineColor = Color.White;

            //グラフX軸グリッド設定
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.DimGray;

            //グラフX軸ラベル設定
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Yu Gothic UI", 9, FontStyle.Regular);
            ChartFirstHitCompProb.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            //グラフX軸拡大表示設定
            ChartFirstHitCompProb.ChartAreas[0].AxisX.ScaleView.Size = 20;

            if (DispFirstHitRotateCountList.Count > ChartFirstHitCompProb.ChartAreas[0].AxisX.ScaleView.Size)
            {
                ChartFirstHitCompProb.ChartAreas[0].AxisX.ScaleView.Position = DispFirstHitRotateCountList.Count - ChartFirstHitCompProb.ChartAreas[0].AxisX.ScaleView.Size;
            }
            ChartFirstHitCompProb.ChartAreas[0].AxisX.IsMarginVisible = false;

            //グラフX軸スクロールバー設定
            ChartFirstHitCompProb.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            ChartFirstHitCompProb.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.FromArgb(74, 84, 96);
            ChartFirstHitCompProb.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.FromArgb(22, 29, 41);
            #endregion

            #region グラフY軸設定
            //グラフY軸領域設定
            ChartFirstHitCompProb.ChartAreas[0].AxisY.Minimum = 0;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.Maximum = 1500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LineColor = Color.White;

            //グラフY軸グリッド設定
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorTickMark.Enabled = true;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.Interval = 500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.Interval = 100;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorTickMark.Interval = 500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.DimGray;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.White;

            //グラフY軸ラベル設定
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Yu Gothic UI", 9, FontStyle.Regular);
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LabelStyle.Interval = 500;
            ChartFirstHitCompProb.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            #endregion

            #region 初当り回転数履歴
            Series DataMakers = new Series();

            //データマーカータイプ：棒グラフ
            DataMakers.ChartType = SeriesChartType.Column;
            DataMakers.SetCustomProperty("PointWidth", "0.6");
            int dataMakerCount = 0;

            if (modelName != null && unitNum != null)
            {
                int labelPosition = 1;

                for (int i = 0; i < DispFirstHitRotateCountList.Count; i++)
                {
                    DataMakers.Points.AddXY(Convert.ToDouble(dataMakerCount + 0.5), DispFirstHitRotateCountList[i].RotateCount);

                    switch (DispFirstHitRotateCountList[i].HitType)
                    {
                        case 1:

                            DataMakers.Points[dataMakerCount].Color = Color.Red;
                            ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(labelPosition), Convert.ToDouble(0),
                                string.Concat("単発\n", DispFirstHitRotateCountList[i].RotateCount));
                            break;

                        case 2:

                            DataMakers.Points[dataMakerCount].Color = Color.Orange;
                            ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(labelPosition), Convert.ToDouble(0),
                                string.Concat(DispFirstHitRotateCountList[i].ProbVarHitCount + 1, "連\n", DispFirstHitRotateCountList[i].RotateCount));
                            break;

                        case 3:

                            if (DispFirstHitRotateCountList[i].ProbVarHitCount == 0)
                            {
                                DataMakers.Points[dataMakerCount].Color = Color.SteelBlue;
                                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(labelPosition), Convert.ToDouble(0),
                                    string.Concat("単発\n", DispFirstHitRotateCountList[i].RotateCount));
                            }
                            else
                            {
                                DataMakers.Points[dataMakerCount].Color = Color.SteelBlue;
                                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(labelPosition), Convert.ToDouble(0),
                                    string.Concat(DispFirstHitRotateCountList[i].ProbVarHitCount + 1, "連\n", DispFirstHitRotateCountList[i].RotateCount));
                            }
                            break;
                    }
                    labelPosition += 2;
                    dataMakerCount++;
                }
            }
            else
            {
                DataMakers.Points.AddXY(Convert.ToDouble(0.5), 0);
                DataMakers.Points[0].Color = Color.White;
                ChartFirstHitCompProb.ChartAreas[0].AxisX.CustomLabels.Add(Convert.ToDouble(1), Convert.ToDouble(0), " \n ");
            }
            ChartFirstHitCompProb.Series.Add(DataMakers);
            #endregion

            #region 初当り確率
            DataMakers = new Series();

            //データマーカータイプ：折れ線グラフ
            DataMakers.ChartType = SeriesChartType.Line;

            double firstHitProb = 0;

            foreach (ClassModelSpecData ModelSpecData in FormMain.ModelSpecDataList)
            {
                if (ModelSpecData.ModelName == modelName)
                {
                    firstHitProb = ModelSpecData.FirstHitProb;
                    break;
                }
            }
            //始点
            DataMakers.Points.AddXY(Convert.ToDouble(0), firstHitProb);

            //終点
            if (DispFirstHitRotateCountList.Count > 20)
            {

                DataMakers.Points.AddXY(Convert.ToDouble(DispFirstHitRotateCountList.Count), firstHitProb);
            }
            else
            {
                DataMakers.Points.AddXY(Convert.ToDouble(ChartFirstHitCompProb.ChartAreas[0].AxisX.ScaleView.Size), firstHitProb);
            }
            DataMakers.Color = Color.Magenta;
            ChartFirstHitCompProb.Series.Add(DataMakers);
            #endregion

            //平滑線グラフ
            DataMakers = new Series();
            DataMakers.ChartType = SeriesChartType.Line;
            //DataMakers.ChartType = SeriesChartType.Spline;
            DataMakers.BorderWidth = 2;
            DataMakers.Color = Color.YellowGreen;
            dataMakerCount = 0;

            if (modelName != null && unitNum != null)
            {
                ClassCalcFirstHitCompProb CalcFirstHitCompProb = new ClassCalcFirstHitCompProb();
                int sampleNum = 20;

                //初当り合成確率の計算
                List<double> FirstHitCompProbList = CalcFirstHitCompProb.CalcFirstHitCompProb(modelName, unitNum, sampleNum, "SMA");

                if (FirstHitCompProbList.Count != 0)
                {
                    //デバッグ用
                    DataMakers.Points.AddXY(Convert.ToDouble(0), 320);
                    dataMakerCount = sampleNum; 
                    
                    for (int i = 0; i < FirstHitCompProbList.Count; i++)
                    {
                        DataMakers.Points.AddXY(Convert.ToDouble(dataMakerCount), FirstHitCompProbList[i]);
                        dataMakerCount++;
                    }
                }
            }
            else
            {
                DataMakers.Points.AddXY(0.5, 0);
            }
            ChartFirstHitCompProb.Series.Add(DataMakers);

            //平滑線グラフ
            DataMakers = new Series();
            DataMakers.ChartType = SeriesChartType.Line;
            //DataMakers.ChartType = SeriesChartType.Spline;
            DataMakers.BorderWidth = 2;
            DataMakers.Color = Color.Aqua;
            dataMakerCount = 0;

            if (modelName != null && unitNum != null)
            {
                ClassCalcFirstHitCompProb CalcFirstHitCompProb = new ClassCalcFirstHitCompProb();
                int sampleNum = 5;

                //初当り合成確率の計算
                List<double> FirstHitCompProbList = CalcFirstHitCompProb.CalcFirstHitCompProb(modelName, unitNum, sampleNum, "SMA");

                if (FirstHitCompProbList.Count != 0)
                {
                    //デバッグ用
                    DataMakers.Points.AddXY(Convert.ToDouble(0), 320);
                    dataMakerCount = sampleNum;

                    for (int i = 0; i < FirstHitCompProbList.Count; i++)
                    {
                        DataMakers.Points.AddXY(Convert.ToDouble(dataMakerCount), FirstHitCompProbList[i]);
                        dataMakerCount++;
                    }
                }
            }
            else
            {
                DataMakers.Points.AddXY(0.5, 0);
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

                                        //default:
                                        //    //初当りがない場合は除外(定休日または故障台含む)
                                        //    if (DailyData.HistoryDataList[i].HitType == -1)
                                        //    {
                                        //        DispFirstHitRotateCount = new ClassDispFirstHitRotateCount();
                                        //        DispFirstHitRotateCount.RotateCount = -1;
                                        //        DispFirstHitRotateCount.HitType = -1;
                                        //        DispFirstHitRotateCount.ProbVarHitCount = -1;
                                        //        DispFirstHitRotateCountList.Add(DispFirstHitRotateCount);
                                        //    }
                                        //    break;
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
