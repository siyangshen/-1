using System;

class MainClass
{
    static void Main()
    {
        string temp;
        int height;

        System.Console.Write("身長[cm]を入力してください>>>");
        temp = System.Console.ReadLine();
        price = System.Int32.Parse(temp);

        System.Console.WriteLine("税込み価格{0:c}", price * 1.05);
    }
}
