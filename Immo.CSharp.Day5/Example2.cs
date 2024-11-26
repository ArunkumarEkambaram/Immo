using System.IO;

namespace Immo.CSharp.Day5
{
    internal class Example2
    {
        public void WriteText(string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Creating File using File Class instead of FileStream");
            }
        }

        public string ReadText(string path)
        {
            string content = null;
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            return content;
        }
    }
}
