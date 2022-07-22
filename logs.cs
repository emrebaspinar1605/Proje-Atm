using System;

namespace AtmApp
{
    class Logs
    {
        static string path =Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\Pratikler\MiniProjects\Proje-Atm\logs.txt";

        public static List<string> GetLogs()
        {
            FileControl();
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    while (!sr.EndOfStream)
                    {
                        string row = sr.ReadLine();
                        if (!String.IsNullOrEmpty(row))
                        {
                            list.Add(row.TrimEnd().TrimStart());
                        }
                    }
                }
                catch {}
            }
            return list;
        }
        public static void AddLog(string userName,string log)
        {
            FileControl();
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine($"{DateTime.Now} {userName}: "+log);
            }
        }
        static void FileControl()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
    }
}