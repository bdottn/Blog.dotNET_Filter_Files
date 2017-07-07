using Service.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Service
{
    public sealed class FileService_FilterByFileAttribute : IFileService
    {
        private readonly string path;

        public FileService_FilterByFileAttribute(string path)
        {
            this.path = path;
        }

        public List<string> GetFiles()
        {
            return
                new DirectoryInfo(this.path).GetFiles()
                .Where(file =>
                    file.Attributes.HasFlag(FileAttributes.System) == false &&
                    file.Attributes.HasFlag(FileAttributes.Hidden) == false)
                .Select(file => file.FullName)
                .ToList();
        }
    }
}