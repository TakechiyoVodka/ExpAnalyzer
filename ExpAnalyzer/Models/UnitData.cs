using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 台データクラス
    /// </summary>
    internal class ClassUnitData
    {
        /// <summary>
        /// 台番号
        /// </summary>
        internal string UnitNum { get; set; }
        /// <summary>
        /// デイリーデータリスト
        /// </summary>
        internal List<ClassDailyData> DailyDataList = new List<ClassDailyData>();
    }
}
