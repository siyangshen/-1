using System;

using Janken;


namespace Janken
{

    class MainClass
    {
        static void Main()
        {
            Player p1 = new Player();
            Computer c1 = new Computer();
            Judge j1 = new Judge();
            int res1;
            int res2;
            while (true)
            {
                res1 = p1.start();
                res2 = c1.start();
                bool finish = j1.Determine(res1, res2);

                if (!finish)
                {
                    return;
                }
                Console.ReadKey();
            }
        }

    }
}

