using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tirtel : Robot, IWalking, ISwimming
    {
        public override void Move()
        {
            this.Walk();
            this.Swim();
        }
        public void Swim()
        {
            Console.WriteLine("Я могу плавать");
        }

        public void Walk()
        {
           Console.WriteLine("Я могу ходить");
        }
    }
}
