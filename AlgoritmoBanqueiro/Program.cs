using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iniciando...");
        if (args.Length < 1)
        {
            Console.WriteLine("Uso: dotnet run -- (recurso1) (recurso2) (recurso3)");
            return;
        }

        int[] resources = new int[args.Length];

        for (int i = 0; i < args.Length; i++)
            resources[i] = int.Parse(args[i]);

        Bank bank = new Bank(resources);

        Thread[] threads = new Thread[5];

        for (int i = 0; i < 5; i++)
        {
            Customer c = new Customer(i, bank, resources.Length);
            threads[i] = new Thread(c.Run);
            threads[i].Start();
        }

        foreach (var t in threads)
            t.Join();
    }
}