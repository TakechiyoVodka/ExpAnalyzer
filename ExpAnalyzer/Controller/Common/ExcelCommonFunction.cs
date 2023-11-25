using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpAnalyzer.Controller.Common
{
    /// <summary>
    /// Excel共通関数クラス
    /// </summary>
    internal class ClassExcelCommonFunction
    {
        /// <summary>
        /// Excelのセル番号を範囲表記へ変換
        /// </summary>
        public string ConvertNumToRange(int row, int column)
        {
            string range = string.Empty;
            string alphabet = string.Empty;

            while (column > 0)
            {
                column--;
                alphabet = Convert.ToChar(column % 26 + 65) + alphabet;
                column = column / 26;
            }
            
            if (alphabet != string.Empty)
            {
                range = string.Concat(alphabet, row);
            }
            else
            {
                throw new Exception("Excelのセル番号の変換に失敗しました。");
            }
            return range;
        }
    }
}
