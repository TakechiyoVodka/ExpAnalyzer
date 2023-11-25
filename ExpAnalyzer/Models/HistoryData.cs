using System;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 履歴データクラス
    /// </summary>
    internal class ClassHistoryData
    {
        /// <summary>
        /// 回転数
        /// </summary>
        internal int RotateCount { get; set; }
        /// <summary>
        /// 大当り種別
        /// </summary>
        internal int HitType { get; set; }
    }
}
