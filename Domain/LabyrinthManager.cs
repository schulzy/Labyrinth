using System;
using Domain.Interface;
using Domain.Reader;
using Microsoft.Practices.Unity;
using Resources.Constants;

namespace Domain
{
    public class LabyrinthManager : ILabyrinthManager
    {
        private readonly IUnityContainer _diContainer;
        private IMapCreator _mapCreator;

        public LabyrinthManager(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void LoadLevel(int level)
        {
            if (AssemblyConstants.Levels.Length < level)
                throw new ArgumentOutOfRangeException($"There is no level {level}");

            _mapCreator = _diContainer.Resolve<IMapCreator>();
            var labyrinthReader = _diContainer.Resolve<ILabyrinthReader>();
            (labyrinthReader as IResourceLabyrinthReader)?.Initialize(AssemblyConstants.AssemblyName,
                AssemblyConstants.Levels[level - 1]);
            _mapCreator.Initialize(labyrinthReader);
        }

        public void FindPath()
        {
            var pathFinder = _diContainer.Resolve<IPathFinder>();
            pathFinder.FindPath(_mapCreator);
        }
    }
}