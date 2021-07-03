using System;

namespace LockVsMonitor
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                Class1 class1 = new Class1();

                class1.Method1();
                class1.Method2();
                class1.Method3();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}