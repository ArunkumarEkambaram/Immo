using System;
using System.IO;

namespace Immo.CSharp.Day5
{
    internal class BinaryExample
    {
        private FileStream fs = null;

        public void WriteBinary(string path)
        {
            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            BinaryWriter binaryWriter = new BinaryWriter(fs);
            binaryWriter.Write(1000);
            binaryWriter.Write(true);
            binaryWriter.Write(4000.5f);
            binaryWriter.Write(false);
            binaryWriter.Flush();
            binaryWriter?.Close();
            fs?.Close();
        }

        public void ReadBinary(string path)
        {
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br=new BinaryReader(fs);
            Console.WriteLine($"Integer :{br.ReadInt32()}");
            Console.WriteLine($"Boolean :{br.ReadBoolean()}");
            Console.WriteLine($"Boolean :{br.ReadBoolean()}");
            br?.Close();
            fs?.Close();
        }
    }
}
