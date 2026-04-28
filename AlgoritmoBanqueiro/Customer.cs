using System;
using System.Threading;

public class Customer
{
    private int id;
    private Bank bank;
    private int numberOfResources;
    private Random random = new Random();

    public Customer(int id, Bank bank, int numberOfResources)
    {
        this.id = id;
        this.bank = bank;
        this.numberOfResources = numberOfResources;
    }

    public void Run()
    {
        while (true)
        {
            // gera uma solicitação aleatória respeitando o need atual
            int[] request = new int[numberOfResources];
            int[] need = bank.GetNeed(id);

            for (int i = 0; i < numberOfResources; i++)
            {
                request[i] = random.Next(0, need[i] + 1);
            }

            bank.request_resources(id, request);

            Thread.Sleep(500);

            // libera uma quantidade aleatória do que foi solicitado
            int[] release = new int[numberOfResources];

            for (int i = 0; i < numberOfResources; i++)
            {
                release[i] = random.Next(0, request[i] + 1);
            }

            bank.release_resources(id, release);

            Thread.Sleep(500);
        }
    }
}