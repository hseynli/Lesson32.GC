using System;

// Destruktorda baş verən xəta onun işinin dayanmasına gətirib çıxaracaq.

namespace DestructorException
{
    class MyClass
    {
        ~MyClass()
        {
            throw new Exception();

            Console.WriteLine("Succeeded!");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
        }
    }
}
