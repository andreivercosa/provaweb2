using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace VIEW.Pages
{

    public partial class DependenteCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindFuncionarios();
        }
        protected void btnCadastrarDependente(object sender, EventArgs e)
        {
            try
            {
                Dependente dependente = new Dependente();
                dependente.Nome = nome.Text;
                dependente.IdFuncionario = Int32.Parse(idFuncionario.SelectedValue);

                DependenteDal dependenteDal = new DependenteDal();
                dependenteDal.Salvar(dependente);

                nome.Text = "";
                idFuncionario.Text = "";

                string msg = "Dependente " + dependente.Nome + " foi cadastrado com Sucesso";
                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                Response.Redirect("/Page/DependenteCadastro.aspx");
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindFuncionarios()
        {
            FuncionarioDal funcionarioDal = new FuncionarioDal();
            List<Funcionario> listaFuncionario = new List<Funcionario>();

            listaFuncionario = funcionarioDal.Listar();
            //idFuncionario.Items.Clear();
            foreach (var funcionario in listaFuncionario)
            {
                idFuncionario.Items.Insert(0, new ListItem(funcionario.Nome, funcionario.Id.ToString()));
            }


        }
    }
}