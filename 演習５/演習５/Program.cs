using System;

class Computer
{
    public string ComputerName;
    public int memory;
    public int disk;
   
}
class MainClass
{
    static void Main()
    {
        Computer computer1=new Computer();
        computer1.ComputerName = "Sales01";
        computer1.memory = 1000;
        computer1.disk = 0;
        Console.WriteLine(computer1.ComputerName);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer1.memory,computer1.disk);

        Computer computer2 = new Computer();
        computer2.ComputerName = "Sales02";
        computer2.memory = 1600;
        computer2.disk = 120;
        Console.WriteLine(computer2.ComputerName);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer2.memory, computer2.disk);

    }
}