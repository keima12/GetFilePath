using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFilePath
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] file_names = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (file_names.Length > 0)
            {
                GetFilePathLib path_getter = new GetFilePathLib();
                List<string> file_paths = path_getter.getPaths(file_names);
                Clipboard.SetText(string.Join("\r\n", file_paths));
            }else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
