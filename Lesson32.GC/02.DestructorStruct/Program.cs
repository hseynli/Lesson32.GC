struct MyStruct
{
    // Strukturlarda desktruktordan istifadə etmək mümkün deyil.
    //~ MyStruct()
    //{

    //}
}

class MyClass
{
    // Destruktorlar arqument qəbul edə bilməz.

    //~ MyClass(int arg)
    //{

    //}

    // Destruktorlar statik ola bilməz.
    //static ~MyClass()
    //{

    //}

    // Destruktorların acess modifier-i ola bilməz.

    //public ~ MyClass()
    //{

    //}
}

class Program
{
    static void Main()
    {
    }
}