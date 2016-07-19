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
            string x;
            string y;

            Console.WriteLine("じゃんけんが始まります。\n対戦パソコン数を入力してください:");
            x = Console.ReadLine();
            int x1 = int.Parse(x);
            Console.WriteLine("対戦人数を入力してください:");
            y = Console.ReadLine();
            int y1 = int.Parse(y);
            var csv = new CsvWriter(new StreamWriter("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\out.csv", false, System.Text.Encoding.GetEncoding(932)));
            dumpCsv("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\test1.csv");
            dumpCsv("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\test2.csv");
            dumpCsv("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\test3.csv");
            dumpCsv("C:\\Users\\00640-1\\Source\\Repos\\-1\\csv\\test4.csv");
            Console.Read();


            do
            {
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

                for (int i = 1; i <= y1; i++)
                {
                    var player = playerlist[i - 1];
                    Console.WriteLine("ユーザー{0}は{1}を出しました。", i, player.IntToFist(player.Fist));
                }

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

                foreach (Player player in playerlist)
                {
                    if (player.Fist == Utils.CHOKI)
                    {
                        condition1 = true;
                        break;
                    }
                }

                foreach (Player player in playerlist)
                {
                    if (player.Fist == Utils.GU)
                    {
                        condition2 = true;
                        break;
                    }
                }

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
                    for (int i = 1; i <= y1; i++)
                    {
                        {
                            var player = playerlist[i - 1];
                            if (player.Fist == Utils.GU)
                            {
                                Console.WriteLine("{0}の勝ち", "ユーザー" + i);
                                win = 1;
                                lose = 0;
                            }
                            else
                            {
                                win = 0;
                                lose = 1;
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
                            if (player.Fist == Utils.GU)
                            {
                                Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                            }
                        }
                    }
                }

                if (condition1 == true && condition2 == false && condition3 == true)
                {
                    for (int i = 1; i <= y1; i++)
                    {
                        {
                            var player = playerlist[i - 1];
                            if (player.Fist == Utils.CHOKI)
                            {
                                Console.WriteLine("{0}の勝ち", "ユーザー" + i);
                                win = 1;
                                lose = 0;
                            }
                            else
                            {
                                win = 0;
                                lose = 1;
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
                            if (player.Fist == Utils.CHOKI)
                            {
                                Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                            }
                        }
                    }
                }

                if (condition1 == false && condition2 == true && condition3 == true)
                {
                    for (int i = 1; i <= y1; i++)
                    {
                        {
                            var player = playerlist[i - 1];
                            if (player.Fist == Utils.PA)
                            {
                                Console.WriteLine("{0}の勝ち", "ユーザー" + i);
                                win = 1;
                                lose = 0;
                            }
                            else
                            {
                                win = 0;
                                lose = 1;
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
                            if (player.Fist == Utils.PA)
                            {
                                Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                            }
                        }
                    }
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

                if (a == 1)
                {
                    continue;
                }
            }
            while (true);
            csv.Dispose();
        }
        static void dumpCsv(string file)
        {
            Console.WriteLine(file + "================================");
            var parser = new CsvReader(new StreamReader(file,
                                                        System.Text.Encoding.GetEncoding(932)));
            parser.Configuration.Encoding = System.Text.Encoding.GetEncoding(932);
            parser.Configuration.AllowComments = true;
            parser.Configuration.Comment = '#';
            parser.Configuration.HasHeaderRecord = false;

            while (parser.Read())
            {
                for (var i = 0; i < parser.CurrentRecord.Length; ++i)
                {
                    Console.WriteLine("{0}:{1}", i, parser.CurrentRecord.ElementAt(i));
                }
                Console.WriteLine("----------------------------");
            }
            parser.Dispose();
        }

    }
}
