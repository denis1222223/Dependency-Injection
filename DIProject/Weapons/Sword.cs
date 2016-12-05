using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject.Weapons
{
    class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Sword kill !");
        }
    }
}
