using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    internal class HallData
    {
        /// <summary>
        /// ホール名
        /// </summary>
        public string HallName { get; set; }
        /// <summary>
        /// 機種データリスト
        /// </summary>
        public List<ModelData> ModelDataList { get; set; }
    }
}
