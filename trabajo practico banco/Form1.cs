using System;
using System.Windows.Forms;
using trabajo_practico_banco.CapaNegocio;

namespace trabajo_practico_banco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length == 0 || clave.Length == 0)
            {
                lblEstado.Text = "Escribe tu usuario y contraseña.";
                return;
            }

            btnIngresar.Enabled = false;
            lblEstado.Text = "Verificando...";

            try
            {
                CN_Usuario servicio = new CN_Usuario();
                if (servicio.IniciarSesion(usuario, clave))
                {
                    FormInicio formulario = new FormInicio();
                    formulario.FormClosed += delegate { Close(); };
                    formulario.Show();
                    Hide();
                }
                else
                {
                    lblEstado.Text = "Usuario o contraseña incorrectos.";
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "No se pudo comprobar el acceso.";
                MessageBox.Show("Revisa la conexión con MySQL.\r\n\r\n" + ex.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIngresar.Enabled = true;
            }
        }
    }
}
