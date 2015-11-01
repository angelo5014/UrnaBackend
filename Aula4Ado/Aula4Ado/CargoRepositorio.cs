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
            if (BuscarPorNome(t.Nome) != null)
            {
                return 0;
            }
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

        public Cargo BuscarPorNome(string nome)
        {
            Cargo cargoEncontrado = null;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idCargo,nome,situacao FROM Cargo WHERE nome = @paramNome";
                comando.AddParameter("paramNome", nome);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idDb = Convert.ToInt32(reader["IdCargo"]);
                    string nomeCargo = reader["Nome"].ToString();
                    char situacao = Convert.ToChar(reader["Situacao"]);

                    cargoEncontrado = new Cargo(idDb, nomeCargo)
                    {
                        Situacao = situacao
                    };
                }
                connection.Close();
            }

            return cargoEncontrado;
        }

        public int AtualizarSituacao(Cargo t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            int linhasAfetadas = 0;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Cargo set situacao=@paramSituacao where idCargo = @paramIdCargo";
                comando.AddParameter("paramSituacao", t.Situacao);
                comando.AddParameter("paramIdCargo", t.IdCargo);
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

            if (BuscarPorNome(t.Nome) == null)
            {
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
}