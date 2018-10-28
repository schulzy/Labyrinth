using System;
using Domain.Interface;
using Domain.Model;

namespace Domain.Reader
{
    internal class MapCreator : IMapCreator
    {
        private string _rawData;
        private Size _size = Size.GetEmptySize();

        public void Initialize(ILabyrinthReader labyrinthReader)
        {
            _rawData = labyrinthReader.Read();
        }

        public Map CreateMap()
        {
            var lines = _rawData.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            _size.Column = lines[0].Length;
            _size.Row = lines.Length;

            var rawMap = new bool[_size.Column, _size.Row];
            for (var i = 0; i < lines.Length; i++)
            for (var j = 0; j < lines[i].Length; j++)
                rawMap[j, i] = lines[i][j] != '#';
            var map = new Map(rawMap);
            map.StartPosition = new Point(1, map.Size.Row - 2);
            map.FinishPosition = new Point(map.Size.Column - 2, 1);
            return map;
        }
    }
}