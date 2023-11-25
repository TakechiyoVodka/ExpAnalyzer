using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// ホールデータクラス
    /// </summary>
    internal class ClassHallData
    {
        /// <summary>
        /// ホール名
        /// </summary>
        internal string HallName { get; set; }
        /// <summary>
        /// 機種データリスト
        /// </summary>
        internal List<ClassModelData> ModelDataList = new List<ClassModelData>();
    }
}
