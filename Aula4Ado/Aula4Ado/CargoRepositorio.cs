using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using DbExtensions;

namespace Aula4Ado
{
    public class CargoRepositorio : IRepositorio<Cargo>
    {
        public int Atualizar(Cargo t)
        {
            int linhasAfetadas = 0;

            if (!Eleicao.EleicoesIniciadas)
            {
                Cargo cargo = BuscarPorNome(t.Nome);
                if ((BuscarPorNome(t.Nome) != null && t.IdCargo != cargo.IdCargo) || !Validar(t))
                {
                    return 0;
                }
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

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
            else
            {
                return linhasAfetadas;
            }
        }

        public Cargo BuscarPorId(int id)
        {
            Cargo cargoEncontrado;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idCargo,nome,situacao FROM Cargo WHERE idCargo = @paramIdCargo";
                comando.AddParameter("paramIdCargo", id);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                cargoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return cargoEncontrado;
        }

        public Cargo BuscarPorNome(string nome)
        {
            Cargo cargoEncontrado;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idCargo,nome,situacao FROM Cargo WHERE nome = @paramNome";
                comando.AddParameter("paramNome", nome);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                cargoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return cargoEncontrado;
        }

        public int AtualizarSituacao(Cargo t)
        {
            int linhasAfetadas = 0;

            if (!Eleicao.EleicoesIniciadas)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

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
            else
            {
                return linhasAfetadas;
            }
        }

        public int Inserir(Cargo t)
        {
            int linhasAfetadas = 0;

            if (!Eleicao.EleicoesIniciadas)
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
                        linhasAfetadas = comando.ExecuteNonQuery();

                        transacao.Complete();
                        connection.Close();
                    }
                }
                return linhasAfetadas;
            }
            else
            {
                return linhasAfetadas;
            }
        }

        public Cargo Parse(IDataReader reader)
        {
            int idDb = Convert.ToInt32(reader["IdCargo"]);
            string nomeCargo = reader["Nome"].ToString();
            char situacao = Convert.ToChar(reader["Situacao"]);

            return new Cargo(nomeCargo, situacao)
            {
                IdCargo = idDb
            };
        }

        public bool Validar(Cargo t)
        {
            return t != null && t.Nome != null && t.IdCargo > 0 && t.Situacao != '\0';
        }
    }
}