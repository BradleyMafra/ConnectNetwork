using System;
using ConnectLibrary;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Network nT = new Network(8);

            nT.Connect(1, 2);
            nT.Connect(6, 2);
            nT.Connect(2, 4);
            nT.Connect(5, 8);

            Console.WriteLine(nT.Query(1, 6));
            Console.WriteLine(nT.Query(6, 4));
            Console.WriteLine(nT.Query(7, 4));
            Console.WriteLine(nT.Query(5, 6));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
