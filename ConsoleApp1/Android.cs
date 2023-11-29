using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Android : Robot, IFlying, IWalking
    {
        public override void Move()
        {
            this.Fly();
            this.Walk();
        }
        public void Fly()
        {
            Console.WriteLine("Я могу летать");
        }

        public void Walk()
        {
            Console.WriteLine("я могу ходить");
        }
    }
}
