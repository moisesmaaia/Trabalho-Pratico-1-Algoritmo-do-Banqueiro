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

        // inicializa os recursos disponíveis a partir dos argumentos da linha de comando
        int[] resources = new int[args.Length];

        for (int i = 0; i < args.Length; i++)
            resources[i] = int.Parse(args[i]);

        Bank bank = new Bank(resources);

        // cria e inicia uma thread por cliente
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