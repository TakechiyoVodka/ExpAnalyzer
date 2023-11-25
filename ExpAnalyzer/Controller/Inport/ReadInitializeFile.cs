using ExpAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpAnalyzer.Controller.Inport
{
    /// <summary>
    /// 初期設定ファイル読込みクラス
    /// </summary>
    internal class ClassReadInitializeFile
    {
        /// <summary>
        /// データ種別定義
        /// </summary>
        public const string MODEL_NAME = "ModelName";
        public const string FIRSTHIT_PROB = "FirstHitProb";
        public const string PROBVARHIT_PROB = "ProbVarHitProb";
        public const string PROBVARHIT_RASHRATE = "ProbVarHitRashRate";
        public const string PROBVARHIT_PERSISRATE = "ProbVarHitPersisRate";
        public const string SPECIAL_TIME = "SpecialTime";
        public const string SAVING_TIME = "SavingTime";
        public const string C_TIME = "CTime";

        /// <summary>
        /// 設定ファイルから機種詳細情報を読込み
        /// </summary>
        public List<ClassModelDetailsInfo> ReadModelDetailsInfo(string InportInitFilePath)
        {
            List<ClassModelDetailsInfo> ModelDetailsInfoList = new List<ClassModelDetailsInfo>();

            using (StreamReader sr = new StreamReader(InportInitFilePath, System.Text.Encoding.Default))
            {
                ClassModelDetailsInfo ModelDetailsInfo = new ClassModelDetailsInfo();
                int modelNum = 0;
                bool readFlg = false;

                while (sr.EndOfStream == false)
                {
                    string readLine = sr.ReadLine();
                    int resultValue = 0;

                    //"■Model-"がヒットした行から読込み開始
                    if (Regex.Match(readLine, @"^■Model-\d+").Success == true)
                    {
                        string[] splitModelNum = readLine.Split('-');

                        if(int.TryParse(splitModelNum[1], out resultValue) != true)
                        {
                            throw new Exception(string.Concat("■Model-(Number)の記載が不正です。"));
                        }
                        modelNum = resultValue;

                        readFlg = true;
                    }
                    else
                    {
                        if (readFlg == true)
                        {
                            string[] splitReadLine = readLine.Split(':');

                            switch (splitReadLine[0])
                            {
                                //機種名
                                case MODEL_NAME:

                                    ModelDetailsInfo.ModelName = splitReadLine[1];
                                    break;

                                //初当り確率
                                case FIRSTHIT_PROB:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "の初当り確率の取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.FirstHitProb = resultValue;
                                    break;

                                //確変当り確率
                                case PROBVARHIT_PROB:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "の確変当り確率の取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.ProbVarHitProb = resultValue;
                                    break;

                                //確変突入率
                                case PROBVARHIT_RASHRATE:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "の確変突入率の取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.ProbVarHitRashRate = resultValue;
                                    break;

                                //確変継続率
                                case PROBVARHIT_PERSISRATE:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "の確変継続率の取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.ProbVarHitPersisRate = resultValue;
                                    break;

                                //ST
                                case SPECIAL_TIME:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "のSTの取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.SpecialTime = resultValue;
                                    break;

                                //時短回数
                                case SAVING_TIME:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "の時短回数の取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.SavingTime = resultValue;
                                    break;

                                //CT
                                case C_TIME:

                                    if (int.TryParse(splitReadLine[1], out resultValue) != true)
                                    {
                                        throw new Exception(string.Concat("■Model-", modelNum, "のCTの取得に失敗しました。"));
                                    }
                                    ModelDetailsInfo.CTime = resultValue;
                                    break;
                            }

                            //全ての機種詳細情報の読込み完了後リストへ追加
                            if (ModelDetailsInfo.ModelName != null && ModelDetailsInfo.FirstHitProb != 0
                                && ModelDetailsInfo.ProbVarHitProb != 0 && ModelDetailsInfo.ProbVarHitRashRate != 0
                                && ModelDetailsInfo.ProbVarHitPersisRate != 0 && ModelDetailsInfo.SpecialTime != 0
                                && ModelDetailsInfo.SavingTime != 0 && ModelDetailsInfo.CTime != 0)
                            {
                                ModelDetailsInfoList.Add(ModelDetailsInfo);
                                ModelDetailsInfo = new ClassModelDetailsInfo();
                                readFlg = false;
                            }
                        }
                    }
                }
            }
            return ModelDetailsInfoList;
        }
    }
}
