﻿using System;

namespace Janken
{
    class Player
    {
        private int i;
        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        public int start()
        {
            int result;
            string fist;
            Console.WriteLine("じゃんけんが始まります。\n数字を入力してください。\n1.チョキ  2.グー　3.パー");            
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
            Console.WriteLine("{0}は{1}を出しました。", name, fist);
            
            
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
