using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// デイリーデータクラス
    /// </summary>
    internal class ClassDailyData
    {
        /// <summary>
        /// 日付
        /// </summary>
        internal DateTime DateTime { get; set; }
        /// <summary>
        /// 履歴データリスト
        /// </summary>
        internal List<ClassHistoryData> HistoryDataList = new List<ClassHistoryData>();
    }
}
