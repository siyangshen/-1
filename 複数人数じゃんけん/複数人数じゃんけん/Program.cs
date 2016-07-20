namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Janken;

    public class Program
    {
        private static string fist;
        private static void Main(string[] args)
        {
            string numberOfCpu;
            string numberOfUser;


            Console.WriteLine("じゃんけんが始まります。\n対戦パソコン数を入力してください:");
            numberOfCpu = Console.ReadLine();
            int x1 = int.Parse(numberOfCpu);
            Console.WriteLine("対戦人数を入力してください:");
            numberOfUser = Console.ReadLine();
            int y1 = int.Parse(numberOfUser);

            
            var resultList = new List<List<int>>();
            
           
            var wonCountDictionary = new Dictionary<string, int>();
            

            

            var csv = new CsvWriter(new StreamWriter("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\out.csv", false, System.Text.Encoding.GetEncoding(932)));

            do
            {
                var detailList = new List<int>();
                List<Player> playerlist = new List<Player>();
                for (int i = 1; i <= y1; i++)
                {
                    Console.WriteLine("数字を入力してください。\n1.チョキ  2.グー　3.パー");

                    while (true)
                    {
                        fist = Console.ReadLine();
                        if (fist != "1" && fist != "2" && fist != "3")
                        {
                            Console.WriteLine("1から3の数字を入力してください。\n1.チョキ  2.グー　3.パー");
                            continue;
                        }

                        break;
                    }

                    int userResult = int.Parse(fist);
                    User userPlayer = new User();
                    playerlist.Add(userPlayer);
                    userPlayer.Fist = userResult;
                }

                Random ran = new Random();
                for (int i = 1; i <= x1; i++)
                {
                    Cpu cpuPlayer = new Cpu();
                    playerlist.Add(cpuPlayer);

                    int cpuResult = ran.Next(1, 4);
                    cpuPlayer.Fist = cpuResult;
                }

                //TODO convert to method
                for (int i = 1; i <= y1; i++)
                {
                    var player = playerlist[i - 1];
                    Console.WriteLine("ユーザー{0}は{1}を出しました。", i, player.IntToFist(player.Fist));
                }

                //TODO convert to method
                for (int i = 1 + y1; i <= x1 + y1; i++)
                {
                    var player = playerlist[i - 1];
                    Console.WriteLine("パソコン{0}は{1}を出しました。", i - y1, player.IntToFist(player.Fist));
                }

                bool condition1;
                bool condition2;
                bool condition3;

                condition1 = false;
                condition2 = false;
                condition3 = false;

                //TODO convert to method
                foreach (Player player in playerlist)
                {
                    if (player.Fist == Utils.CHOKI)
                    {
                        condition1 = true;
                        break;
                    }
                }
                //TODO convert to method
                foreach (Player player in playerlist)
                {
                    if (player.Fist == Utils.GU)
                    {
                        condition2 = true;
                        break;
                    }
                }
                //TODO convert to method
                foreach (Player player in playerlist)
                {
                    if (player.Fist == Utils.PA)
                    {
                        condition3 = true;
                        break;
                    }
                }

                int win = 0;
                int lose = 0;

                if (condition1 == true && condition2 == true && condition3 == false)
                {
                    WinProcess(x1, y1, csv, playerlist, ref win, ref lose, Utils.GU, detailList);
                }

                if (condition1 == true && condition2 == false && condition3 == true)
                {
                    WinProcess(x1, y1, csv, playerlist, ref win, ref lose, Utils.CHOKI, detailList);
                }

                if (condition1 == false && condition2 == true && condition3 == true)
                {
                    WinProcess(x1, y1, csv, playerlist, ref win, ref lose, Utils.PA, detailList);
                }


                if (
                    (!condition1 == true && condition2 == true && condition3 == false) ||
                    (!condition1 == true && condition2 == false && condition3 == true) ||
                    (!condition1 == false && condition2 == true && condition3 == true))
                {
                    Console.WriteLine("あいこです。もう一度やります。");
                    playerlist.Clear();

                    continue;
                }

                resultList.Add(detailList);

                // 対戦回数
                var taisenkaisu = 0;
                wonCountDictionary.Clear();
                foreach (var result in resultList)
                {
                    for (int i = 0; i < result.Count(); i++)
                    {
                        var userName = "user" + (i + 1);
                        var nowResult = result[i];
                        int pastCount = 0;
                        if (wonCountDictionary.ContainsKey(userName))
                        {
                            pastCount = wonCountDictionary[userName];
                            wonCountDictionary.Remove(userName);
                        }
                        Console.WriteLine(userName + ":" + pastCount + ":" + nowResult);
                        wonCountDictionary.Add(userName, pastCount + nowResult);
                    }
                    taisenkaisu++;
                }
                Console.WriteLine("----");

                int a = 0;
                if ((condition1 == true && condition2 == true && condition3 == false) ||
                    (condition1 == true && condition2 == false && condition3 == true) ||
                    (condition1 == false && condition2 == true && condition3 == true))
                {
                    Console.WriteLine("もう一度やりますか？\n0.終了　1.やる");
                    string fist = Console.ReadLine();
                    a = Convert.ToInt32(fist);
                }

                

                if (a == 0)
                {
                    Console.WriteLine("終了します。");

                    Console.WriteLine("対戦回数{0}", taisenkaisu);
                    for (int i = 0; i < resultList[0].Count(); i++)
                    {
                        var userName = "user" + (i + 1);
                        var userWonCount = wonCountDictionary[userName];
                        Console.WriteLine("ユーザー{0}は{1}回勝った  勝率は{2}%", i + 1, userWonCount, (double)userWonCount / taisenkaisu * 100);
                        //csv.WriteField()
                    }
                    Console.ReadKey();
                    break;
                }

            }
            while (true);
            csv.Dispose();

        }

        

        private static void WinProcess(int x1, int y1, CsvWriter csv, List<Player> playerlist, ref int win, ref int lose, int wonType,List<int> detailList)
        {
            for (int i = 1; i <= y1; i++)
            {
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
                    csv.NextRecord();
                }
            }

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

        }

    }
}
