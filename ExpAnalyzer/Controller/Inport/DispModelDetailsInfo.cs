using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpAnalyzer.Controller.Inport
{
    /// <summary>
    /// 表示用機種スペックデータクラス
    /// </summary>
    internal class ClassDispModelDetailsInfo
    {
        /// <summary>
        /// テキストボックスへ機種スペック情報を表示
        /// </summary>
        public void DispModelDetailsInfoOnTextBox(
            TextBox TextBoxFirstHitProb,
            TextBox TextBoxProbVarHitProb,
            TextBox TextBoxProbVarHitRashRate,
            TextBox TextBoxProbVarHitPersisRate,
            TextBox TextBoxSpecialTime,
            TextBox TextBoxSavingTime,
            TextBox TextBoxCTime,
            List<ClassModelDetailsInfo> ModelDetailsInfoList,
            string modelName)
        {
            foreach(ClassModelDetailsInfo ModelDetailsInfo in ModelDetailsInfoList)
            {
                //選択中の機種スペック情報を抽出
                if (ModelDetailsInfo.ModelName == modelName)
                {
                    //初当り確率
                    TextBoxFirstHitProb.Text
                        = ModelDetailsInfo.FirstHitProb != -1 ? String.Concat("1/", Convert.ToString(ModelDetailsInfo.FirstHitProb)) : "-";

                    //確変当り確率
                    TextBoxProbVarHitProb.Text
                        = ModelDetailsInfo.ProbVarHitProb != -1 ? String.Concat("1/", Convert.ToString(ModelDetailsInfo.ProbVarHitProb)) : "-";

                    //確変突入率
                    TextBoxProbVarHitRashRate.Text
                        = ModelDetailsInfo.ProbVarHitRashRate != -1 ? String.Concat(Convert.ToString(ModelDetailsInfo.ProbVarHitRashRate), "%") : "-";

                    //確変継続率
                    TextBoxProbVarHitPersisRate.Text
                        = ModelDetailsInfo.ProbVarHitPersisRate != -1 ? String.Concat(Convert.ToString(ModelDetailsInfo.ProbVarHitPersisRate), "%") : "-";

                    //ST
                    TextBoxSpecialTime.Text
                        = ModelDetailsInfo.SpecialTime != -1 ? String.Concat(Convert.ToString(ModelDetailsInfo.SpecialTime), "回") : "-";

                    //時短回数
                    TextBoxSavingTime.Text
                        = ModelDetailsInfo.SavingTime != -1 ? String.Concat(Convert.ToString(ModelDetailsInfo.SavingTime), "回") : "-";

                    //CT
                    TextBoxCTime.Text
                        = ModelDetailsInfo.CTime != -1 ? String.Concat(Convert.ToString(ModelDetailsInfo.CTime), "回") : "-";

                    break;
                }
            }
            return;
        }
    }
}
