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
            Application.Run(new fQuanLyCanHo());
>>>>>>> 0e8944d8a95cde0fcd0854820f0dd43c38c9516c

        }
    }
}
