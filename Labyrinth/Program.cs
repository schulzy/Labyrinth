using Domain.Interface;
using Domain.Modul;
using Microsoft.Practices.Unity;

namespace Labyrinth
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new UnityContainer();
            var register = new Register();
            register.RegisterAll(container);

            var manager = container.Resolve<ILabyrinthManager>();
            manager.LoadLevel(2);
            manager.FindPath();
        }
    }
}