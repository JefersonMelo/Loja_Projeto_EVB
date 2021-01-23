using System;
using System.Windows.Forms;

namespace Loja.UI
{
    public partial class MDI_Loja : Form
    {
        private int childFormNumber = 0;

        public MDI_Loja()
        {
            InitializeComponent();
        }
        private void MDI_Loja_Load(object sender, EventArgs e)
        {

        }

        private void Cadastro_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //direcionamento para o Catastro_Usuarios.cs
            Form form_filho = new Cadastro_Usuario();
            form_filho.MdiParent = this;
            form_filho.Show();
        }
    }
}
