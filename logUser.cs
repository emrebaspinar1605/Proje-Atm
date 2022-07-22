using System;
namespace AtmApp
{
    public partial class LogUser
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\Pratikler\MiniProjects\Proje-Atm\userLog.txt";
        public static bool UserControl(string userName)
        {
            if(LogUser.GetUsers().Contains(userName))
                return true;
            else return false;
        }
        public static List<string> GetUsers()
        {
            FileControl();
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    while(!sr.EndOfStream)
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
        public static void AddUser(string userName)
        {
            FileControl();

            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine(userName.TrimEnd().TrimStart());
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
    public class User
    {
        private string userName;
        public User(string userName)
        {
            this.userName = userName;
        }
    }
}