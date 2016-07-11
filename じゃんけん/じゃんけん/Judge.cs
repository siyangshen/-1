using System;

namespace Janken
{
    class Judge
    {
        public bool Determine(int p1, int p2, int a = 1)
        {
            while (a == 1)
            {
                if (p1 - p2 == -2 || p1 - p2 == 1)
                {
                    Console.WriteLine("あなたの勝ち!");

                }
                else if (p1 == p2)
                {
                    Console.WriteLine("あいこです。もう一度やります。");

                    return true;
                }
                else
                {
                    Console.WriteLine("パソコンの勝ち!");

                }
                if (p1 != p2)
                {
                    Console.WriteLine("もう一度やりますか？\n0.終了　1.やる");
                    a = int.Parse(Console.ReadLine());

                }
                if (a == 0)
                {
                    Console.WriteLine("終了します。");
                    return false;
                }

                if (a == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

