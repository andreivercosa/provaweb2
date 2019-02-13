using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Data;


namespace VIEW.Pages
{

    public partial class DependenteLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }



        public void btnPesquisarDependente(object sender, EventArgs e)
        {
            string nomeDependente = nome.Text;
            DependenteDal dependenteDal = new DependenteDal();

            gridListaDependente.DataSource = dependenteDal.ListarNome(nomeDependente);
            gridListaDependente.DataBind();

        }
    }
}