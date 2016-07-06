using System;

class Computer
{
    public static int daisu;
    public string ComputerName;
    public string InstalledOS;
    public int memory;
    public int disk;

   
}



class MainClass
{ 
    static void Main()
    {
        Computer.daisu = 0;
        Console.WriteLine("現在の台数={0}",Computer.daisu);
        Computer computer1 = new Computer();
        computer1.ComputerName = "Sales01";
        computer1.InstalledOS = "Windows 8 Ultimate";
        computer1.memory = 1000;
        computer1.disk = 0;
        Computer computer2 = new Computer();
        computer2.ComputerName = "Sales02";
        computer2.InstalledOS = "Windows 7 Professional";
        computer2.memory = 1600;
        computer2.disk = 120;
        Computer.daisu = Computer.daisu+2;

        Console.WriteLine("現在の台数={0}", Computer.daisu);
        Console.WriteLine("{0}, {1}", computer1.ComputerName, computer1.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer1.memory, computer1.disk);
        Console.WriteLine("{0},{1}", computer2.ComputerName, computer2.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer2.memory, computer2.disk);

    }
}