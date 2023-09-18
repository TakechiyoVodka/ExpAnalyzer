using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    internal class ClassModelData
    {
        /// <summary>
        /// 機種名
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 設置台数
        /// </summary>
        public string InstallNum { get; set; }
        /// <summary>
        /// 台データリスト
        /// </summary>
        public List<ClassUnitData> UnitDataList { get; set; }
    }
}
