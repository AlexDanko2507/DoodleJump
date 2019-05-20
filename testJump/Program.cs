using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testJump
{
    static class CheckRecord
    {
        public static bool Value { get; set; }
        public static bool CheckForm { get; set; }
        public static bool CheckBack { get; set; }
        public static string Name { get; set; }
        public static int Scores { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
