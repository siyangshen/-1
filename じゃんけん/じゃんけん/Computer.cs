using System;

namespace Janken
{
    class Computer
    {
        Random ran = new Random();
        public int start()
        {
            int result = ran.Next(1, 4);
            Console.WriteLine("パソコンは{0}を出しました。", IntToFist(result));
            return result;
        }
        private string IntToFist(int input)
        {
            string result = string.Empty;
            switch (input)
            {
                case 1:
                    result = "チョキ";
                    break;
                case 2:
                    result = "グー";
                    break;
                case 3:
                    result = "パー";
                    break;
            }
            return result;
        }
    }
}
