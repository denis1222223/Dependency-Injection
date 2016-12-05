using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject.Weapons
{
    class Bazuka : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Bazuka kill !");
        }
    }
}
