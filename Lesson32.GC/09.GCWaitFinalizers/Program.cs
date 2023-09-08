using System;

namespace GCWaitFinalizers
{
    class MyClass
    {
        ~MyClass()
        {
            for (int i = 0; i < 80; i++)
                Console.Write("|");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            for (int i = 0; i < 80; i++)
                Console.Write(".");
        }
    }
}
