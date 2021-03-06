﻿using DbExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Aula4Ado
{
    public class PartidoRepositorio : IRepositorio<Partido>
    {
        public int Atualizar(Partido t)
        {
            int linhasAfetadas = 0;

            if (!Eleicao.EleicoesIniciadas)
            {
                Partido validar = BuscarPorSiglaENome(t);
                if ((Validar(validar) && validar.IdPartido != t.IdPartido) || !Validar(t))
                {
                    return 0;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "UPDATE Partido set nome=@paramNome,slogan=@paramSlogan,sigla=@paramSigla where idPartido = @paramIdPartido";
                    comando.AddParameter("paramNome", t.Nome);
                    comando.AddParameter("paramSlogan", t.Slogan);
                    comando.AddParameter("paramSigla", t.Sigla);
                    comando.AddParameter("paramIdPartido", t.IdPartido);
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

        public Partido BuscarPorId(int id)
        {
            Partido partidoEncontrado;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idPartido,nome,slogan,sigla FROM Partido WHERE idPartido = @paramIdPartido";
                comando.AddParameter("paramIdPartido", id);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                partidoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return partidoEncontrado;
        }

        public Partido BuscarPorSiglaENome(Partido partido)
        {
            Partido partidoEncontrado;
            string nomePartido = partido.Nome;
            string siglaPartido = partido.Sigla;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT idPartido,nome,slogan,sigla FROM Partido WHERE nome=@paramNome and sigla=@paramSigla";
                comando.AddParameter("paramNome", nomePartido);
                comando.AddParameter("paramSigla", siglaPartido);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                partidoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return partidoEncontrado;
        }

        public int DeletarPorId(int id)
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
                        "DELETE FROM Partido where idPartido = @paramIdPartido";
                    comando.AddParameter("paramIdPartido", id);
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

        public int Inserir(Partido t)
        {
            int linhasAfetadas = 0;

            if (!Eleicao.EleicoesIniciadas)
            {
                if (BuscarPorSiglaENome(t) == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                    using (TransactionScope transacao = new TransactionScope())
                    using (IDbConnection connection = new SqlConnection(connectionString))
                    {
                        IDbCommand comando = connection.CreateCommand();
                        comando.CommandText =
                            "INSERT into Partido(nome, slogan, sigla) values(@paramNome,@paramSlogan,@paramSigla)";
                        comando.AddParameter("paramNome", t.Nome);
                        comando.AddParameter("paramSlogan", t.Slogan);
                        comando.AddParameter("paramSigla", t.Sigla);
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

        public Partido Parse(IDataReader reader)
        {
            int idDb = Convert.ToInt32(reader["IdPartido"]);
            string nome = reader["Nome"].ToString();
            string slogan = reader["Slogan"].ToString();
            string sigla = reader["Sigla"].ToString();

            return new Partido(nome, slogan, sigla)
            {
                IdPartido = idDb
            };
        }

        public bool Validar(Partido t)
        {
            return t != null && !String.IsNullOrEmpty(t.Nome) && !String.IsNullOrEmpty(t.Slogan) && !String.IsNullOrEmpty(t.Sigla);
        }
    }
}