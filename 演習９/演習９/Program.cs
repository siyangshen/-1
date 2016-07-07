using System;
abstract class Auto
{
    private int displacement;
    protected double fuel;
    public Auto(int d)
    {
        displacement = d;
    }
    public void AddFuel(double f)
    {
        fuel = f;
    }
    public int GetDisplacement()
    {
        return displacement;
    }
    public abstract bool Transfer(double distance);


}
class Sedan : Auto
{
    public Sedan(int d) : base(d)
    {

    }
    public override bool Transfer(double distance)
    {
        double useFuel = distance * 3.75 / 30;
        if(useFuel<fuel)
        {
            Console.WriteLine("ガソリンを3.75L消費し、30Km移動しました");
            fuel -= 3.75;
            return true;
        }
        else
        {
            Console.WriteLine("Sedan：30Kｍ移動するには、燃料が{0}L足りません",useFuel-fuel);
            return false;
        }

        
    }
}
class Truck : Auto
{
    public Truck(int d) : base(d)
    {

    }
    public override bool Transfer(double distance)
    {
        double useFuel = distance * 1.5 / 30;
        if (useFuel < fuel)
        {
            Console.WriteLine("軽油を1.5L消費し、30Km移動しました");
            fuel -= 1.5;
            return true;
        }
        else
        {
            Console.WriteLine("Truck：30Kｍ移動するには、燃料が{0}L足りません", useFuel-fuel);
            return false;
        }
        // 消費する燃料を計算
        // 消費する燃料より残ってる燃料が多かったら、
        // 何キロ走ったというメッセージを表示
        // 消費燃料の分だけ、燃料を減らす
        // trueを返す
       
    }

}
class MainClass
{
    static void Main()
    {
        Sedan auto1 = new Sedan(2000);
        auto1.AddFuel(50);
        Console.WriteLine("排気量{0}ccの車", auto1.GetDisplacement());
        Truck auto2 = new Truck(5500);
        auto2.AddFuel(50);
        Console.WriteLine("排気量{0}ccのトラック", auto2.GetDisplacement());
        for (int i = 1; i < 31; i++)
        {
            Console.WriteLine("{0,2}日目", i);
            if (!auto1.Transfer(30))
            {
                break;
            }
            
            
            if (!auto2.Transfer(30))
            {
               break;
            }
           
        }
    }
}

