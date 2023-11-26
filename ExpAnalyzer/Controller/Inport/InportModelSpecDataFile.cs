﻿using ExpAnalyzer.Models;
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
    /// 機種スペックデータファイル読込みクラス
    /// </summary>
    internal class ClassInportModelSpecDataFile
    {
        /// <summary>
        /// データ種別定義
        /// </summary>
        private const string MODEL_NAME = "ModelName";
        private const string FIRSTHIT_PROB = "FirstHitProb";
        private const string PROBVARHIT_PROB = "ProbVarHitProb";
        private const string PROBVARHIT_RASHRATE = "ProbVarHitRashRate";
        private const string PROBVARHIT_PERSISRATE = "ProbVarHitPersisRate";
        private const string SPECIAL_TIME = "SpecialTime";
        private const string SAVING_TIME = "SavingTime";
        private const string C_TIME = "CTime";

        /// <summary>
        /// テキストファイルから機種スペックデータを読込み
        /// </summary>
        internal List<ClassModelSpecData> InportModelSpecDataFromTextFile(string InportInitFilePath)
        {
            List<ClassModelSpecData> ModelSpecDataList = new List<ClassModelSpecData>();

            using (StreamReader sr = new StreamReader(InportInitFilePath, System.Text.Encoding.Default))
            {
                ClassModelSpecData ModelDetailsInfo = new ClassModelSpecData();
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
                                ModelSpecDataList.Add(ModelDetailsInfo);
                                ModelDetailsInfo = new ClassModelSpecData();
                                readFlg = false;
                            }
                        }
                    }
                }
            }
            return ModelSpecDataList;
        }
    }
}