using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Copter  copter = new Copter();
            copter.Move();
            Console.WriteLine();
            Android android = new Android();
            android.Move();
            Console.WriteLine();
            Tirtel  tirtel = new Tirtel();
            tirtel.Move();
        }
    }
}
