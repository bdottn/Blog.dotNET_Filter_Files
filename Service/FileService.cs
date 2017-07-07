using Service.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service
{
    public sealed class FileService : IFileService
    {
        private readonly string path;

        public FileService(string path)
        {
            this.path = path;
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(this.path).ToList();
        }
    }
}