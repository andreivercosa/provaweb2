using System;
namespace BLL.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CodigoRegistro { get; set; }
        public string DtCadastro { get; set; }
        public Funcionario()
        {
        }
    }
}
