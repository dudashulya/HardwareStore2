using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Copter : Robot, IFlying
    {
        public override void Move()
        {
            this.Fly();
        }

        public  void Fly()
        {
            Console.WriteLine("Я умею летать!");
        }
    }
}
