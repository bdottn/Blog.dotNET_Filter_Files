using Service.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service
{
    public sealed class FileService_FilterByExtension : IFileService
    {
        private readonly string path;

        public FileService_FilterByExtension(string path)
        {
            this.path = path;
        }

        public List<string> GetFiles()
        {
            return
                Directory.GetFiles(this.path)
                .Where(file => ".db".Equals(Path.GetExtension(file).ToLower()) == false)
                .ToList();
        }
    }
}