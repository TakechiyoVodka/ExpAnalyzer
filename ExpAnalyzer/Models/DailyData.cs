using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    internal class DailyData
    {
        /// <summary>
        /// 日付情報
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 履歴データリスト
        /// </summary>
        public List<HistoryData> HistoryDataList { get; set; }
    }
}
