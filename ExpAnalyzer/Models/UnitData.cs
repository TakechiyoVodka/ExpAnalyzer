using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    internal class UnitData
    {
        /// <summary>
        /// 台番号
        /// </summary>
        public string UnitNum { get; set; }
        /// <summary>
        /// デイリーデータリスト
        /// </summary>
        public List<DailyData> DailyDataList { get; set; }
    }
}
