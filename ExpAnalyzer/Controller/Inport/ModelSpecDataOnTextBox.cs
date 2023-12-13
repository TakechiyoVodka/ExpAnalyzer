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
    /// 機種スペックデータのテキストボックスクラス
    /// </summary>
    internal class ClassModelSpecDataOnTextBox
    {
        /// <summary>
        /// テキストボックスへ機種スペック情報を表示
        /// </summary>
        internal void DispModelSpecDataOnTextBox(
            TextBox TextBoxFirstHitProb,
            TextBox TextBoxProbVarHitProb,
            TextBox TextBoxProbVarHitRashRate,
            TextBox TextBoxProbVarHitPersisRate,
            TextBox TextBoxSpecialTime,
            TextBox TextBoxSavingTime,
            TextBox TextBoxCTime,
            List<ClassModelSpecData> ModelSpecDataList,
            string modelName)
        {
            foreach(ClassModelSpecData ModelSpecData in ModelSpecDataList)
            {
                //選択中の機種スペック情報を抽出
                if (ModelSpecData.ModelName == modelName)
                {
                    //初当り確率
                    TextBoxFirstHitProb.Text = ModelSpecData.FirstHitProb != -1 ? String.Concat("1/", Convert.ToString(ModelSpecData.FirstHitProb)) : "-";

                    //確変当り確率
                    TextBoxProbVarHitProb.Text = ModelSpecData.ProbVarHitProb != -1 ? String.Concat("1/", Convert.ToString(ModelSpecData.ProbVarHitProb)) : "-";

                    //確変突入率
                    TextBoxProbVarHitRashRate.Text = ModelSpecData.ProbVarHitRashRate != -1 ? String.Concat(Convert.ToString(ModelSpecData.ProbVarHitRashRate), "%") : "-";

                    //確変継続率
                    TextBoxProbVarHitPersisRate.Text = ModelSpecData.ProbVarHitPersisRate != -1 ? String.Concat(Convert.ToString(ModelSpecData.ProbVarHitPersisRate), "%") : "-";

                    //ST
                    TextBoxSpecialTime.Text = ModelSpecData.SpecialTime != -1 ? String.Concat(Convert.ToString(ModelSpecData.SpecialTime), "回") : "-";

                    //時短回数
                    TextBoxSavingTime.Text = ModelSpecData.SavingTime != -1 ? String.Concat(Convert.ToString(ModelSpecData.SavingTime), "回") : "-";

                    //CT
                    TextBoxCTime.Text = ModelSpecData.CTime != -1 ? String.Concat(Convert.ToString(ModelSpecData.CTime), "回") : "-";
                    break;
                }
            }
            return;
        }
    }
}
