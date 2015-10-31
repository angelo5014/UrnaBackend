using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DbExtensions;

namespace Aula4Ado
{
    public class CargoRepositorio : IRepositorio<Cargo>
    {
        public void Atualizar(Cargo t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Cargo set nome=@paramNome,situacao=@paramSituacao where idCargo = @paramIdCargo";
                comando.AddParameter("paramNome", t.Nome);
                comando.AddParameter("paramSituacao", t.Situacao);
                comando.AddParameter("paramIdCargo", t.IdCargo);
                connection.Open();
                comando.ExecuteNonQuery();

                connection.Close();
            }
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
    }
}