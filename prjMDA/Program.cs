using prjMDA.電影;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMDA
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MDA());

            //Application.Run(new Director());
            Application.Run(new FormMain());
            //Application.Run(new MovieIImagesList());
            //Application.Run(new MovieImages());
            //Application.Run(new 導演());

        }
    }
}
