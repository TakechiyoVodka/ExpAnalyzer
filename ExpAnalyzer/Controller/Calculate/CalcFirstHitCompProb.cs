using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExpAnalyzer.Controller.Calculate.ClassCalcMovingAverage;

namespace ExpAnalyzer.Controller.Calculate
{
    internal class ClassCalcFirstHitCompProb
    {
        /// <summary>
        /// 初当り合成確率を計算
        /// </summary>
        internal List<double> CalcFirstHitCompProb(string modelName, string unitNum, int sampleNum, string aveValueType)
        {
            ClassCalcMovingAverage CalcMovingAverage = new ClassCalcMovingAverage();
            List<int> FirstHitRotateCountList = new List<int>();
            List<double> FirstHitCompProbList = new List<double>();

            foreach (ClassModelData ModelData in FormMain.FormatHallData.ModelDataList)
            {
                if (ModelData.ModelName == modelName)
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        if (UnitData.UnitNum == unitNum)
                        {
                            foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                            {
                                foreach (ClassHistoryData HistoryData in DailyData.HistoryDataList)
                                {
                                    //整形後ホールデータから初当り回転数を抽出
                                    if (HistoryData.HitType == 1 || HistoryData.HitType == 3)
                                    {
                                        FirstHitRotateCountList.Add(HistoryData.RotateCount);
                                    }
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            //移動平均値を計算
            FirstHitCompProbList = CalcMovingAverage.CalcMovingAverage(FirstHitRotateCountList, sampleNum, aveValueType);

            return FirstHitCompProbList;
        }
    }
}
