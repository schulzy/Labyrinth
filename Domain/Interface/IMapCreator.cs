namespace Domain.Interface
{
    internal interface IMapCreator
    {
        void Initialize(ILabyrinthReader reader);
        bool[,] Map { get; }
    }
}