using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace VIEW.Pages
{

    public partial class FuncionarioCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando o Cadastro";
        }
        protected void btnCadastrarFuncionario(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = nome.Text;
                funcionario.CodigoRegistro = Convert.ToInt32(codigoRegistro.Text);


                FuncionarioDal funcionarioDal = new FuncionarioDal();
                funcionarioDal.Salvar(funcionario);

                nome.Text = "";


                string msg = "Funcionario " + funcionario.Nome +
                             " - Cadastrado com Sucesso,";

                lblMensagem.Attributes.CssStyle.Add("color", "green");

                lblMensagem.Text = msg;

                //Thread.Sleep(5000);

                //Response.Redirect("/Pages/FuncionarioCadastro.aspx");

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }
    }
}