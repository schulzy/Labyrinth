using Domain.Interface;
using Domain.PathFinder.ParalellStrategy;
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
            diContainer.RegisterType<IPathFinder, ParalellPathFinder>();
            diContainer.RegisterType<IMapCreator, MapCreator>();

        }

    }
}