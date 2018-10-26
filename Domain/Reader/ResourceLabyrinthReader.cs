using System;
using Domain.Interface;

namespace Domain.Reader
{
    internal class ResourceLabyrinthReader : ILabyrinthReader
    {
        private string _resourcePath;

        public ResourceLabyrinthReader(string resourcePath)
        {
            _resourcePath = resourcePath;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}