using System.IO;

namespace Framework.Core.Extensions
{
    public static class FileHelperExtensions
    {
        public static MemoryStream ToValidMemoryStream(this MemoryStream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(stream.ToArray(), 0, stream.ToArray().Length);
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}