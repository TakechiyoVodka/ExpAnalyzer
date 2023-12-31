using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpAnalyzer.Controller.Calculate
{
    internal class ClassCalcMovingAverage
    {
        /// <summary>
        /// 移動平均種別定義
        /// </summary>
        private const string SIMPLE_MA = "SMA";
        private const string EXPONENTIAL_MA = "EMA";
        private const string WEIGHTED_MA = "WMA";

        /// <summary>
        /// 移動平均値を計算
        /// </summary>
        internal List<double> CalcMovingAverage(List<int> DataList, int sampleNum, string averageType)
        {
            List<double> MovingAverageList = new List<double>();

            switch (averageType)
            {
                //単純移動平均(SMA)
                case SIMPLE_MA:

                    for (int i = 0; i < DataList.Count; i++)
                    {
                        int totalValue = 0;
                        int currentIdx = i;
                        int lastIdx = i + sampleNum - 1;

                        if (lastIdx < DataList.Count)
                        {
                            while (currentIdx <= lastIdx)
                            {
                                totalValue += DataList[currentIdx];
                                currentIdx++;
                            }
                            MovingAverageList.Add(Convert.ToDouble(totalValue / sampleNum));
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;

                //指数平滑移動平均(EMA)
                case EXPONENTIAL_MA:

                    for (int i = 0; i < DataList.Count; i++)
                    {
                        int totalValue = 0;
                        int currentIdx = i;
                        int lastIdx = i + sampleNum - 1;

                        if (lastIdx < DataList.Count)
                        {
                            while (currentIdx <= lastIdx)
                            {
                                totalValue += DataList[currentIdx];

                                if (currentIdx == lastIdx)
                                {
                                    totalValue += DataList[currentIdx];
                                }
                                currentIdx++;
                            }
                            MovingAverageList.Add(Convert.ToDouble(totalValue / sampleNum + 1));
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;

                //加重移動平均(WMA)
                case WEIGHTED_MA:

                    for (int i = 0; i < DataList.Count; i++)
                    {
                        int totalValue = 0;
                        int currentIdx = i;
                        int lastIdx = i + sampleNum - 1;

                        if (lastIdx < DataList.Count)
                        {
                            int multiplier = 1;
                            int divisor = 0;

                            while (currentIdx <= lastIdx)
                            {
                                totalValue += DataList[currentIdx] * multiplier;
                                divisor += multiplier;
                                currentIdx++;
                                multiplier++;
                            }
                            MovingAverageList.Add(Convert.ToDouble(totalValue / divisor));
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }
            return MovingAverageList;
        }
    }
}
