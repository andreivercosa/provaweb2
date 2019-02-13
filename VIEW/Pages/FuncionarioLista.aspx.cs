using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Model;
using DAL.Persistence;

namespace VIEW.Pages
{

    public partial class FuncionarioLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnPesquisarFuncionario(object sender, EventArgs e)
        {
            int codigoFuncionario = Convert.ToInt32(codigoRegistro.Text.ToString());
            FuncionarioDal funcionarioDal = new FuncionarioDal();

            gridListaFuncionario.DataSource = funcionarioDal.pesquisarFuncionario(codigoFuncionario);
            gridListaFuncionario.DataBind();


        }
    }
}