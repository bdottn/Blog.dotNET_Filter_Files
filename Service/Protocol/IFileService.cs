using System.Collections.Generic;

namespace Service.Protocol
{
    public interface IFileService
    {
        List<string> GetFiles();
    }
}