using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    internal class ClassUnitData
    {
        /// <summary>
        /// 台番号
        /// </summary>
        public string UnitNum { get; set; }
        /// <summary>
        /// デイリーデータリスト
        /// </summary>
        public List<ClassDailyData> DailyDataList { get; set; }
    }
}
