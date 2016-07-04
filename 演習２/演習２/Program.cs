using System;

class MainClass
{
    static void Main()
    {
        string temp;
        double height;

        System.Console.Write("身長[cm]を入力してください>>>");
        temp = System.Console.ReadLine();
        height = System.Double.Parse(temp);

        System.Console.WriteLine("あなたの標準体重は{0:##.0}Kgです", height * height * 22 / 100 / 100);
    }
}

