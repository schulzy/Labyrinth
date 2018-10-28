using Domain.Interface;
using Domain.PathFinder.SlowStrategy;
using Domain.Reader;
using Microsoft.Practices.Unity;

namespace Domain.Modul
{
    public class Register
    {
        public void RegisterAll(IUnityContainer diContainer)
        {
            diContainer.RegisterType<ILabyrinthManager, LabyrinthManager>();
            diContainer.RegisterType<ILabyrinthReader, ResourceLabyrinthReader>();
            diContainer.RegisterType<IPathFinder, SlowPathFinder>();
            diContainer.RegisterType<IMapCreator, MapCreator>();
        }
    }
}