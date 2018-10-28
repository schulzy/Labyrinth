using Domain.Model;

namespace Domain.Interface
{
    internal interface IMapCreator
    {
        void Initialize(ILabyrinthReader reader);

        Map CreateMap();
    }
}