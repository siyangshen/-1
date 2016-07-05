using System;

class MainClass
{
    static void Main()
    {
        for (int i = 0; i <= 100; i++)
        {
            if (i % 3 == 0 | i % 7 == 0)
            {
                continue;
            }
            Console.Write(i + " ");
        }
    }
}