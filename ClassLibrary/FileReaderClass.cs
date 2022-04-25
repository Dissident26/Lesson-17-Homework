using System.IO;

namespace FileReaderClass
{
    public static class FileReader
    {
        static Mutex mutex = new Mutex(false);
        static string divider = "\n ******* \n";
        public static string ReadText(string path)
        {
            StreamReader reader = new StreamReader(path);
            string result = reader.ReadToEnd();
            reader.Close();

            return result;
        }

        public static void WriteToFileMultiThread(string toPath,string fromPath)
        {
            mutex.WaitOne();

            string result = ReadText(toPath);

            result += ReadText(fromPath) + divider;

            StreamWriter writer = new StreamWriter(toPath);
            writer.Write(result);
            writer.Close();

            mutex.ReleaseMutex();
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

        public static void WriteFilesToFileMultiThread(string toPath, params string[] fromPathes)
        {
            List<Task> tasks = new(fromPathes.Length);

            foreach (var fromPath in fromPathes)
            {
                tasks.Add(Task.Factory.StartNew(() => WriteToFileMultiThread(toPath, fromPath)));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}