using System;
class Computer
{
    public static int daisu;
    public string ComputerName;
    public string InstalledOS;
    public int memory;
    public int disk;

    public static int GetCount()
    {
        return daisu;
    }
    public Computer(string compComputerName,
                    string compInstalledOs,
                    int compmemory,
                    int compdisk)
    {
        ComputerName = compComputerName;
        InstalledOS = compInstalledOs;
        memory = compmemory;
        disk = compdisk;
        daisu = daisu + 1;
    }
}

class MainClass
{ 
    static void Main()
    {
        Computer.daisu = 0;
        
        Console.WriteLine("現在の台数={0}",Computer.GetCount());
        Computer computer1 = new Computer("Sales01", "Windows 8 Ultimate",1000,0);
       
        Computer computer2 = new Computer("Sales02", "Windows 7 Professional",1600,120);
        
        

        Console.WriteLine("現在の台数={0}", Computer.daisu);
        Console.WriteLine("{0}, {1}", computer1.ComputerName, computer1.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer1.memory, computer1.disk);
        Console.WriteLine("{0},{1}", computer2.ComputerName, computer2.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer2.memory, computer2.disk);

    }
}