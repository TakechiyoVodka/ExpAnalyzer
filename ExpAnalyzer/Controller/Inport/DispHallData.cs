﻿using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpAnalyzer.Controller.Inport
{
    internal class ClassDispHallData
    {
        /// <summary>
        /// 台データクラス (DataGridView表示用)
        /// </summary>
        public class ClassDispUnitData
        {
            public string UnitNum;
            public DateTime Date;
            public int TotalFirstHitCount;
            public int TotalProbVarHitCount;
            public int TotalHitCount;
            public int TotalRotateCount;
            public int RemainRotateCount;
        }

        /// <summary>
        /// 機種データをコンボボックスへ表示
        /// </summary>
        public void DispModelDataInComboBox(ComboBox ComboBoxModelName, ClassHallData HallData)
        {
            //コンボボックス初期化
            ComboBoxModelName.Items.Clear();

            foreach (ClassModelData ModelData in HallData.ModelDataList)
            {
                ComboBoxModelName.Items.Add(ModelData.ModelName);
            }
            ComboBoxModelName.SelectedIndex = 0;

            return;
        }

        /// <summary>
        /// 台データをDataGridViewへ表示
        /// </summary>
        public void DispUnitDataInDataGridView(DataGridView DataGridViewUnitData, ClassHallData HallData, string SelectedModelName)
        {
            //DataGridViewへ表示する台データの計算
            List<ClassDispUnitData> DispUnitDataList = CalcDispUnitData(HallData, SelectedModelName);

            //DataTable作成
            DataTable dt = new DataTable();

            DataColumn dc_unitNumber = dt.Columns.Add("台番号");
            DataColumn dc_dateTime = dt.Columns.Add("日付");
            DataColumn dc_totalFirstHitCount = dt.Columns.Add("初当り回数");
            DataColumn dc_totalProbVarHitCount = dt.Columns.Add("確変回数");
            DataColumn dc_totalHitCount = dt.Columns.Add("初当り+確変");
            DataColumn dc_totalRotateCount = dt.Columns.Add("総回転数");
            DataColumn dc_remainRotateCount = dt.Columns.Add("残り回転数");

            foreach (ClassDispUnitData DispUnitData in DispUnitDataList)
            {
                DataRow dr = dt.NewRow();

                dr.SetField(dc_unitNumber, DispUnitData.UnitNum);
                dr.SetField(dc_dateTime, DispUnitData.Date.ToString("yyyy/MM/dd"));

                if (DispUnitData.TotalFirstHitCount != -1)
                {
                    dr.SetField(dc_totalFirstHitCount, DispUnitData.TotalFirstHitCount);
                    dr.SetField(dc_totalProbVarHitCount, DispUnitData.TotalProbVarHitCount);
                    dr.SetField(dc_totalHitCount, DispUnitData.TotalHitCount);
                    dr.SetField(dc_totalRotateCount, DispUnitData.TotalRotateCount);
                    dr.SetField(dc_remainRotateCount, DispUnitData.RemainRotateCount);
                }
                else
                {
                    //定休日または故障台は全て"-"で埋める
                    dr.SetField(dc_totalFirstHitCount, "-");
                    dr.SetField(dc_totalProbVarHitCount, "-");
                    dr.SetField(dc_totalHitCount, "-");
                    dr.SetField(dc_totalRotateCount, "-");
                    dr.SetField(dc_remainRotateCount, "-");
                }
                dt.Rows.Add(dr);
            }
            //DataGridViewへDataTableを反映
            DataGridViewUnitData.DataSource = dt;

            //各台データをグループ化
            Subro.Controls.DataGridViewGrouper DataGridViewUnitDataGrouper = new Subro.Controls.DataGridViewGrouper(DataGridViewUnitData);
            
            DataGridViewUnitDataGrouper.RemoveGrouping();
            DataGridViewUnitDataGrouper.SetGroupOn(DataGridViewUnitData.Columns[0]);

            return;
        }

        /// <summary>
        /// DataGridViewへ表示する台データの計算
        /// </summary>
        private List<ClassDispUnitData> CalcDispUnitData(ClassHallData HallData, string SelectedModelName)
        {
            List<ClassDispUnitData> DispUnitDataList = new List<ClassDispUnitData>();

            foreach (ClassModelData ModelData in HallData.ModelDataList)
            {
                //コンボボックスで選択中の機種から台データ取得
                if (ModelData.ModelName == SelectedModelName)
                {
                    foreach (ClassUnitData UnitData in ModelData.UnitDataList)
                    {
                        foreach (ClassDailyData DailyData in UnitData.DailyDataList)
                        {
                            ClassDispUnitData DispUnitData = new ClassDispUnitData();

                            int totalFirstHitCount = 0;
                            int totalProbVarHitCount = 0;
                            int totalHitCount = 0;
                            int totalRotateCount = 0;
                            int remainRotateCount = 0;

                            //台番号
                            DispUnitData.UnitNum = UnitData.UnitNum;

                            //日付
                            DispUnitData.Date = DailyData.Date;

                            foreach (ClassHistoryData HistoryData in DailyData.HistoryDataList)
                            {
                                switch (HistoryData.HitStatus)
                                {
                                    case 0:
                                        remainRotateCount = HistoryData.RotateCount;
                                        break;
                                    case 1:
                                        totalFirstHitCount++;
                                        totalHitCount++;
                                        totalRotateCount += HistoryData.RotateCount;
                                        break;
                                    case 2:
                                        totalProbVarHitCount++;
                                        totalHitCount++;
                                        totalRotateCount += HistoryData.RotateCount;
                                        break;
                                    default:
                                        //定休日または故障台
                                        if (HistoryData.HitStatus == -1)
                                        {
                                            totalFirstHitCount = -1;
                                            totalProbVarHitCount = -1;
                                            totalHitCount = -1;
                                            totalRotateCount = -1;
                                            remainRotateCount = -1;
                                        }
                                        break;
                                }
                            }
                            //初当り回数
                            DispUnitData.TotalFirstHitCount = totalFirstHitCount;
                            
                            //確変回数
                            DispUnitData.TotalProbVarHitCount = totalProbVarHitCount;

                            //(初当り+確変)回数
                            DispUnitData.TotalHitCount = totalHitCount;

                            //総回転数
                            DispUnitData.TotalRotateCount = totalRotateCount;

                            //残り回転数
                            DispUnitData.RemainRotateCount = remainRotateCount;

                            //台データをリストへ追加
                            DispUnitDataList.Add(DispUnitData);
                        }
                    }
                }
            }
            return DispUnitDataList;
        }
    }
}
