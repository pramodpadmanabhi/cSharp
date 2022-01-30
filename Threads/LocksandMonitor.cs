using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class LocksandMonitor
    {
    }

    public class Acccount
    {
        int balance;
        Object objLock = new object();
        Random random = new Random();
        public Acccount(int initialBalance)
        {
            balance = initialBalance;
        }
        public int Withdraw(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("Not enough Balance");
            }

            //Monitor.Enter(objLock);
            //lock(objLock){}
            //try
            //{
                if (balance >= amount)
                {
                    Console.WriteLine("Amount drawn " + amount);
                    balance = balance - amount;
                    return balance;
                }
            //}
            //finally
            //{
            //    Monitor.Exit(objLock);
            //}
            return 0;

        }
        public void WithdrawRandomly()
        {
            for(int i = 0; i < 100; i++)
            {
                var balance = Withdraw(random.Next(2000, 5000));
                if (balance > 0)
                {
                    Console.WriteLine("Balance Left " + balance);
                }
            }
           
        }
    }
}
