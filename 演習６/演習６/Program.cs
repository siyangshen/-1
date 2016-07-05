using System;

class Computer
{
    public string computerName;
    public string installedOS;
    public int memory;
    public int disk;

    public string ComputerName
    {
        get
        {
            return computerName;
        }
        set
        {
            if (value.Length <= 100)
            {
                computerName = value;
            }
        }
    }
    public string InstalledOS
    {
        get
        {
            return installedOS;
        }
        set
        {
            if (value.Length <= 100)
            {
                installedOS = value;
            }
        }
    }

}
class MainClass
{
    static void Main(string[] args)
    {
        Computer computer1 = new Computer();
        computer1.ComputerName = "Sales01";
        computer1.InstalledOS = "Windows 8 Ultimate";
        computer1.memory = 1000;
        computer1.disk = 0;
        Console.WriteLine("{0}, {1}",computer1.ComputerName, computer1.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer1.memory, computer1.disk);

        Computer computer2 = new Computer();
        computer2.ComputerName = "Sales02";
        computer2.InstalledOS = "Windows 7 Professional";
        computer2.memory = 1600;
        computer2.disk = 120;
        Console.WriteLine("{0},{1}",computer2.ComputerName, computer2.InstalledOS);
        Console.WriteLine("Memory={0}MB,Disk={1}GB", computer2.memory, computer2.disk);

    }
}