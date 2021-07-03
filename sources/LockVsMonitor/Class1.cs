using System;
using System.Threading;

namespace LockVsMonitor
{
    public class Class1
    {
        private readonly object syncObject = new object();

        public void Method1()
        {
            lock (syncObject)
            {
                Console.WriteLine("something");
            }
        }

        /// <remarks>
        /// Initially, I thought that the <c>lock</c> block is implemented like in this method.
        /// But this is not true.
        /// </remarks>
        public void Method2()
        {
            Monitor.Enter(syncObject);

            try
            {
                Console.WriteLine("something");
            }
            finally
            {
                Monitor.Exit(syncObject);
            }
        }

        /// <remarks>
        /// The <c>lock</c> block is implemented like in this method.
        /// </remarks>
        public void Method3()
        {
            // From Microsoft's documentation about "Monitor.Enter(object obj, ref bool lockTaken)":
            // 
            // "If the lock was not taken because an exception was thrown, the variable specified for the lockTaken parameter
            // is false after this method ends. This allows the program to determine, in all cases, whether it is necessary
            // to release the lock. If this method returns without throwing an exception, the variable specified for the
            // lockTaken parameter is always true, and there is no need to test it."

            object localSyncObject = syncObject;
            bool lockTaken = false;

            try
            {
                Monitor.Enter(localSyncObject, ref lockTaken);

                Console.WriteLine("something");
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(localSyncObject);
            }
        }
    }
}