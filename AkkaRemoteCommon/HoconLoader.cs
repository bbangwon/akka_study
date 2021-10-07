using Akka.Configuration;
using System.IO;

namespace AkkaRemoteCommon
{
    public static class HoconLoader
    {
        public static Config FromFile(string path)
        {
            var hoconContent = File.ReadAllText(path);
            return ConfigurationFactory.ParseString(hoconContent);
        }
    }
}
