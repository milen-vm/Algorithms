namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            var knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine(
                    "  (weight: {0}, price: {1})",
                    item.Weight,
                    item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];
            // Calculate maxPrice[0, 0...cpacity]
            for(int c = 0; c <= capacity; c++)
            {
                if(items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    isItemTaken[0, c] = true;
                }
            }
            // Calculate maxPrice[1...items.Length, 0...cpacity]
            for (int i = 1; i < items.Length; i++)
            {
                for(int c = 0; c <= capacity; c++)
                {
                    // Do not take item i
                    maxPrice[i, c] = maxPrice[i - 1, c];
                    // Try to take item i (if it gives better price)
                    int remaindingCapacity = c - items[i].Weight;
                }
            }

            throw new NotImplementedException();
        }
    }
}
