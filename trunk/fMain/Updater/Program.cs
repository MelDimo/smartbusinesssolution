using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace com.sbs.gui.launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            if (arg.Length != 3)
            {
                MessageBox.Show("Ожидаемое кол-во аргументов: 3 " + Environment.NewLine +
                                "1 - Путь к источнику (откуда)" + Environment.NewLine +
                                "2 - Путь к рабочей папке (куда)" + Environment.NewLine +
                                "3 - Имя исполняемого файла программы" + Environment.NewLine +
                                "Файлы переносятся со структурой папок", "SmartBusinessSolution");
                return;
            }

            UpdateParam.sourcePath = arg[0];
            UpdateParam.destPath = arg[1];
            UpdateParam.mainAppName = arg[2];

            if (checkPath())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new fLauncher());
            }

            Process secondProc = new Process();
            secondProc.StartInfo.FileName = UpdateParam.mainAppName;
            secondProc.Start();
        }

        private static bool checkPath()
        {
            string errMsg = string.Empty;

            if (!Directory.Exists(UpdateParam.sourcePath)) 
                errMsg += string.Format(Environment.NewLine + "- Неверно указан путь к источнику обновления [{0}]", UpdateParam.sourcePath);

            if (!Directory.Exists(UpdateParam.destPath))
                errMsg += string.Format(Environment.NewLine + "- Неверно указан путь к приемнику обновления [{0}]", UpdateParam.destPath);

            if (errMsg.Equals(string.Empty))
                return true;
            else
            {
                MessageBox.Show(string.Format("Ошибка при проверке параметров {0}" + Environment.NewLine + "Приложение будет запущено без обновления.", errMsg), "SmartBusinessSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
    }

    public static class UpdateParam
    {
        public static string destPath { get; set; }
        public static string sourcePath { get; set; }
        public static string mainAppName { get; set; }
    }
        
}
