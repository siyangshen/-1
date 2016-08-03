namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CsvHelper;

    /// <summary>
    /// 勝負を判定する
    /// </summary>
    internal class Judge
    {
        /// <summary>
        /// 勝負を判定するメソッド
        /// </summary>
        /// <param name="numberOfUser1">対戦ユーザーの数</param>
        /// <param name="numberOfCpu1">対戦パソコンの数</param>
        /// <param name="playerlist">プレーヤーの手の情報</param>
        /// <returns>bool</returns>
        public static bool IsDrawn(int numberOfUser1, int numberOfCpu1, List<Player> playerlist)
        {
            var detailList = new List<int>();
            var csv = new CsvWriter(new StreamWriter("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\janken.csv", true, System.Text.Encoding.GetEncoding(932)));

            bool condition1;
            bool condition2;
            bool condition3;
            

            condition1 = ExistFist(playerlist, Utils.CHOKI);

            condition2 = ExistFist(playerlist,  Utils.GU);

            condition3 = ExistFist(playerlist, Utils.PA);

            int win = 0;
            int lose = 0;

            if (condition1 == true && condition2 == true && condition3 == false)
            {
                WinProcess(numberOfCpu1, numberOfUser1, csv, playerlist, ref win, ref lose, Utils.GU, detailList);
            }

            if (condition1 == true && condition2 == false && condition3 == true)
            {
                WinProcess(numberOfCpu1, numberOfUser1, csv, playerlist, ref win, ref lose, Utils.CHOKI, detailList);
            }

            if (condition1 == false && condition2 == true && condition3 == true)
            {
                WinProcess(numberOfCpu1, numberOfUser1, csv, playerlist, ref win, ref lose, Utils.PA, detailList);
            }

            if (
                (!condition1 == true && condition2 == true && condition3 == false) ||
                (!condition1 == true && condition2 == false && condition3 == true) ||
                (!condition1 == false && condition2 == true && condition3 == true))
            {
                Console.WriteLine("あいこです。もう一度やります。");
                playerlist.Clear();

                return true;
            }

            return false;
        }

        private static bool ExistFist(List<Player> playerlist, int fistType)
        {
            foreach (Player player in playerlist)
            {
                if (player.Fist == fistType)
                {
                    return true;
                }
            }

            return false;
        }

        private static void WinProcess(int x1, int y1, CsvWriter csv, List<Player> playerlist, ref int win, ref int lose, int wonType, List<int> detailList)
        {
            for (int i = 1; i <= y1; i++)
            {
                var player = playerlist[i - 1];
                if (player.Fist == wonType)
                {
                    Console.WriteLine("{0}の勝ち", "ユーザー" + i);
                    win = 1;
                    lose = 0;
                    detailList.Add(1);
                }
                else
                {
                    win = 0;
                    lose = 1;

                    detailList.Add(0);
                }

                csv.WriteField(win);
                csv.WriteField(lose);
            }

            csv.NextRecord();

            for (int i = 1 + y1; i <= x1 + y1; i++)
            {
                {
                    var player = playerlist[i - 1];
                    if (player.Fist == wonType)
                    {
                        Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                    }
                }
            }

            csv.Dispose();
        }
    }
}
