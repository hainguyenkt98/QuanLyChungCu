using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new fQuanLyNhanVien());
=======
            Application.Run(new fQuanLyDichVuCanHo());
>>>>>>> 0f7cfdd805726c7e42d8ad0312d6ea6fbc5d1ae0
        }
    }
}
