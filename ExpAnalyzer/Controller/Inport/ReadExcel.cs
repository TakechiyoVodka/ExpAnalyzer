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

namespace ExpAnalyzer.Controller.Inport
{
    internal class ClassReadExcel
    {
        /// <summary>
        /// データ種別定義
        /// </summary>
        public const string MODEL_NAME = "機種名";
        public const string INSTALL_NUMBER = "設置台数";
        public const string RTATE_COUNT = "回転数";
        public const string HIT_STATUS = "ステータス";

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
                            bool endUnitFlg = false;

                            for (int j = 2; j <= Worksheet.Columns.EndColumn + 1; j++)
                            {
                                if (j == 2 && Convert.ToString(Worksheet.Cells[i, j].Value) != "")
                                {
                                    switch (Convert.ToString(Worksheet.Cells[i, j].Value))
                                    {
                                        //機種名
                                        case MODEL_NAME:

                                            if (Convert.ToString(Worksheet.Cells[i, j + 1].Value) == "")
                                            {
                                                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, j + 1), ")の機種名の取得に失敗しました。"));
                                            }
                                            ModelData.ModelName = Convert.ToString(Worksheet.Cells[i, j + 1].Value);
                                            break;

                                        //設置台数
                                        case INSTALL_NUMBER:

                                            if (int.TryParse(Convert.ToString(Worksheet.Cells[i, j + 1].Value), out int installNum) != true)
                                            {
                                                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, j + 1), ")の設置台数の取得に失敗しました。"));
                                            }
                                            ModelData.InstallNum = installNum;
                                            break;

                                        //台番号
                                        default:

                                            if (Regex.IsMatch(Convert.ToString(Worksheet.Cells[i, j].Value), "^\\d+$") != true)
                                            {
                                                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, j), ")の台番号の取得に失敗しました。"));
                                            }
                                            UnitData.UnitNum = Convert.ToString(Worksheet.Cells[i, j].Value);
                                            unitCount++;
                                            continue;
                                    }
                                }
                                else
                                {
                                    if (DateTime.TryParse(Convert.ToString(Worksheet.Cells[i, j].Value), out DateTime dateTime) == true)
                                    {
                                        //回転数と大当りステータスの取得
                                        ClassDailyData DailyData = GetRotateCountAndHitStatus(Worksheet, i, j, dateTime);

                                        UnitData.DailyDataList.Add(DailyData);
                                        j++;
                                        continue;
                                    }
                                    else
                                    {
                                        if (Convert.ToString(Worksheet.Cells[i + 1, j].Value) == RTATE_COUNT
                                            || Convert.ToString(Worksheet.Cells[i + 1, j + 1].Value) == HIT_STATUS)
                                        {
                                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(i, j), ")の日付情報の取得に失敗しました。"));
                                        }
                                        else
                                        {
                                            if (UnitData.UnitNum != null && UnitData.DailyDataList.Count != 0)
                                            {
                                                //1台毎の台データをリストへ追加
                                                ModelData.UnitDataList.Add(UnitData);

                                                //最終台のデータ取得が完了するまで探索
                                                if (ModelData.InstallNum - unitCount != 0)
                                                {
                                                    i += 103;
                                                }
                                                else
                                                {
                                                    endUnitFlg = true;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            if (endUnitFlg == true)
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
        /// 回転数と大当りステータスの取得
        /// </summary>
        private static ClassDailyData GetRotateCountAndHitStatus(ExcelWorksheet Worksheet, int row, int column, DateTime dateTime)
        {
            ClassDailyData DailyData = new ClassDailyData();

            //日付
            DailyData.Date = dateTime;

            //Excel共通関数
            ClassExcelCommonFunction ExcelComFunc = new ClassExcelCommonFunction();

            if (Convert.ToString(Worksheet.Cells[row + 1, column].Value) == RTATE_COUNT
                && Convert.ToString(Worksheet.Cells[row + 1, column + 1].Value) == HIT_STATUS)
            {
                ClassHistoryData HistoryData;
                bool convRotateCntResult = false;
                bool convHitStatusResult = false;
                int rotateCount = 0;
                int hitStatus = 0;

                row += 2;

                if (Convert.ToString(Worksheet.Cells[row, column + 1].Value) != "-")
                {
                    //ステータス(0)でない場合は探索
                    while (int.Parse(Convert.ToString(Worksheet.Cells[row, column + 1].Value)) != 0)
                    {
                        HistoryData = new ClassHistoryData();
                        convRotateCntResult = int.TryParse(Convert.ToString(Worksheet.Cells[row, column].Value), out rotateCount);
                        convHitStatusResult = int.TryParse(Convert.ToString(Worksheet.Cells[row, column + 1].Value), out hitStatus);

                        if (convRotateCntResult == true)
                        {
                            //回転数
                            HistoryData.RotateCount = rotateCount;
                        }
                        else
                        {
                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column), ")の回転数の取得に失敗しました。"));
                        }

                        if (convHitStatusResult == true)
                        {
                            //ステータス
                            HistoryData.HitStatus = hitStatus;
                        }
                        else
                        {
                            throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column + 1), ")のステータスの取得に失敗しました。"));
                        }
                        DailyData.HistoryDataList.Add(HistoryData);
                        row++;
                    }
                    HistoryData = new ClassHistoryData();

                    //ステータス(0)を1行だけ取得
                    convRotateCntResult = int.TryParse(Convert.ToString(Worksheet.Cells[row, column].Value), out rotateCount);
                    convHitStatusResult = int.TryParse(Convert.ToString(Worksheet.Cells[row, column + 1].Value), out hitStatus);

                    if (convRotateCntResult == true)
                    {
                        //回転数
                        HistoryData.RotateCount = rotateCount;
                    }
                    else
                    {
                        throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column), ")の回転数の取得に失敗しました。"));
                    }

                    if (convHitStatusResult == true)
                    {
                        //ステータス
                        HistoryData.HitStatus = hitStatus;
                    }
                    else
                    {
                        throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column + 1), ")のステータスの取得に失敗しました。"));
                    }
                    DailyData.HistoryDataList.Add(HistoryData);
                }
                else
                {
                    //定休日または故障台
                    HistoryData = new ClassHistoryData();
                    HistoryData.RotateCount = -1;
                    HistoryData.HitStatus = -1;
                    DailyData.HistoryDataList.Add(HistoryData);
                }
            }
            else
            {
                throw new Exception(string.Concat("セル(", ExcelComFunc.ConvertNumToRange(row, column), ")の値が不正です。"));
            }
            return DailyData;
        }
    }
}
