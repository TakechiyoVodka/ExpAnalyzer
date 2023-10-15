using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    public class ClassModelData
    {
        /// <summary>
        /// 機種名
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 設置台数
        /// </summary>
        public int InstallNum { get; set; }
        /// <summary>
        /// 台データリスト
        /// </summary>
        public List<ClassUnitData> UnitDataList = new List<ClassUnitData>();
    }
}
