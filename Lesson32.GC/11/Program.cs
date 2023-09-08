using System;
using System.Threading;

// IDisposable.Dispose() - Desktruktora alternativ kimi.

namespace IDisposableFinalization
{
    // IDisposable interfeysinin realizasiyası.
    public class MyClass : IDisposable
    {
        // Obyektin istifadəçisi obyekt üzərində işini bitirəndən sonra bu metodu çağırmalıdır
        public void Dispose()
        {
            // İdarəoluna bilməyən obyektlərin yaddaşdan silinməsi
            // (Misal üçün verilənlər bazası ilə işləmələr).
            Console.WriteLine("Dispose() metodu işə düşdü:" + this.GetHashCode());
            Thread.Sleep(2000);
        }

        public void SomeMethod()
        {
            Console.WriteLine("Some work");
        }

        // Destruktor.
        ~MyClass()
        {
            for (int i = 0; i < 10; i++)
                Console.Write(".");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyClass instance = new MyClass();

            try
            {
                instance.SomeMethod();
            }
            finally
            {
                if (instance is IDisposable && instance != null)
                    instance.Dispose();
            }


            Console.WriteLine(new string('_', 30));

            // using konstruksiyasından istifadə zamanı:
            // Dispose() metodu avtomatik olaraq using blokunun sonunda işə düşəcəkdir.
            // Əgər using blokunun daxilində xəta baş versə, onda Dispose() metodu yenə də avtomatik olaraq çağırılacaqdır.
            // Bu kodun kompilyasiyası zamanı kompilyator avtomatik olaraq try və finally blokları yaradacaqdır
            using (instance = new MyClass())
            {
                instance.SomeMethod();
                throw new Exception();
            } // finally{ instance.Dispose();}

            // Delay.
            Console.ReadKey();
        }
    }
}
