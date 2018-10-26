using System;
using System.IO;
using System.Reflection;
using Domain.Interface;
using Microsoft.Practices.Unity;

namespace Domain.Reader
{
    internal class ResourceLabyrinthReader : IResourceLabyrinthReader
    {
        private string _resourceName;
        private string _resourceAssembly;
       
        public void Initialize(string resourceAssembly, string resourceName)
        {
            _resourceName = resourceName;
            _resourceAssembly = resourceAssembly;
        }

        public string Read()
        {
            string result;
            var assembly = Assembly.Load(_resourceAssembly);
            using (Stream stream = assembly.GetManifestResourceStream(_resourceName))
            {
                if (stream == null)
                    throw new ArgumentNullException($"The stream is not set");
                
                using (StreamReader reader = new StreamReader(stream))
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