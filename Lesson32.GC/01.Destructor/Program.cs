class MyClass
{
    // Destructor (Metod Finalize)
    ~MyClass()
    {
        Console.WriteLine("Hello from Destructor!");

        // Məsələn: Bazaya qoşulmanı bağlamaq.
    }
}

class Program
{
    static void Main()
    {
        MyClass my = new MyClass();

        // Destruktoru əllə birbaşa çağırmaq mümkün deyil.
        // Tullantıtəmizləmə mexanizmi tərəfindən avtomatik olaraq çağırılır.
        // my.~MyClass();
    }
}