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
    /// 機種データのコンボボックスクラス
    /// </summary>
    internal class ClassModelDataOnComboBox
    {
        /// <summary>
        /// 機種データをコンボボックスへ表示
        /// </summary>
        internal void DispModelDataOnComboBox(ComboBox ComboBoxModelName)
        {
            //コンボボックス初期化
            ComboBoxModelName.Items.Clear();

            foreach (ClassModelData ModelData in FormMain.HallData.ModelDataList)
            {
                ComboBoxModelName.Items.Add(ModelData.ModelName);
            }
            ComboBoxModelName.SelectedIndex = 0;

            return;
        }
    }
}
