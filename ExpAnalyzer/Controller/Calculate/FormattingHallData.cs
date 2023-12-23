using ExpAnalyzer.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpAnalyzer.Controller.Calculate
{
    internal class ClassFormattingHallData
    {
        /// <summary>
        /// データソース定義
        /// </summary>
        private const string DATASOURCE_MARUHAN = "マルハンアプリ";
        private const string DATASOURCE_DATAROBO = "データロボサイトセブン";
        private const string DATASOURCE_DATAONLINE = "台データオンライン";

        /// <summary>
        /// ホールデータの整形
        /// </summary>
        internal ClassHallData FormattingHallData(string hallDataSource)
        {
            ClassHallData HallData = new ClassHallData();
            ClassHallData OriginHallData = FormMain.HallData;

            HallData.HallName = OriginHallData.HallName;

            //機種データ
            foreach (ClassModelData OriginModelData in OriginHallData.ModelDataList)
            {
                ClassModelData ModelData = new ClassModelData();
                int STime = -1;
                int CTime = -1;

                ModelData.ModelName = OriginModelData.ModelName;

                //機種スペックデータ
                foreach (ClassModelSpecData ModelSpecData in FormMain.ModelSpecDataList)
                {
                    //機種スペックデータからST回転数を取得
                    if (ModelData.ModelName == ModelSpecData.ModelName)
                    {
                        STime = ModelSpecData.SpecialTime;
                        CTime = ModelSpecData.CTime;
                        break;
                    }
                }

                //台データ
                foreach (ClassUnitData OriginUnitData in OriginModelData.UnitDataList)
                {
                    ClassUnitData UnitData = new ClassUnitData();
                    int remainRotateCount = 0;

                    UnitData.UnitNum = OriginUnitData.UnitNum;

                    //デイリーデータ
                    foreach (ClassDailyData OriginDailyData in OriginUnitData.DailyDataList)
                    {
                        ClassDailyData DailyData = new ClassDailyData();
                        
                        DailyData.DateTime = OriginDailyData.DateTime;

                        //履歴データ
                        for (int i = 0; i < OriginDailyData.HistoryDataList.Count; i++)
                        {
                            ClassHistoryData HistoryData = new ClassHistoryData();

                            //マルハンアプリ
                            if (hallDataSource == DATASOURCE_MARUHAN)
                            {
                                switch (OriginDailyData.HistoryDataList[i].HitType)
                                {
                                    //定休日または故障台
                                    case -1:

                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        HistoryData.HitType = -1;
                                        break;

                                    //残り回転数
                                    case 0:

                                        //確変終了後が残り回転数の場合
                                        if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 2)
                                        {
                                            if (OriginDailyData.HistoryDataList[i].RotateCount >= STime)
                                            {
                                                //残り回転数からST回転数を減算
                                                remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                            }
                                            else
                                            {
                                                //残り回転数を0に設定
                                                remainRotateCount = 0;

                                                //閉店時に確変が終了しなかった場合(強制退店時)
                                                if (OriginDailyData.HistoryDataList[i].RotateCount < STime - 4)
                                                {
                                                    //RAMクリア警告フラグON
                                                }
                                            }
                                        }
                                        //初当り後または初当りしなかった場合
                                        else
                                        {
                                            remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        }
                                        break;

                                    //初当り
                                    case 1:

                                        if (i == 0)
                                        {
                                            //前日の残り回転数を先頭の初当り回転数に加算
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount + remainRotateCount;
                                            HistoryData.HitType = 1;
                                            remainRotateCount = 0;
                                        }
                                        else
                                        {
                                            //確変終了後が初当りの場合
                                            if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 2)
                                            {
                                                if (OriginDailyData.HistoryDataList[i].RotateCount > STime)
                                                {
                                                    //確変終了後の初当り回転数からST回転数を減算
                                                    HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                    HistoryData.HitType = 1;
                                                }
                                                else
                                                {
                                                    //確変終了後の初当り回転数を1に設定
                                                    HistoryData.RotateCount = 1;
                                                    HistoryData.HitType = 1;
                                                }
                                            }
                                            else
                                            {
                                                HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                                HistoryData.HitType = 1;
                                            }
                                        }
                                        break;

                                    //確変当り
                                    case 2:

                                        //確変当り回転数がST回転数を超過する場合　※Cタイム突入時
                                        if (OriginDailyData.HistoryDataList[i].RotateCount > STime)
                                        {
                                            //確変当り回転数からST回転数を減算し、大当り種別を初当り(Cタイム)へ変更
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                            HistoryData.HitType = 3;
                                        }
                                        else
                                        {
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                            HistoryData.HitType = 2;
                                        }
                                        break;
                                }
                                //残り回転数は履歴データリストに含めない
                                if (OriginDailyData.HistoryDataList[i].HitType != 0)
                                {
                                    DailyData.HistoryDataList.Add(HistoryData);
                                }
                            }
                            //データロボサイトセブン
                            else if (hallDataSource == DATASOURCE_DATAROBO)
                            {
                                switch (OriginDailyData.HistoryDataList[i].HitType)
                                {
                                    //定休日または故障台
                                    case -1:

                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        HistoryData.HitType = -1;
                                        break;

                                    //残り回転数
                                    case 0:

                                        //確変終了後が残り回転数の場合
                                        if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 2)
                                        {
                                            if (OriginDailyData.HistoryDataList[i].RotateCount >= STime)
                                            {
                                                //残り回転数からST回転数を減算
                                                remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                            }
                                            else
                                            {
                                                //残り回転数を0に設定
                                                remainRotateCount = 0;

                                                //閉店時に確変が終了しなかった場合(強制退店時)
                                                if (OriginDailyData.HistoryDataList[i].RotateCount < STime - 4)
                                                {
                                                    //RAMクリア警告フラグON
                                                }
                                            }
                                        }
                                        //Cタイム終了後が残り回転数の場合
                                        else if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 3)
                                        {
                                            if (OriginDailyData.HistoryDataList[i].RotateCount >= OriginDailyData.HistoryDataList[i - 1].RotateCount)
                                            {
                                                if (OriginDailyData.HistoryDataList[i - 1].RotateCount >= STime)
                                                {
                                                    //残り回転数からST回転数を減算
                                                    remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                }
                                                else
                                                {
                                                    //初当り回転数からCタイム突入時の回転数を減算
                                                    remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount - OriginDailyData.HistoryDataList[i - 1].RotateCount;
                                                }
                                            }
                                            else
                                            {
                                                if (OriginDailyData.HistoryDataList[i].RotateCount >= STime)
                                                {
                                                    //残り回転数からST回転数を減算
                                                    remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                }
                                                else
                                                {
                                                    //残り回転数を0に設定
                                                    remainRotateCount = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        }
                                        break;

                                    //初当り
                                    case 1:
                                        
                                        if (i == 0)
                                        {
                                            //前日の残り回転数を先頭の初当り回転数に加算
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount + remainRotateCount;
                                            HistoryData.HitType = 1;
                                            remainRotateCount = 0;
                                        }
                                        else
                                        {
                                            //確変終了後が初当りの場合
                                            if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 2)
                                            {
                                                if (OriginDailyData.HistoryDataList[i].RotateCount > STime)
                                                {
                                                    //確変終了後の初当り回転数からST回転数を減算
                                                    HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                    HistoryData.HitType = 1;
                                                }
                                                else
                                                {
                                                    //確変終了後の初当り回転数を1に設定
                                                    HistoryData.RotateCount = 1;
                                                    HistoryData.HitType = 1;
                                                }
                                            }
                                            //Cタイム中またはCタイム終了後が初当りの場合
                                            else if (i > 0 && OriginDailyData.HistoryDataList[i - 1].HitType == 3)
                                            {
                                                if (OriginDailyData.HistoryDataList[i].RotateCount > OriginDailyData.HistoryDataList[i - 1].RotateCount)
                                                {
                                                    //Cタイム中に初当りした場合
                                                    if (OriginDailyData.HistoryDataList[i].RotateCount - OriginDailyData.HistoryDataList[i - 1].RotateCount <= CTime)
                                                    {
                                                        if (OriginDailyData.HistoryDataList[i - 1].RotateCount > STime)
                                                        {
                                                            //初当り回転数からST回転数を減算
                                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                            HistoryData.HitType = 3;
                                                        }
                                                        else
                                                        {
                                                            //初当り回転数からCタイム突入時の回転数を減算
                                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - OriginDailyData.HistoryDataList[i - 1].RotateCount;
                                                            HistoryData.HitType = 3;
                                                        }
                                                    }
                                                    //Cタイム終了後に初当りした場合
                                                    else
                                                    {
                                                        if (OriginDailyData.HistoryDataList[i - 1].RotateCount > STime)
                                                        {
                                                            //初当り回転数からST回転数を減算
                                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                            HistoryData.HitType = 1;
                                                        }
                                                        else
                                                        {
                                                            //初当り回転数からCタイム突入時の回転数を減算
                                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - OriginDailyData.HistoryDataList[i - 1].RotateCount;
                                                            HistoryData.HitType = 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //例外処理  ※確変終了後であるため初当り回転数からST回転数を減算
                                                    if (OriginDailyData.HistoryDataList[i].RotateCount > STime)
                                                    {
                                                        //初当り回転数からST回転数を減算
                                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount - STime;
                                                        HistoryData.HitType = 1;
                                                    }
                                                    else
                                                    {
                                                        //初当り回転数を1に設定
                                                        HistoryData.RotateCount = 1;
                                                        HistoryData.HitType = 1;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                                HistoryData.HitType = 1;
                                            }
                                        }
                                        break;
                                    
                                    //確変当り
                                    case 2:

                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        HistoryData.HitType = 2;
                                        break;
                                }
                                //残り回転数またはCT回転数は履歴データリストに含めない
                                if (OriginDailyData.HistoryDataList[i].HitType != 0 || OriginDailyData.HistoryDataList[i].HitType != 3)
                                {
                                    DailyData.HistoryDataList.Add(HistoryData);
                                }
                            }
                            //台データオンライン etc.
                            else
                            {
                                switch (OriginDailyData.HistoryDataList[i].HitType)
                                {
                                    //定休日または故障台
                                    case -1:
                                        
                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        HistoryData.HitType = -1;
                                        break;

                                    //残り回転数
                                    case 0:

                                        remainRotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        break;

                                    //初当り
                                    case 1:

                                        if (i == 0)
                                        {
                                            //前日の残り回転数を先頭の初当り回転数に加算
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount + remainRotateCount;
                                            HistoryData.HitType = 1;
                                            remainRotateCount = 0;
                                        }
                                        else
                                        {
                                            HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                            HistoryData.HitType = 1;
                                        }
                                        break;

                                    //確変当り
                                    case 2:

                                        HistoryData.RotateCount = OriginDailyData.HistoryDataList[i].RotateCount;
                                        HistoryData.HitType = 2;
                                        break;
                                }
                                //残り回転数は履歴データリストに含めない
                                if (OriginDailyData.HistoryDataList[i].HitType != 0)
                                {
                                    DailyData.HistoryDataList.Add(HistoryData);
                                }
                            }
                        }
                        UnitData.DailyDataList.Add(DailyData);
                    }
                    ModelData.UnitDataList.Add(UnitData);
                }
                HallData.ModelDataList.Add(ModelData);
            }
            return HallData;
        }
    }
}
