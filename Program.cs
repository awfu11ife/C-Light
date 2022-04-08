using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork34
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> purchaseAmount = new Queue<int>();
            int queueLenght = 5;
            int revenu = 0;

            FillQueue(purchaseAmount, queueLenght);
            ServeQueue(purchaseAmount, ref revenu);
        }

        static void FillQueue(Queue<int> queue, int queueLenght)
        {
            Random random = new Random();
            int maxPurchaseAmount = 200;
            int minPurchaseAmount = 80;

            for (int i = 0; i < queueLenght; i++)
            {
                queue.Enqueue(random.Next(minPurchaseAmount, maxPurchaseAmount));
            }
        }

        static void ServeQueue(Queue<int> queue, ref int revenu)
        {
            int visitorNumber = 1;

            while (queue.Count > 0)
            {
                Console.WriteLine($"Клиент номер {visitorNumber} принес вам {queue.Peek()} золота");
                revenu += queue.Dequeue();
                visitorNumber++;
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"В очереди осталось {queue.Count} человек");
                Console.WriteLine($"Текущая выручка - {revenu} золота");
            }
        }
    }
}
