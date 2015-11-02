using DbExtensions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Aula4Ado
{
    class VotoRepositorio : IRepositorio<Voto>
    {
        public int Atualizar(Voto t)
        {
            return 0;
        }

        public Voto BuscarPorId(int id)
        {
            Voto votoEncontrado;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idVoto, idCandidato FROM Voto WHERE idVoto = @paramIdVoto";
                comando.AddParameter("paramIdVoto", id);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                votoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return votoEncontrado;
        }

        public void Inserir(Voto t)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Voto voto, string cpf)
        {
            if (Validar(voto) && ValidarEleitor(cpf))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "INSERT into Voto(idVoto, idCandidato) values(@paramIdVoto,@paramIdCandidato)";
                    comando.AddParameter("paramIdVoto", voto.IdVoto);
                    comando.AddParameter("paramIdCandidato", voto.IdCandidato);
                    connection.Open();
                    comando.ExecuteNonQuery();

                    transacao.Complete();
                    connection.Close();
                }
            }
        }

        public Voto Parse(IDataReader reader)
        {
            int idDb = Convert.ToInt32(reader["IdVoto"]);
            int idCandidato = Convert.ToInt32(reader["IdCandidato"]);

            return new Voto(idCandidato)
            {
                IdVoto = idDb
            };
        }

        public bool Validar(Voto t)
        {
            return t != null && t.IdCandidato > 0 && t.IdVoto > 0;
        }

        public bool ValidarEleitor(string cpf)
        {
            return new EleitorRepositorio().PodeVotarPorCpf(cpf);
        }
    }
}
