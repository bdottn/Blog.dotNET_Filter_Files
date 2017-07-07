using Service.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service
{
    public sealed class FileService_FilterBySearchPattern : IFileService
    {
        private readonly string path;

        public FileService_FilterBySearchPattern(string path)
        {
            this.path = path;
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(this.path, "*.jpg").ToList();
        }
    }
}