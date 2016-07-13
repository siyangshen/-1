using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace 複数人数じゃんけん
{
    class Utils
    {
        public const int GU = 2;
        public const int CHOKI = 1;
        public const int PA = 3;
        //public static int GetCount()
        //{
        //    return Utils.CHOKI;
        //}
    }
    class Player
    {
        public int fist
        {
            get;
            internal set;
        }
    }
    class cpu : Player
    {
        private static string IntToFist(int input)
        {
            string result = string.Empty;
            switch (input)
            {
                case Utils.CHOKI:
                    result = "チョキ";
                    break;
                case Utils.GU:
                    result = "グー";
                    break;
                case Utils.PA:
                    result = "パー";
                    break;
            }
            return result;
        }
        public cpu()
        {
        }
        class user : Player
        {
            public user()
            {
            }
        }
        class Program
        {
            private static string fist;
            private static int result;
            static void Main(string[] args)
            {
                string x;
                string y;
                Console.WriteLine("じゃんけんが始まります。\n対戦パソコン数を入力してください:");
                x = Console.ReadLine();
                int x1 = Int32.Parse(x);
                Console.WriteLine("対戦人数を入力してください:");
                y = Console.ReadLine();
                int y1 = Int32.Parse(y);
                List<Player> playerlist = new List<Player>();
                for (int i = 1; i <= y1; i++)
                {
                    playerlist.Add(new user(/*"ユーザ" + i*/));
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
                    result = Int32.Parse(fist);
                    Console.WriteLine("ユーザー{0}は{1}を出しました。", i, IntToFist(result));
                }
                for (int i = 1; i <= x1; i++)
                {
                    playerlist.Add(new cpu());
                    Random ran = new Random();
                    int result = ran.Next(1, 4);
                    Console.WriteLine("パソコン{0}は{1}を出しました。", i, IntToFist(result));


                }
                foreach (Player player in playerlist)
                {
                    int fist = player.fist;
                }

                
                bool condition1;
                bool condition2;
                bool condition3;
                do
                {
                    // TODO じゃんけんの手を入力する処理を実装する

                    condition1 = false;
                    condition2 = false;
                    condition3 = false;
                    foreach (Player player in playerlist)
                    {
                        if (result == Utils.CHOKI)
                        {
                            condition1 = true;
                            break;
                        }
                    }


                    foreach (Player player in playerlist)
                    {
                        if (result == Utils.GU)
                        {
                            condition2 = true;
                            break;
                        }
                    }
                    foreach (Player player in playerlist)
                    {
                        if (result == Utils.PA)
                        {
                            condition3 = true;
                            break;
                        }
                    }
                    while (false) ;

                    while (
                    (condition1 && condition2 && condition3) ||
                    (condition1 && !condition2 && !condition3) ||
                    (!condition1 && condition2 && !condition3) ||
                    (!condition1 && !condition2 && condition3))
                        Console.WriteLine("あいこです。もう一度やります。");
                    





                    bool guWon = (condition1 && condition2 && !condition3);
                    if (guWon)
                    {
                        for (int i = 1; i <= y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.GU)
                                {
                                    Console.WriteLine("{0}の勝ち", "プレイヤー" + i);
                                }
                            }
                        }
                        for (int i = 1 + y1; i <= x1 + y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.GU)
                                {
                                    Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                                }
                            }
                        }

                        continue;
                    }
                    bool chokiWon = (condition1 && !condition2 && condition3);
                    if (chokiWon)
                    {
                        for (int i = 1; i <= y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.CHOKI)
                                {
                                    Console.WriteLine("{0}の勝ち", "プレイヤー" + i);
                                }
                            }
                        }
                        for (int i = 1 + y1; i <= x1 + y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.CHOKI)
                                {
                                    Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                                }
                            }
                        }

                        continue;
                    }
                    bool paWon = (!condition1 && condition2 && condition3);
                    if (paWon)
                    {
                        for (int i = 1; i <= y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.PA)
                                {
                                    Console.WriteLine("{0}の勝ち", "プレイヤー" + i);
                                }
                            }
                        }
                        for (int i = 1 + y1; i <= x1 + y1; i++)
                        {
                            {
                                var player = playerlist[i - 1];
                                if (player.fist == Utils.PA)
                                {
                                    Console.WriteLine("{0}の勝ち", "パソコン" + (i - y1));
                                }
                            }
                        }

                        continue;
                    }
                    int a = 1;
                    if (chokiWon || guWon || paWon)
                    {
                        Console.WriteLine("もう一度やりますか？\n0.終了　1.やる");
                        fist = (Console.ReadLine());
                    }
                    if (a == 0)
                    {
                        Console.WriteLine("終了します。");
                        while (false) ;
                    }

                    if (a == 1)
                    {
                        while (true) ;
                    }
                } while (false);







                    
                }

            }   
        }


    }

  






