using Service.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Service
{
    public sealed class FileService_FilterByRegularExpression : IFileService
    {
        private readonly string path;

        public FileService_FilterByRegularExpression(string path)
        {
            this.path = path;
        }

        public List<string> GetFiles()
        {
            var pattern = @"^(.)*.(db|DB)$";

            return
                Directory.GetFiles(this.path)
                .Where(file => new Regex(pattern).IsMatch(Path.GetFileName(file)) == false)
                .ToList();
        }
    }
}