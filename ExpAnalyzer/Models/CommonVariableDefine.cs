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
    public class ClassCommonVariableDefine
    {
        /// <summary>
        /// 入力機種情報ファイルパス
        /// </summary>
        public string InputInitFilePath { get; set; }

        /// <summary>
        /// 入力Excelファイルパス
        /// </summary>
        public string InputExcelFilePath { get; set; }
    }
}
