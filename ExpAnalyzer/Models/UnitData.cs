using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 台データクラス
    /// </summary>
    public class ClassUnitData
    {
        /// <summary>
        /// 台番号
        /// </summary>
        public string UnitNum { get; set; }
        /// <summary>
        /// デイリーデータリスト
        /// </summary>
        public List<ClassDailyData> DailyDataList = new List<ClassDailyData>();
    }
}
