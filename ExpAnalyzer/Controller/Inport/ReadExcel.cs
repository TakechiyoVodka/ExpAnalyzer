using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using ExpAnalyzer.Controller.Common;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace ExpAnalyzer.Controller.Inport
{
    /// <summary>
    /// 読込みExcelデータクラス
    /// </summary>
    internal class ClassReadExcel
    {
        /// <summary>
        /// 定数定義
        /// </summary>
        public const int DEFAULT_COLUMN = 2;
        public const int SKIP_CELL_COUNT = 103;

        /// <summary>
        /// データ種別定義
        /// </summary>
        public const string MODEL_NAME = "機種名";
        public const string INSTALL_NUMBER = "設置台数";
        public const string RTATE_COUNT = "回転数";
        public const string HIT_TYPE = "大当り種別";

        /// <summary>
        /// Excelからホールデータを読込み
        /// </summary>
        public ClassHallData ReadHallDataFromExcel(string InportWorkBookPath)
        {
            ClassHallData HallData = new ClassHallData();

            //Excelを読み取り専用で開く
            using (FileStream fs = new FileStream(InportWorkBookPath, FileMode.Open, FileAccess.Read))
            {
                //Excel共通関数
                ClassExcelCommonFunction　ExcelComFunc = new ClassExcelCommonFunction();

                using (ExcelPackage ExcelPkg = new ExcelPackage(InportWorkBookPath))
                {
                    //デバッグモードでの例外回避
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    //Excelワークブック
                    ExcelWorkbook Workbook = new ExcelPackage(InportWorkBookPath).Workbook;

                    string workbookFileName = Path.GetFileNameWithoutExtension(InportWorkBookPath);
                    string hallName = workbookFileName.Substring(workbookFileName.IndexOf("パチンコデータ_") + 8);

                    //店舗名を取得
                    HallData.HallName = hallName;

                    foreach (ExcelWorksheet Worksheet in Workbook.Worksheets)
                    {
                        if (Worksheet.Name == "機種情報")
                        {
                            continue;
                        }
                        ClassModelData ModelData = new ClassModelData();
                        int unitCount = 0;

                        for (int i = 1; i <= Worksheet.Rows.EndRow; i++)
                        {
                            ClassUnitData UnitData = new ClassUnitData();

                            switch (Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN].Value))
                            {
                                //機種名
                                case MODEL_NAME:

                                    if (Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN + 1].Value) == "")
                                    {
                                        throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, DEFAULT_COLUMN + 1), ")の機種名の取得に失敗しました。"));
                                    }
                                    ModelData.ModelName = Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN + 1].Value);
                                    break;

                                //設置台数
                                case INSTALL_NUMBER:

                                    if (int.TryParse(Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN + 1].Value), out int installNum) != true)
                                    {
                                        throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, DEFAULT_COLUMN + 1), ")の設置台数の取得に失敗しました。"));
                                    }
                                    ModelData.InstallNum = installNum;
                                    break;

                                //台番号
                                default:

                                    if (Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN].Value) != "")
                                    {
                                        if (Regex.IsMatch(Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN].Value), "^\\d+$") != true)
                                        {
                                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, DEFAULT_COLUMN), ")の台番号の取得に失敗しました。"));
                                        }
                                        UnitData.UnitNum = Convert.ToString(Worksheet.Cells[i, DEFAULT_COLUMN].Value);

                                        //回転数と大当り種別の取得
                                        UnitData.DailyDataList = GetRotateCountAndHitStatus(Worksheet, i, DEFAULT_COLUMN);

                                        //1台毎の台データをリストへ追加
                                        ModelData.UnitDataList.Add(UnitData);
                                        unitCount++;

                                        i += SKIP_CELL_COUNT;
                                    }
                                    break;
                            }
                            //全ての台データ取得が完了したら探索終了
                            if (ModelData.InstallNum != 0 && unitCount == ModelData.InstallNum)
                            {
                                break;
                            }
                        }
                        HallData.ModelDataList.Add(ModelData);
                    }
                }
            }
            return HallData;
        }

        /// <summary>
        /// 回転数と大当り種別の取得
        /// </summary>
        private static List<ClassDailyData> GetRotateCountAndHitStatus(ExcelWorksheet Worksheet, int defRow, int defColumn)
        {
            //Excel共通関数
            ClassExcelCommonFunction ExcelComFunc = new ClassExcelCommonFunction();
            List<ClassDailyData> DayliDataList = new List<ClassDailyData>();

            for (int column = defColumn + 1; column < Worksheet.Columns.EndColumn; column++)
            {
                ClassDailyData DailyData = new ClassDailyData();

                if (DateTime.TryParse(Convert.ToString(Worksheet.Cells[defRow, column].Value), out DateTime dateTime) == true)
                {
                    //日付
                    DailyData.DateTime = dateTime;

                    if (Convert.ToString(Worksheet.Cells[defRow + 1, column].Value) == RTATE_COUNT
                        && Convert.ToString(Worksheet.Cells[defRow + 1, column + 1].Value) == HIT_TYPE)
                    {
                        int row = defRow + 2;

                        if (Convert.ToString(Worksheet.Cells[row, column].Value) == "-"
                            || Convert.ToString(Worksheet.Cells[row, column + 1].Value) == "-")
                        {
                            //定休日または故障台
                            ClassHistoryData HistoryData = new ClassHistoryData();
                            HistoryData.RotateCount = -1;
                            HistoryData.HitType = -1;
                            DailyData.HistoryDataList.Add(HistoryData);
                        }
                        else
                        {
                            ClassHistoryData HistoryData = new ClassHistoryData();
                            int rotateCount = 0;
                            int hitType = 0;

                            //大当り種別(0)でない場合は探索
                            while (int.Parse(Convert.ToString(Worksheet.Cells[row, column + 1].Value)) != 0)
                            {
                                HistoryData = new ClassHistoryData();

                                //回転数
                                if (int.TryParse(Convert.ToString(Worksheet.Cells[row, column].Value), out rotateCount) != true)
                                {
                                    throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column), ")の回転数の取得に失敗しました。"));
                                }
                                HistoryData.RotateCount = rotateCount;

                                //大当り種別
                                if (int.TryParse(Convert.ToString(Worksheet.Cells[row, column + 1].Value), out hitType) != true)
                                {
                                    throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column + 1), ")の大当り種別の取得に失敗しました。"));
                                }
                                HistoryData.HitType = hitType;

                                DailyData.HistoryDataList.Add(HistoryData);
                                row++;
                            }
                            //大当り種別(0)を1行だけ取得 (残スタート回転数)
                            HistoryData = new ClassHistoryData();

                            //回転数

                            if (int.TryParse(Convert.ToString(Worksheet.Cells[row, column].Value), out rotateCount) != true)
                            {
                                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column), ")の回転数の取得に失敗しました。"));
                            }
                            HistoryData.RotateCount = rotateCount;

                            //大当り種別
                            if (int.TryParse(Convert.ToString(Worksheet.Cells[row, column + 1].Value), out hitType) != true)
                            {
                                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column + 1), ")の大当り種別の取得に失敗しました。"));
                            }
                            HistoryData.HitType = hitType;

                            DailyData.HistoryDataList.Add(HistoryData);
                        }
                        DayliDataList.Add(DailyData);
                        column++;
                    }
                    else
                    {
                        if (Convert.ToString(Worksheet.Cells[defRow + 1, column].Value) != RTATE_COUNT)
                        {
                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(defRow + 1, column), ")の記載が不正です。"));
                        }
                        else
                        {
                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(defRow + 1, column + 1), ")の記載が不正です。"));
                        }
                    }
                }
                else
                {
                    throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(defRow, column), ")の日付の取得に失敗しました。"));
                }
            }
            return DayliDataList;
        }
    }
}
