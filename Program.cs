//Written for From Village to Empire. https://store.steampowered.com/app/791400
namespace From_Village_to_Empire_Extractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryReader br = new(File.OpenRead(args[0]));

            if (new string(br.ReadChars(4)) != "WLP2")
                throw new Exception("This is mot a wlp file.");

            string path = Path.GetDirectoryName(args[0]) + "\\" + Path.GetFileNameWithoutExtension(args[0]) + "\\";
            Directory.CreateDirectory(path);
            while (br.BaseStream.Position < br.BaseStream.Length - 4)
            {
                br.ReadInt32();//2
                int size = br.ReadInt32();
                string name = new string(br.ReadChars(br.ReadInt32()));
                BinaryWriter bw = new(File.Create(path + name));
                bw.Write(br.ReadBytes(size));
                bw.Close();
            }
        }
    }
}