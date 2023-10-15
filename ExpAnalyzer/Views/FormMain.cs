using ExpAnalyzer.Controller.Inport;
using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpAnalyzer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        #region 静的フィールド
        public static ClassDefine Define;
        public static ClassHallData HallData;
        //public static List<ClassHallData> HallDataList;
        #endregion
        /// <summary>
        /// 参照ボタンクリックイベント
        /// </summary>
        private void ButtonReference_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenFileダイアログ表示
                OpenFileDialog Ofd = new OpenFileDialog();

                Ofd.FileName = "";
                Ofd.InitialDirectory = @"%UserProfile%\Documents";
                Ofd.Filter = "Excelブック(*.xlsx)|*.xlsx|Excelマクロ有効ブック(*.xlsm)|*.xlsm|すべてのファイル(*.*)|*.*";
                Ofd.FilterIndex = 1;
                Ofd.Title = "読込むファイルを選択してください";
                Ofd.RestoreDirectory = true;
                Ofd.CheckFileExists = true;
                Ofd.CheckPathExists = true;

                if (Ofd.ShowDialog() == DialogResult.OK)
                {
                    Define = new ClassDefine();

                    Define.InputWorkbookPath = Ofd.FileName;
                    TextBoxReadDataPath.Text = Ofd.FileName;
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }
        /// <summary>
        /// Excelデータ読み込みボタンクリックイベント
        /// </summary>
        private void ButtonReadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Define.InputWorkbookPath) == true)
                {
                    ClassReadExcel ReadExcel = new ClassReadExcel();

                    //Excelからホールデータを読込み
                    HallData = ReadExcel.ReadHallDataFromExcel(Define.InputWorkbookPath);
                }
                else
                {
                    throw new Exception("指定されたExcelデータファイルが存在しません。");
                }
                return;
            }
            catch (Exception ex)
            {
                WinModuleLibrary.ErrorModule.ShowErrorLog(ex);
                return;
            }
        }
    }
}
