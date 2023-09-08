using System;

namespace DestructorObject
{
    class MyClass : Object
    {
        // INFO:
        // Object base klasının daxilində özündə destruktor var, 
        // amma o törəmə klaslar üçün çağırılmır.
        // Törəmə klasların hamısında əllə destruktor çağırmaq lazımdır.        
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
        }
    }
}
