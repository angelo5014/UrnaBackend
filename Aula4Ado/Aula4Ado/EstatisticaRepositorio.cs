using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Aula4Ado
{
    public class EstatisticaRepositorio
    {
        public IList<Estatistica> BuscarEstatisticas()
        {
            List<Estatistica> estatisticas = new List<Estatistica>();

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT c.NomePopular[Nome],cg.Nome[Cargo] ,p.Sigla[Partido], count(1)[Votos] FROM Voto v INNER JOIN Candidato c ON v.IDCandidato = c.IDCandidato INNER JOIN Cargo cg ON c.IDCargo = cg.IDCargo INNER JOIN Partido p ON c.IDPartido = p.IDPartido GROUP BY v.IDCandidato, c.NomePopular, cg.Nome, p.Sigla ORDER BY Votos DESC";
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    estatisticas.Add(Parse(reader));
                }

                connection.Close();
            }

            return estatisticas;
        }

        private Estatistica Parse(IDataReader reader)
        {
            return new Estatistica(reader["Nome"].ToString(), reader["Cargo"].ToString(),
                reader["Partido"].ToString(), Convert.ToInt32(reader["Votos"]));
        }
    }
}
