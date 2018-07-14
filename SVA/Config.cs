using System.IO;
using System.Xml.Serialization;

namespace SVA
{
    public class Config
    {
        public string LastPath;

        public int Top;
        public int Left;
        public int Width;
        public int Height;

        public Config()
        {
            LastPath = "";
            Top = 100;
            Left = 100;
            Width = 640;
            Height = 480;
        }

        public static Config LoadFromFile(string AFileName = null)
        {
            var config = new Config();
            AFileName = AFileName ?? "config.xml";
            if (File.Exists(AFileName))
            {
                var formatter = new XmlSerializer(typeof(Config));
                using (FileStream fs = new FileStream(AFileName, FileMode.Open))
                {
                    config = (Config)formatter.Deserialize(fs);
                }
            }
            return config;
        }

        public void SaveToFile(string AFileName = null)
        {
            var formatter = new XmlSerializer(typeof(Config));

            using (FileStream fs = new FileStream(AFileName ?? "config.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }
    }
}
