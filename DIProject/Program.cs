using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DIProject.Weapons;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject
{
    class Program
    {
        public static IKernel AppKernel;
        public static UnityContainer Container;

        static void Main(string[] args)
        {
            // Castle.Windsor
            Console.WriteLine("Castle.Windsor");
            var container1 = new WindsorContainer();
            container1.Register(Component.For<IWeapon>().ImplementedBy<Sword>(),
            Component.For<Warrior>().ImplementedBy<Warrior>());

            var warrior3 = container1.Resolve<Warrior>();
            warrior3.Kill();
            Console.WriteLine();


            // Autofac
            Console.WriteLine("Autofac");
            var builder = new ContainerBuilder();
            builder.RegisterType<Bazuka>();
            builder.RegisterType<Warrior>();
            builder.Register<IWeapon>(x => x.Resolve<Bazuka>());
            var container = builder.Build();

            var warrior2 = container.Resolve<Warrior>();
            warrior2.Kill();
            Console.WriteLine();

            // Unity
            Console.WriteLine("Unity");
            Container = new UnityContainer();
            Container.RegisterType(typeof(IWeapon), typeof(Bazuka));

            var serviceProvider = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => serviceProvider);

            var warrior1 = Container.Resolve<Warrior>();
            warrior1.Kill();

            var otherWarrior1 = Container.Resolve<OtherWarrior>();
            otherWarrior1.Kill();
            Console.WriteLine();


            // Ninject
            Console.WriteLine("Ninject");
            AppKernel = new StandardKernel(new WeaponNinjectModule());

            var warrior = AppKernel.Get<Warrior>();
            warrior.Kill();

            var otherWarrior = new OtherWarrior();
            otherWarrior.Kill();

            var anotherWarrior = AppKernel.Get<AnotherWarrior>();
            anotherWarrior.Kill();
            Console.WriteLine();



            Console.ReadLine();
        }
    }
}
