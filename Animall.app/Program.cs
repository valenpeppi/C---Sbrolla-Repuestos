// Proyecto: Animall.App
// Archivo: Program.cs

using System;
using System.Windows.Forms;

namespace Animall.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            decimal dineroInicial = 0;
            using (var formDineroInicial = new DineroInicialForm())
            {
                if (formDineroInicial.ShowDialog() == DialogResult.OK)
                {
                    dineroInicial = formDineroInicial.DineroInicial;
                }
                else
                {
                    return;
                }
            }

            Application.Run(new Form1(dineroInicial));
        }
    }
}
