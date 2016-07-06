using System;
class Auto
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
}
class Sedan:Auto
{
    public Sedan(int d):base(d)
    {

    }

}
class Truck:Auto
{
    public Truck(int d):base(d)
    {

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
    }
}