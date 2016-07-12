using System;

using Janken;


namespace Janken
{

    class MainClass
    {
        static void Main()
        {
            Player p1 = new Player("プレイヤー１");
            Player p2 = new Player("プレイヤー2");
            Computer c1 = new Computer();
            Judge j1 = new Judge();
            int res1;
            int res2;
            int res3;
            while (true)
            {
                res1 = p1.start();
                res2 = p2.start();
                res3 = c1.start();
                bool finish = j1.Determine(res1, res2,res3);

                if (!finish)
                {
                    return;
                }
                Console.ReadKey();
            }
        }

    }
}

