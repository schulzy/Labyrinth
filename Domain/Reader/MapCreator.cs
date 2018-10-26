using System;
using Domain.Interface;

namespace Domain.Reader
{
    internal class MapCreator : IMapCreator
    {
        private bool[,] _map;
        private Size _size = Size.GetEmptySize();

        public void Initialize(ILabyrinthReader labyrinthReader)
        {
            var rawData = labyrinthReader.Read();
            FillMap(rawData);
        }

        public Size Size => _size;

        public bool[,] Map => _map;

        private void FillMap(string rawData)
        {
            string[] lines = rawData.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            _size.Column = lines[0].Length;
            _size.Row = lines.Length;

            _map = new bool[_size.Column, _size.Row];
            for (int i=0;i<lines.Length;i++)
            {
                for (int j=0;j<lines[i].Length;j++)
                {
                    _map[j, i] = lines[i][j] != '#';
                }
            }
        }
    }
}
