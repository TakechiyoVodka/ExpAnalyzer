using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpAnalyzer.Models
{
    /// <summary>
    /// 共通変数クラス
    /// </summary>
    internal class ClassCommonVariableDefine
    {
        /// <summary>
        /// 機種スペックデータファイルパス
        /// </summary>
        internal string ModelSpecDataFilePath { get; set; }

        /// <summary>
        /// ホールデータファイルパス
        /// </summary>
        internal string HallDataFilePath { get; set; }
    }
}
