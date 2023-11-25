using System;
using System.Collections.Generic;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 機種データクラス
    /// </summary>
    internal class ClassModelData
    {
        /// <summary>
        /// 機種名
        /// </summary>
        internal string ModelName { get; set; }
        /// <summary>
        /// 設置台数
        /// </summary>
        internal int InstallNum { get; set; }
        /// <summary>
        /// 台データリスト
        /// </summary>
        internal List<ClassUnitData> UnitDataList = new List<ClassUnitData>();
    }

    /// <summary>
    /// 機種スペックデータクラス
    /// </summary>
    internal class ClassModelSpecData
    {
        /// <summary>
        /// 機種名
        /// </summary>
        internal string ModelName { get; set; }
        /// <summary>
        /// 初当り確率 [1/n]
        /// </summary>
        internal double FirstHitProb { get; set; }
        /// <summary>
        /// 確変当り確率 [1/n]
        /// </summary>
        internal double ProbVarHitProb { get; set; }
        /// <summary>
        /// 確変突入率 [%]
        /// </summary>
        internal double ProbVarHitRashRate { get; set; }
        /// <summary>
        /// 確変継続率 [%]
        /// </summary>
        internal double ProbVarHitPersisRate { get; set; }
        /// <summary>
        /// ST [回転数]
        /// </summary>
        internal int SpecialTime { get; set; }
        /// <summary>
        /// 時短回数 [回転数]
        /// </summary>
        internal int SavingTime { get; set; }
        /// <summary>
        /// Cタイム [回転数]
        /// </summary>
        internal int CTime { get; set; }
    }
}
