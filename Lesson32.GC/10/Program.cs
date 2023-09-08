using System;

// Böyük obyektlər birbaşa olaraq big heap-də yerləşir və onlar ikinici generasiyaya aid olur.

namespace GCMemoryException
{
    // BigObject - böyük obyekt üçün yaradılan obyektdir. Balaca heap-də yerləşəcək.
    class BigObject
    {
        // Həqiqətən  böyük obyektdir. Big heap-də yerləşəcəkdir.
        // 100 000 000 * 4 B = 400 000 000 B = 390 625 KB = 381 MB
        Array array = new int[100000000];
        public BigObject()
        {
            Console.WriteLine(this.GetHashCode());
        }
        ~BigObject()
        {
            Console.WriteLine("Obyekt " + this.GetHashCode() + " silindi");
        }
    }
    class Program
    {
        static void Main()
        {
            // BigObject-dən ibarət massiv.
            // 381 * 1000 = 381 000 MB = 372 QB - bütün massivin ölçüsü.
            BigObject[] objects = new BigObject[1000];

            try
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i] = new BigObject();
                    //BigObject @object = new BigObject(); // optimize +
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
