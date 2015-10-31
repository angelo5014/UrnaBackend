using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using DbExtensions;
using System.Collections.Generic;

namespace Aula4Ado
{
    public class CargoRepositorio : IRepositorio<Cargo>
    {
        public int Atualizar(Cargo t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            int linhasAfetadas = 0;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Cargo set nome=@paramNome,situacao=@paramSituacao where idCargo = @paramIdCargo";
                comando.AddParameter("paramNome", t.Nome);
                comando.AddParameter("paramSituacao", t.Situacao);
                comando.AddParameter("paramIdCargo", t.IdCargo);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public Cargo BuscarPorId(int id)
        {
            Cargo cargoEncontrado = null;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idCargo,nome,situacao FROM Cargo WHERE idCargo = @paramIdCargo";
                comando.AddParameter("paramIdCargo", id);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idDb = Convert.ToInt32(reader["IdCargo"]);
                    string nome = reader["Nome"].ToString();
                    char situacao = Convert.ToChar(reader["Situacao"]);

                    cargoEncontrado = new Cargo(idDb, nome)
                    {
                        Situacao = situacao
                    };
                }
                connection.Close();
            }

            return cargoEncontrado;
        }

        public IList<Cargo> BuscarPorNome(string nome)
        {
            IList<Cargo> cargosEncontrados = new List<Cargo>();

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idCargo,nome,situacao FROM Cargo WHERE idCargo = @paramNome";
                comando.AddParameter("paramNome", nome);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    int idDb = Convert.ToInt32(reader["IdCargo"]);
                    string nomeCargo = reader["Nome"].ToString();
                    char situacao = Convert.ToChar(reader["Situacao"]);

                    cargosEncontrados.Add(new Cargo(idDb, nomeCargo)
                    {
                        Situacao = situacao
                    });
                }
                connection.Close();
            }

            return cargosEncontrados;
        }

        public int DeletarPorId(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            int linhasAfetadas = 0;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "DELETE FROM Cargo where idCargo = @paramIdCargo";
                comando.AddParameter("paramIdCargo", id);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public void Inserir(Cargo t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "INSERT into Cargo(nome, situacao) values(@paramNome,@paramSituacao)";
                comando.AddParameter("paramNome", t.Nome);
                comando.AddParameter("paramSituacao", t.Situacao);
                connection.Open();
                comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
        }
    }
}