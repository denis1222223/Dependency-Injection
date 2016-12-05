using DIProject.Weapons;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject
{
    public class AnotherWarrior
    {
        [Inject]
        public IWeapon Weapon { get; set; }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}
