namespace Testing
{
    public class BankAccount
    {
        object padlock = new object();
        public int Balance { get; private set; }

        private int balance;
        public int Balance2
        {
            get { return balance;  }
            private set { balance = value; }
        }

        public void Deposit(int amount)
        {

            //this op is not atomic
            // op1: temp => get_balance + amount
            // op2: set_balance = temp
            lock (padlock)
            {
                Balance += amount;
            }
        }
        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }

        public void WithdrawInterlock(int amount)
        {

            Interlocked.Add(ref balance, -amount);
                //Balance -= amount;
            
        }
    }

    public class SharingDataTasks
    {
        public void TestingBankAccounts()
        {
            var ba = new BankAccount();
            var tasks = new List<Task>();

            SpinLock sl = new SpinLock();

            for(int i = 1; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                       ba.Deposit(100);
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final balance is {ba.Balance}");
            Console.ReadKey();
        }
        static SpinLock sl = new SpinLock();
        public static void LockRecursion(int x)
        {
            bool locktaken = false;
            try
            {
                sl.Enter(ref locktaken);
            }
            catch (LockRecursionException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
            finally
            {
                if (locktaken)
                {
                    LockRecursion(x - 1);
                    sl.Exit();
                }
            }

        }
    }
}
