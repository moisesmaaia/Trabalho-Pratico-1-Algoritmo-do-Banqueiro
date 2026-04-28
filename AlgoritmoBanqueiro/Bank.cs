using System;

public class Bank
{
    private int NUMBER_OF_CUSTOMERS = 5;
    private int NUMBER_OF_RESOURCES;

    private int[] available;
    private int[,] maximum;
    private int[,] allocation;
    private int[,] need;

    private readonly object mutex = new object();

    private Random random = new Random();

    public Bank(int[] resources)
    {
        NUMBER_OF_RESOURCES = resources.Length;

        available = new int[NUMBER_OF_RESOURCES];
        Array.Copy(resources, available, NUMBER_OF_RESOURCES);

        maximum = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];
        allocation = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];
        need = new int[NUMBER_OF_CUSTOMERS, NUMBER_OF_RESOURCES];

        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
            {
                maximum[i, j] = random.Next(1, resources[j] + 1);
                need[i, j] = maximum[i, j];
            }
        }
    }

    public int request_resources(int customer_num, int[] request)
    {
        lock (mutex)
        {
            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                if (request[i] > need[customer_num, i])
                    return -1;

                if (request[i] > available[i])
                    return -1;
            }

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                available[i] -= request[i];
                allocation[customer_num, i] += request[i];
                need[customer_num, i] -= request[i];
            }

            if (IsSafe())
            {
                Console.WriteLine($"Cliente {customer_num}: solicitação CONCEDIDA [{string.Join(", ", request)}]");
                return 0;
            }

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                available[i] += request[i];
                allocation[customer_num, i] -= request[i];
                need[customer_num, i] += request[i];
            }
            Console.WriteLine($"Cliente {customer_num}: solicitação NEGADA [{string.Join(", ", request)}]");
            return -1;
        }
    }

    public int release_resources(int customer_num, int[] release)
    {
        lock (mutex)
        {
            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                if (release[i] > allocation[customer_num, i])
                    return -1;
            }

            for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            {
                available[i] += release[i];
                allocation[customer_num, i] -= release[i];
                need[customer_num, i] += release[i];
            }
            Console.WriteLine($"Cliente {customer_num}: recursos LIBERADOS [{string.Join(", ", release)}]");
            return 0;
        }
    }

    private bool IsSafe()
    {
        int[] work = new int[NUMBER_OF_RESOURCES];
        bool[] finish = new bool[NUMBER_OF_CUSTOMERS];

        Array.Copy(available, work, NUMBER_OF_RESOURCES);

        while (true)
        {
            bool found = false;

            for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
            {
                if (!finish[i])
                {
                    bool canFinish = true;

                    for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
                    {
                        if (need[i, j] > work[j])
                        {
                            canFinish = false;
                            break;
                        }
                    }

                    if (canFinish)
                    {
                        for (int j = 0; j < NUMBER_OF_RESOURCES; j++)
                            work[j] += allocation[i, j];

                        finish[i] = true;
                        found = true;
                    }
                }
            }

            if (!found)
                break;
        }

        for (int i = 0; i < NUMBER_OF_CUSTOMERS; i++)
        {
            if (!finish[i])
                return false;
        }

        return true;
    }

    public int[] GetNeed(int customer)
    {
        int[] result = new int[NUMBER_OF_RESOURCES];
        for (int i = 0; i < NUMBER_OF_RESOURCES; i++)
            result[i] = need[customer, i];

        return result;
    }
}