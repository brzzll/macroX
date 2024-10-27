using System;
using System.Windows.Forms;

namespace macrosx_
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length < 4){return;}
            int parametro1, parametro2;
            if (!int.TryParse(args[0], out parametro1)||!int.TryParse(args[1], out parametro2)){return;}
            string parametro3 = args[2];
            string parametro4 = args[3];
            string parametro5 = args[4];
            string parametro6 = args[5];
            Application.Run(new Form1(parametro1, parametro2, parametro3, parametro4, parametro5, parametro6));
        }
    }
}
