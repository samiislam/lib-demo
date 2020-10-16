using System;
using mylib;

namespace myconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassLib cl = new ClassLib();
            Console.WriteLine(cl.Call("Jack"));
        }
    }
}
