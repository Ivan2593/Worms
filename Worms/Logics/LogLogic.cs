using System.IO;

namespace Worms.Logics
{
    public class LogLogic
    {
        private static string path = @"D:\NSU\C#\Worms\My.txt";
        private StreamWriter f = new StreamWriter(path);

        public void wr(string s)
        {
            f.WriteLine(s);
        }

        public void e()
        {
            f.Close();
        }
    }
}