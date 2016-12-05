using DIProject.Weapons;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject
{
    public class OtherWarrior
    {
        private IWeapon _weapon;

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                    // Ninject
                    // _weapon = Program.AppKernel.Get<IWeapon>();

                    // Unity
                    _weapon = ServiceLocator.Current.GetInstance<IWeapon>();
                }
                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}
