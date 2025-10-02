// Proyecto: Animall.App
// Archivo: DineroInicialForm.cs

using System;
using System.Windows.Forms;

namespace Animall.App
{
    public partial class DineroInicialForm : Form
    {
        public decimal DineroInicial { get; private set; }

        public DineroInicialForm()
        {
            InitializeComponent();
        }

        private void DineroInicialForm_Load(object sender, EventArgs e)
        {
            // Pone el foco en el campo numérico y selecciona el texto.
            this.ActiveControl = numDineroInicial;
            numDineroInicial.Select(0, numDineroInicial.Text.Length);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DineroInicial = numDineroInicial.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numDineroInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}

