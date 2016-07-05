using System;

class Computer
{
    public int memory;
    public int disk;
    private string computerName;
    public void SetName(string str)
    {
        computerName += str;
    }
    public string GetName()
    {
        return string;
    }
    public void PrintSpec()
    {
        Console.WriteLine("Memory=1000MB,Disk=160GB");
    }
}


class MainClass
{
    static void Main()
    {
        Computer computer1;
        computer1 = new Computer();
        computer1.SetName("Sales01");
        computer1.memory = 1000;
        computer1.disk = 160;
        Console.WriteLine("{0}", computer1.GetName());
        computer1.PrintSpec();
    }
}