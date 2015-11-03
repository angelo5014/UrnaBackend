using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DbExtensions;
using System.Transactions;

namespace Aula4Ado
{
    public class EleitorRepositorio : IRepositorio<Eleitor>
    {
        public int Atualizar(Eleitor t)
        {
            Eleitor validar = BuscarPorRGouCPF(t);
            if (Validar(validar) && validar.IdEleitor != t.IdEleitor)
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
                    "UPDATE Eleitor set nome=@paramNome, TituloEleitoral=@paramTituloEleitoral, RG=@paramRG, CPF=@paramCPF, DataNascimento=@paramDataNascimento, " +
                        "ZonaEleitoral=@paramZonaEleitoral, Secao=@paramSecao, Situacao=@paramSituacao, Votou=@paramVotou " +                     
                    "WHERE idEleitor = @paramIdEleitor";
                comando.AddParameter("paramNome", t.Nome);
                comando.AddParameter("paramTituloEleitoral", t.TituloEleitoral);
                comando.AddParameter("paramRG", t.RG);
                comando.AddParameter("paramCPF", t.CPF);
                comando.AddParameter("paramDataNascimento", t.DataNascimento);
                comando.AddParameter("paramZonaEleitoral", t.ZonaEleitoral);
                comando.AddParameter("paramSecao", t.Secao);
                comando.AddParameter("paramSituacao", t.Situacao);
                comando.AddParameter("paramVotou", t.Votou);
                comando.AddParameter("paramIdEleitor", t.IdEleitor);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public int InativarPorId(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            int linhasAfetadas = 0;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Eleitor SET Situacao = 'I' where idEleitor = @paramIdEleitor";
                comando.AddParameter("paramIdEleitor", id);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public Eleitor BuscarPorId(int id)
        {
            Eleitor eleitorEncontrado;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT IDEleitor, Nome, TituloEleitoral, RG, CPF, DataNascimento, ZonaEleitoral, Secao, Situacao, Votou " +
                    "FROM Eleitor WHERE idEleitor = @paramIdEleitor";
                comando.AddParameter("paramIdEleitor", id);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                eleitorEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return eleitorEncontrado;
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
                    "DELETE FROM Eleitor where idEleitor = @paramIdEleitor";
                comando.AddParameter("paramIdEleitor", id);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public int Inserir(Eleitor t)
        {
            int linhasAfetadas = 0;
            if (BuscarPorRGouCPF(t) == null && Validar(t))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;                

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "INSERT into Eleitor(nome, TituloEleitoral, RG, CPF, DataNascimento, ZonaEleitoral, Secao, Situacao, Votou) "+
                        "values(@paramNome,@paramTituloEleitoral,@paramRG,@paramCPF,@paramDataNascimento,@paramZonaEleitoral,@paramSecao,@paramSituacao,@paramVotou)";
                    comando.AddParameter("paramNome", t.Nome);
                    comando.AddParameter("paramTituloEleitoral", t.TituloEleitoral);
                    comando.AddParameter("paramRG", t.RG);
                    comando.AddParameter("paramCPF", t.CPF);
                    comando.AddParameter("paramDataNascimento", t.DataNascimento);
                    comando.AddParameter("paramZonaEleitoral", t.ZonaEleitoral);
                    comando.AddParameter("paramSecao", t.Secao);
                    comando.AddParameter("paramSituacao", t.Situacao);
                    comando.AddParameter("paramVotou", t.Votou);
                    connection.Open();
                    linhasAfetadas = comando.ExecuteNonQuery();

                    transacao.Complete();
                    connection.Close();
                }                
            }

            return linhasAfetadas;
        }

        public Eleitor Parse(IDataReader reader)
        {
            int idDb = Convert.ToInt32(reader["IDEleitor"]);
            string nome = reader["Nome"].ToString();
            string tituloEleitoral = reader["TituloEleitoral"].ToString();
            string rg = reader["RG"].ToString();
            string cpf = reader["CPF"].ToString();
            string zonaEleitoral = reader["ZonaEleitoral"].ToString();
            string secao = reader["Secao"].ToString();
            char situacao = char.Parse(reader["Situacao"].ToString());
            char votou = char.Parse(reader["Votou"].ToString());
            DateTime dataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());

            return new Eleitor(nome, tituloEleitoral, rg, cpf, dataNascimento, zonaEleitoral, secao, situacao, votou)
            {
                IdEleitor = idDb
            };
        }

        public bool PodeVotarPorCpf(string cpf)
        {
            Eleitor eleitor = BuscarPorCpf(cpf);
            return eleitor != null && eleitor.Votou == 'N' && eleitor.Situacao == 'A';
        }

        public bool Validar(Eleitor t)
        {
            return t != null && !String.IsNullOrEmpty(t.Nome) && !String.IsNullOrEmpty(t.TituloEleitoral) && !String.IsNullOrEmpty(t.RG)
                && !String.IsNullOrEmpty(t.CPF) && !String.IsNullOrEmpty(t.ZonaEleitoral) && !String.IsNullOrEmpty(t.Secao)
                && (t.Situacao.ToString().ToUpper() == "I" || t.Situacao.ToString().ToUpper() == "A") &&
                (t.Votou.ToString().ToUpper() == "S" || t.Votou.ToString().ToUpper() == "P" || t.Votou.ToString().ToUpper() == "N");
        }

        public Eleitor BuscarPorCpf(string cpf)
        {
            Eleitor eleitorEncontrado;            

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT IDEleitor, Nome, TituloEleitoral, RG, CPF, DataNascimento, ZonaEleitoral, Secao, Situacao, Votou " +
                    "FROM Eleitor WHERE CPF=@paramCPF";
                comando.AddParameter("paramCPF", cpf);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                eleitorEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return eleitorEncontrado;
        }

        public Eleitor BuscarPorRGouCPF(Eleitor eleitor)
        {
            Eleitor eleitorEncontrado;
            string cpf = eleitor.CPF;
            string rg = eleitor.RG;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT IDEleitor, Nome, TituloEleitoral, RG, CPF, DataNascimento, ZonaEleitoral, Secao, Situacao, Votou " +
                    "FROM Eleitor WHERE CPF=@paramCPF or RG=@paramRG";
                comando.AddParameter("paramCPF", cpf);
                comando.AddParameter("paramRG", rg);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                eleitorEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }

            return eleitorEncontrado;
        }

        public int ResetarSituacao()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            int linhasAfetadas = 0;

            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Eleitor set votou='N'";
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }
    }
}