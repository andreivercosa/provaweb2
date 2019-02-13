using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;
namespace DAL.Persistence
{
    public class DependenteDal : Conexao
    {
        public void Salvar(Dependente dependente)
        {
            try
            {
                var sql = "INSERT INTO dependente(nome, idade, idFuncionario, dtCadastro)" +
                          "VALUES(@nome, @idade, @idFuncionario, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", dependente.Nome);
                command.Parameters.AddWithValue("@idade", dependente.Idade);
                command.Parameters.AddWithValue("@idFuncionario", dependente.IdFuncionario);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }

        public DataTable ListarNome(string nome)
        {
            try
            {

                var sql = "SELECT * FROM dependente WHERE nome LIKE '%" + nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();


                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("idDependente");
                dataTable.Columns.Add("dependente");
                dataTable.Columns.Add("funcionario");
               
                while (dataReader.Read())
                {
                    Dependente dependente = new Dependente();
                    FuncionarioDal funcionarioDal = new FuncionarioDal();


                    dependente.Id = Convert.ToInt32(dataReader["id"]);
                    dependente.IdFuncionario = Convert.ToInt32(dataReader["idFuncionario"]);
                    dependente.Funcionario = funcionarioDal.FuncionarioID(dependente.IdFuncionario);
                    dependente.Nome = dataReader["nome"].ToString();
                    dataTable.Rows.Add(dependente.Id, dependente.Nome, dependente.Funcionario.Nome);
                }

                return dataTable;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }
        public DependenteDal()
        {
            AbrirConexao();
        }
        ~DependenteDal()
        {
            FecharConexao();
        }
    }
}
