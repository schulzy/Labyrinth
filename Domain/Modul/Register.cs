using Domain.Interface;
using Domain.Reader;
using Microsoft.Practices.Unity;

namespace Domain.Modul
{
    public class Register
    {
        public void RegisterAll(IUnityContainer diContainer)
        {
            RegisterReader(diContainer);
        }

        private void RegisterReader(IUnityContainer diContainer)
        {
            diContainer.RegisterType<ILabyrinthReader, ResourceLabyrinthReader>();
        }
    }
}