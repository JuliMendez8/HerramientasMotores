using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionBD;

namespace IniciarSesion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ConexionBD.Varios.Validation(txtEmail.Text, txtPassword.Text) == 1)
            {
                MessageBox.Show("Ingresó a su cuenta");
                txtEmail.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Error al conectar");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister registro = new frmRegister();
            registro.Show();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
