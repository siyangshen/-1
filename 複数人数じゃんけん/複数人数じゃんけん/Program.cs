namespace Janken
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Janken;

    /// <summary>
    /// 勝敗の判定
    /// </summary>
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

            var csv = new CsvWriter(new StreamWriter("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\janken.csv", true, System.Text.Encoding.GetEncoding(932)));

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

                NewMethod3(y1, playerlist);

                NewMethod4(x1, y1, playerlist);

                bool condition1;
                bool condition2;
                bool condition3;

                condition1 = false;
                condition2 = false;
                condition3 = false;

                condition1 = NewMethod(playerlist, condition1, Utils.CHOKI);

                condition2 = NewMethod1(playerlist, condition2, Utils.GU);

                condition3 = NewMethod2(playerlist, condition3, Utils.PA);

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

                    break;
                }
            }
            while (true);

            csv.Dispose();
            CsvOpen();
        }

        private static void NewMethod4(int x1, int y1, List<Player> playerlist)
        {
            for (int i = 1 + y1; i <= x1 + y1; i++)
            {
                var player = playerlist[i - 1];
                Console.WriteLine("パソコン{0}は{1}を出しました。", i - y1, player.IntToFist(player.Fist));
            }
        }

        private static void NewMethod3(int y1, List<Player> playerlist)
        {
            for (int i = 1; i <= y1; i++)
            {
                var player = playerlist[i - 1];
                Console.WriteLine("ユーザー{0}は{1}を出しました。", i, player.IntToFist(player.Fist));
            }
        }

        private static bool NewMethod2(List<Player> playerlist, bool condition3, int fistType)
        {
            foreach (Player player in playerlist)
            {
                if (player.Fist == fistType)
                {
                    condition3 = true;
                    break;
                }
            }

            return condition3;
        }

        private static bool NewMethod1(List<Player> playerlist, bool condition2, int fistType)
        {
            foreach (Player player in playerlist)
            {
                if (player.Fist == fistType)
                {
                    condition2 = true;
                    break;
                }
            }

            return condition2;
        }

        private static bool NewMethod(List<Player> playerlist, bool condition1, int fistType)
        {
            foreach (Player player in playerlist)
            {
                if (player.Fist == fistType)
                {
                    condition1 = true;
                    break;
                }
            }

            return condition1;
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
        }

        private static void CsvOpen()
        {
            string[] kekka = System.IO.File.ReadAllLines(@"C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\janken.csv");
            IEnumerable<IEnumerable<int>> multiColQuery =
                from line in kekka
                let elements = line.Split(',')
                let janken = elements.Skip(0)
                select from str in janken
                        select Convert.ToInt32(str);
            var results = multiColQuery.ToList();
            int columnCount = results[0].Count();
            for (int column = 0; column < columnCount; column += 2)
            {
                var results2 = from row in results
                               select row.ElementAtOrDefault(column);
                double sumwin = results2.Sum();
                var results3 = from row in results
                               select row.ElementAtOrDefault(column + 1);
                double sumlose = results3.Sum();
                Console.WriteLine("ユーザー{0}は{1}勝{2}敗　勝率は{3:##.##}%", (column + 2) / 2, sumwin, sumlose, sumwin / (sumwin + sumlose) * 100);
                Console.ReadKey();
            }
        }
    }
}
