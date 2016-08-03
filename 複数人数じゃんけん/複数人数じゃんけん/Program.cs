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
        private static void Main(string[] args)
        {
            string numberOfCpu;
            string numberOfUser;
            string fist;

            JankenAdapter adapter = new JankenAdapter();
            adapter.AdaptedJanken(args);
            Console.WriteLine("対戦パソコン数を入力してください:");
            while (true)
            {
                numberOfCpu = Console.ReadLine();

                if (!System.Text.RegularExpressions.Regex.IsMatch(numberOfCpu, @"^\d$"))
                {
                    Console.WriteLine("整数の数字を入力してください。");
                    continue;
                }

                break;
            }

            int numberOfCpu1 = int.Parse(numberOfCpu);
            Console.WriteLine("対戦人数を入力してください:");
            numberOfUser = Console.ReadLine();
            int numberOfUser1 = int.Parse(numberOfUser);
            {
                List<Player> playerlist = new List<Player>();
                for (int i = 1; i <= numberOfUser1; i++)
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

                    // User userPlayer = new User();
                    PlayerFactory userPlayerFactory = new UserPlayerFactory();

                    Player userPlayer = userPlayerFactory.CreatePlayer();

                    playerlist.Add(userPlayer);
                    userPlayer.Fist = userResult;
                }

                Random ran = new Random();
                for (int i = 1; i <= numberOfCpu1; i++)
                {
                    // Cpu cpuPlayer = new Cpu();
                    PlayerFactory cpuPlayerFactory = new CpuPlayerFactory();
                    Player cpuPlayer = cpuPlayerFactory.CreatePlayer();
                    playerlist.Add(cpuPlayer);

                    int cpuResult = ran.Next(1, 4);
                    cpuPlayer.Fist = cpuResult;
                }

                UserFist(numberOfUser1, playerlist);

                CpuFist(numberOfCpu1, numberOfUser1, playerlist);
                Judge.IsDrawn(numberOfUser1, numberOfCpu1, playerlist);

                Console.WriteLine("もう一度やりますか？\n0.終了　1.やる");
                fist = Console.ReadLine();
                int a = Convert.ToInt32(fist);

                if (a == 0)
                {
                    Console.WriteLine("終了します。");
                    Csv.CsvOpen();
                    //break;
                }
            }
        }

        private static void CpuFist(int x1, int y1, List<Player> playerlist)
        {
            for (int i = 1 + y1; i <= x1 + y1; i++)
            {
                var player = playerlist[i - 1];
                Console.WriteLine("パソコン{0}は{1}を出しました。", i - y1, player.IntToFist(player.Fist));
                Console.ReadKey();
            }
        }

        private static void UserFist(int y1, List<Player> playerlist)
        {
            for (int i = 1; i <= y1; i++)
            {
                var player = playerlist[i - 1];
                Console.WriteLine("ユーザー{0}は{1}を出しました。", i, player.IntToFist(player.Fist));
            }
        }
    }
}
