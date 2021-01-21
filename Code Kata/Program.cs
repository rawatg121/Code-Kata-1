using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"c:\Kata.txt";
            KataConstructorInjection obj = new KataConstructorInjection();
            obj.StartTrip();
        }
    }
}
