using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            List<Task> userTheards = new List<Task>();
            Random random = new Random();

            foreach (int i in Enumerable.Range(0, 50))
            {
                userTheards.Add(Task.Run(() =>
                {
                    if (random.Next(5) % 3 == 0)
                    {
                        Server.AddToCount(i);
                    }
                    else
                    {
                        Server.GetCount();
                    }
                }));
            }

            await Task.WhenAll(userTheards);
        }
    }
}
