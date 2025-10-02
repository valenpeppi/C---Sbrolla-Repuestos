// Proyecto: Animall.App
// Archivo: TicketForm.cs

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Animall.App
{
    public partial class TicketForm : Form
    {
        private string ticketContent;
        private PrintDocument printDocument = new PrintDocument();

        public TicketForm(string ticketText)
        {
            InitializeComponent();
            this.ticketContent = ticketText;

            richTextBoxTicket.Text = ticketText;
            richTextBoxTicket.Font = new Font("Consolas", 10, FontStyle.Regular);

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el ticket:\n" + ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            Font printFont = new Font("Consolas", 10);
            float yPos = 0;
            int count = 0;
            float leftMargin = 5;
            float topMargin = 5;
            string? line = null;

            using (System.IO.StringReader sr = new System.IO.StringReader(ticketContent))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                    e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                    count++;
                }
            }

            e.HasMorePages = false;
        }

        private void btnCerrar_Click(object? sender, EventArgs e)
        {

            this.Close();
        }
    }
}

