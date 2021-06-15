using System.IO;

namespace AT.Test.Util
{
    public static class RandomUtil
    {
        public static string GetRandomString(string prefix ="")
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return !string.IsNullOrEmpty(prefix) ? $"{prefix}_{path}" : path;
        }
    }
}
