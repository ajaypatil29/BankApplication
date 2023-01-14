using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace BankApplication
{
    class MyThreading
    {
        
        
            public void process()
            {
                Console.WriteLine("Loading ");
                for (int i = 0; i <= 5; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);

                }
                Console.WriteLine();
            }

        
    }
}
