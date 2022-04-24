using System.IO;

namespace FileReaderClass
{
    public static class FileReader
    {
        static string divider = "\n ******* \n";
        public static string ReadText(string path)
        {
            StreamReader reader = new StreamReader(path);
            string result = reader.ReadToEnd();
            reader.Close();

            return result;
        }

        public static void WriteFilesToFile(string toPath, params string[] fromPathes)
        {
            string result = ReadText(toPath);

            foreach (var fromPath in fromPathes)
            {
                result += ReadText(fromPath) + divider;
            }

            StreamWriter writer = new StreamWriter(toPath);
            writer.Write(result);
            writer.Close();
        }
    }
}