using System;
namespace BLL.Model
{
    public class Dependente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int IdFuncionario { get; set; }
        public string DtCadastro { get; set; }
        public Funcionario Funcionario  { get; set; }

    public Dependente()
        {
        }
    }
}
