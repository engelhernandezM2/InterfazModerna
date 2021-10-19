using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace interfazModerna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que deseas salir ", "Salir ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void AbrirFrmHijo(Object FmrHijo)
        {
            if (panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form f1 = FmrHijo as Form;
            f1.TopLevel = false;
            f1.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(f1);
            this.panelContenedor.Tag = f1;
            f1.Show();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);
        }
        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "releaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wmsg, int wparam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }
        #region VisibilidadDelSubMenu
        private void btnReportes_Click(object sender, EventArgs e)
        {
            pnlSubmenu.Visible = true;
        }

        private void btnRptVentas_Click(object sender, EventArgs e)
        {
            pnlSubmenu.Visible = false;
        }

        private void btnRptCompras_Click(object sender, EventArgs e)
        {
            pnlSubmenu.Visible = false;
        }

        private void btnRptPagos_Click(object sender, EventArgs e)
        {
            pnlSubmenu.Visible = false;
        }
        #endregion

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FrmProductos());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFrmHijo(new FrmInicio());
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
