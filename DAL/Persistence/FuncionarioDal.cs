using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class FuncionarioDal : Conexao
    {
        public void Salvar(Funcionario funcionario)
        {
            try
            {
                var sql = "INSERT INTO funcionario(nome, codigoRegistro, dtCadastro)" +
                          "VALUES(@nome, @codigoRegistro, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", funcionario.Nome);
                command.Parameters.AddWithValue("@codigoRegistro", funcionario.CodigoRegistro);
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
        public List<Funcionario> Listar()
        {
            try
            {

                var sql = "SELECT * FROM funcionario";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Funcionario> listaFuncionario = new List<Funcionario>();

                while (dataReader.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.Id = Convert.ToInt32(dataReader["id"]);
                    funcionario.Nome = dataReader["nome"].ToString();
                    funcionario.CodigoRegistro = Convert.ToInt32(dataReader["codigoRegistro"]);

                    listaFuncionario.Add(funcionario);
                }

                return listaFuncionario;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }
        public List<Funcionario> pesquisarFuncionario(int codigoRegistro)
        {
            try
            { 
                var sql = "SELECT * FROM funcionario WHERE codigoRegistro LIKE '%" + codigoRegistro + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Funcionario> listaFuncionario = new List<Funcionario>();

                while (dataReader.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.Id = Convert.ToInt32(dataReader["id"]);
                    funcionario.Nome = dataReader["nome"].ToString();
                    funcionario.CodigoRegistro = Convert.ToInt32(dataReader["codigoRegistro"]);

                    listaFuncionario.Add(funcionario);
                }

                return listaFuncionario;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }
        public Funcionario FuncionarioID(int id)
        {
            try
            {


                var sql = "SELECT * FROM funcionario WHERE id = " + id;
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                Funcionario funcionario = new Funcionario();

                if (dataReader.Read())
                {
                    funcionario.Id = Convert.ToInt32(dataReader["id"]);
                    funcionario.Nome = dataReader["nome"].ToString();
                    funcionario.CodigoRegistro = Convert.ToInt32(dataReader["codigoRegistro"]);

                }
                return funcionario;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {

            }
        }
        /*public List<Funcionario> pesquisarFuncionario(int codigoRegistro)
        {
            try
            {


                var sql = "SELECT * FROM funcionario WHERE codigoRegistro = " + codigoRegistro;
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Funcionario> listaFuncionario = new List<Funcionario>();

                while (dataReader.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.Id = Convert.ToInt32(dataReader["id"]);
                    funcionario.Nome = dataReader["nome"].ToString();
                  

                    listaFuncionario.Add(funcionario);
                }

                return listaFuncionario;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro de insercao" + erro);
            }
        }*/

        public FuncionarioDal()
        {
            AbrirConexao();
        }
        ~FuncionarioDal()
        {
            FecharConexao();
        }
    }
}
