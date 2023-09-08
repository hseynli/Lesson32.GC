using System;
using System.Threading;

// GENERATION
// GENERATION 0 - Tullantıtəmizləmə mexanizmi tərəfindən obyektlər yoxlanılmayıb.
// GENERATION 1 - Bir dəfə yoxlamaya məruz qalan obyektlər
//               (həmçinin silinmə üçün ayrılann obyektlər, amma heap-da yetərincə
//               yaddaş qaldığı üçün silinməyn obyektlər).
// GENERATION 2 - Birdən çox yoxlamaya məruz qalan obyektlər.

namespace GarbageCollector
{
    class NormalObject
    {
        byte[] array = new byte[1024]; // 1 KB
        public NormalObject()
        {
            Console.WriteLine("Constructor {0}", this.GetHashCode());
        }
        ~NormalObject()
        {
            Console.WriteLine("Destructor {0}", this.GetHashCode());
        }
    }

    class OtherObject
    {
        byte[] array = new byte[1024 * 50]; // 50 KB
    }

    class Program
    {
        static void AuxiliaryMethod()
        {
            OtherObject[] objects = new OtherObject[1000];

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = new OtherObject();
                //OtherObject @object = new OtherObject();

                Thread.Sleep(5);
            }
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Sistem {0} generasiya dəstəkləyir.", (GC.MaxGeneration + 1));
            Console.WriteLine(new string('-', 40));

            NormalObject @object = new NormalObject();

            // Heap-in paralel olaraq digər obyektlər ilə doldurulması.
            new Thread(AuxiliaryMethod).Start();

            for (int i = 0; i < 300; i++)
            {
                Console.Write("Generation: {0} | ", GC.GetGeneration(@object));
                Console.WriteLine("Heap-in ölçüsü = {0} KB", GC.GetTotalMemory(false) / 1024); // true
                Thread.Sleep(100);
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Generasiya 0 {0} dəfə yoxlanılıb", GC.CollectionCount(0));
            Console.WriteLine("Generasiya 1 {0} dəfə yoxlanılıb", GC.CollectionCount(1));
            Console.WriteLine("Generasiya 2 {0} dəfə yoxlanılıb", GC.CollectionCount(2));
            Console.WriteLine(new string('-', 40));
        }
    }
}
