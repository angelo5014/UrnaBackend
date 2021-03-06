﻿using DbExtensions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Aula4Ado
{
    public class VotoRepositorio : IRepositorio<Voto>
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

        public int Inserir(Voto voto)
        {
            if (Validar(voto))
            {
                int idCandidato = new CandidatoRepositorio().BuscarPorNumero(voto.Numero).IdCandidato;

                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "INSERT into Voto(idCandidato) values(@paramIdCandidato)";
                    comando.AddParameter("paramIdCandidato", idCandidato);
                    connection.Open();
                    comando.ExecuteNonQuery();

                    transacao.Complete();
                    connection.Close();
                }
                return 1;
            }
            return 0;
        }

        public Voto Parse(IDataReader reader)
        {
            int idDb = Convert.ToInt32(reader["IdVoto"]);
            int idCandidato = Convert.ToInt32(reader["IdCandidato"]);

            return new Voto(new CandidatoRepositorio().BuscarPorId(idCandidato).Numero)
            {
                IdVoto = idDb
            };
        }

        public bool Validar(Voto t)
        {
            return t != null;
        }

        public int DeletarVotos()
        {
            int linhasAfetadas = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "DELETE FROM Voto";
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }
    }
}
