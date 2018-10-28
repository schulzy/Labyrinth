using System;
using System.IO;
using System.Reflection;
using Domain.Interface;

namespace Domain.Reader
{
    internal class ResourceLabyrinthReader : IResourceLabyrinthReader
    {
        private string _resourceAssembly;
        private string _resourceName;

        public void Initialize(string resourceAssembly, string resourceName)
        {
            _resourceName = resourceName;
            _resourceAssembly = resourceAssembly;
        }

        public string Read()
        {
            string result;
            var assembly = Assembly.Load(_resourceAssembly);
            using (var stream = assembly.GetManifestResourceStream(_resourceName))
            {
                if (stream == null)
                    throw new ArgumentNullException($"The stream is not set");

                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }

    internal interface IResourceLabyrinthReader : ILabyrinthReader
    {
        void Initialize(string resourceAssembly, string resourceName);
    }
}