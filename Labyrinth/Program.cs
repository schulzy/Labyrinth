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
        }
    }
}