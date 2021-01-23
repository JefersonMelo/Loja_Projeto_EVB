using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Loja.DTO;
using Loja.BLL;

namespace Loja.UI
{
    public partial class Cadastro_Usuario : Form
    {
        string modo = "";
        public Cadastro_Usuario()
        {
            InitializeComponent();
        }
        private void Cadastro_Usuario_Load(object sender, EventArgs e)
        {
            carregarGridView();
           
        }

        private void carregarGridView()
        { 
            try
            {
                //carregar lista do banco
                IList<Usuario_DTO> listUsuario_DTO = new List<Usuario_DTO>();
                listUsuario_DTO = new UsuarioBLL().carregarUsuario();
                //preencher dados no data grid view
                dataGridView1.DataSource = listUsuario_DTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;
            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtData_Cadastro.Text = Convert.ToString(dataGridView1["data_cadastro", sel].Value);

            //Condição se a situação for igual a "A" então o combobox ficará Ativo senao "Inativo"
            if (Convert.ToString(dataGridView1["situacao", sel].Value) == "A")
            {
                comBoxSituacao.Text = "Ativo";
            }
            else
            {
                comBoxSituacao.Text = "Inativo";
                //comBoxSituacao.Text = Convert.ToString(dataGridView1["perfil", sel].Value);
            }

            switch (Convert.ToString(dataGridView1["perfil", sel].Value))
            {
                // caso 1, Administrador
                case "1":
                    comBoxPerfil.Text = "Adminstração";
                    break;
                case "2":
                    comBoxPerfil.Text = "Operação";
                    break;
                case "3":
                    comBoxPerfil.Text = "Gerencial";
                    break;

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtData_Cadastro_TextChanged(object sender, EventArgs e)
        {

        }

        private void comBoxSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Método crido para limpar campos antes de preenchimento
        private void Limpar_Campos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtData_Cadastro.Text = "";
            comBoxPerfil.Text = "";
            comBoxSituacao.Text = "";


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (modo == "novo")
            {
                try
                {
                    Usuario_DTO usuario_DTO = new Usuario_DTO();
                    usuario_DTO.Nome = txtNome.Text;
                    usuario_DTO.Login = txtLogin.Text;
                    usuario_DTO.Email = txtEmail.Text;
                    usuario_DTO.Data_cadastro = System.DateTime.Now;
                    usuario_DTO.Senha = txtSenha.Text;

                    if (comBoxSituacao.Text == "Ativo")
                    {
                        usuario_DTO.Situacao = "A";
                    }
                    else
                    {
                        usuario_DTO.Situacao = "I";
                    }
                    switch (comBoxPerfil.Text)
                    {
                        case "Administração":
                            usuario_DTO.Perfil = 1;
                            break;
                        case "Operação":
                            usuario_DTO.Perfil = 2;
                            break;
                        case "Gerencial":
                            usuario_DTO.Perfil = 3;
                            break;
                    }

                    int x = new UsuarioBLL().insereUsuario(usuario_DTO);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado Com Sucesso!");
                    }

                    //Recarregar Grid View
                    carregarGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro Inesperado: " + ex.Message);
                }
                modo = "";
            }
        }

        private void buttonDeletar_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            modo = "alterar";

        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            //limpar campos antes de novo preenchimento
            Limpar_Campos();

            //inserindo data atual automaticamente no txtCadastro
            txtData_Cadastro.Text = Convert.ToString(System.DateTime.Now);

            //após clicar no botão NOVO, modo passa a ser novo (incluindo um registro)
            modo = "novo";
        }
    }
}
