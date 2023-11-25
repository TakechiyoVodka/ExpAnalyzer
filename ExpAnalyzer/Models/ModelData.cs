using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 機種データクラス
    /// </summary>
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

    /// <summary>
    /// 機種スペックデータクラス
    /// </summary>
    public class ClassModelDetailsInfo
    {
        /// <summary>
        /// 機種名
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// 初当り確率 [1/n]
        /// </summary>
        public int FirstHitProb { get; set; }
        /// <summary>
        /// 確変当り確率 [1/n]
        /// </summary>
        public int ProbVarHitProb { get; set; }
        /// <summary>
        /// 確変突入率 [%]
        /// </summary>
        public int ProbVarHitRashRate { get; set; }
        /// <summary>
        /// 確変継続率 [%]
        /// </summary>
        public int ProbVarHitPersisRate { get; set; }
        /// <summary>
        /// ST [回転数]
        /// </summary>
        public int SpecialTime { get; set; }
        /// <summary>
        /// 時短回数 [回転数]
        /// </summary>
        public int SavingTime { get; set; }
        /// <summary>
        /// Cタイム [回転数]
        /// </summary>
        public int CTime { get; set; }
    }
}
