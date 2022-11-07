using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionBD;

namespace IniciarSesion
{
    public partial class frmRegister : Form
    {
        //-------------------------------------------Variables-------------------------------------------------------
        int cerrar = 0;

        //-------------------------------------------Funciones-------------------------------------------------------
        public void sendAndValidation()
        {
            if (ConexionBD.Varios.validationEmail(txtEmail.Text) == 0)
            {
                MessageBox.Show(ConexionBD.Varios.Register(txtCedula.Text, txtFirstName.Text, txtSecondName.Text,
                    txtFirstLastName.Text, txtSecondLastName.Text, txtEmail.Text, txtPassword.Text));
                clear();
            }
            else
            {
                MessageBox.Show("Este correo ya está registrado");
            }
        }
        public void clear()
        {
            txtCedula.Clear();
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtFirstLastName.Clear();
            txtSecondLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmation.Clear();
            cerrar = 1;

            this.Close();

            frmLogin login = new frmLogin();
            login.Show();
            cerrar = 0;
        }
        public frmRegister()
        {
            InitializeComponent();
        }

        //-------------------------------------------Botones-------------------------------------------------------
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Se verifica que todos los campos estén llenos a excepción del segundo nombre.
            if (txtFirstName.Text == string.Empty || txtFirstLastName.Text == string.Empty || 
                txtSecondLastName.Text == string.Empty || txtEmail.Text == string.Empty || txtCedula.Text == string.Empty ||
                txtPassword.Text == string.Empty || txtConfirmation.Text == string.Empty)
            {
                MessageBox.Show("Rellene todos los campos, por favor :)");
            }
            //Se verifica que la contraseña y la verificación de contraseña sean iguales.
            else if (txtPassword.Text == txtConfirmation.Text)
            {
                if (txtSecondName.Text == String.Empty)
                {
                    //Si el campo del segundo nombre está vacío se cambia por un NULL.
                    txtSecondName.Text = "NULL";
                    sendAndValidation();//Se valida que el correo no exista y se hace el envío de datos.
                }
                else
                {
                    sendAndValidation();
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden :(");
            }
        }

        //-------------------------------------------Acción-------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e)
        {
            cerrar = 1;
            this.Close();
            frmLogin login = new frmLogin();
            login.Show();
            cerrar = 0;
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrar == 0)
            {
                Application.Exit();
            }
        }
    }
}
