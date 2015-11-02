using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbExtensions;
using System.Transactions;

namespace Aula4Ado
{
    public class CandidatoRepositorio : IRepositorio<Candidato>
    {
        public int Atualizar(Candidato t)
        {
            if (!ValidarCandidato(t) || BuscarPorId(t.IdCandidato) == null)
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
                    "UPDATE Candidato set idCandidato=@paramId, nomeCompleto=@paramNomeCompleto," 
                    + " nomePopular=@paramNomePop,dataNascimento=@paramDataNasc, registroTRE=@paramRegistroTRE,"
                    + " idPartido=@paramIdPartido, foto=@paramFoto, numero=@paramNumero, idCargo=@paramIdCargo," 
                    + " exibe=@paramExibe where idCandidato = @paramIdCandidato";
                comando.AddParameter("paramNomeCompleto", t.NomeCompleto);
                comando.AddParameter("paramNomePop", t.NomePopular);
                comando.AddParameter("paramDataNasc", t.DataNascimento);
                comando.AddParameter("paramRegistroTRE", t.RegistroTRE);
                comando.AddParameter("paramIDPartido",t);
                comando.AddParameter("paramFoto", t.Foto);
                comando.AddParameter("paramNumero", t.Numero);
                comando.AddParameter("paramIdCargo", t.IdCargo);
                comando.AddParameter("paramExibe", t.Exibe ? 1 : 0);
                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public int Inserir(Candidato t)
        {
            int linhasAfetadas = 0;
            if (ValidarCandidato(t))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transation = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "INSERT INTO Candidato (nomeCompleto, nomePopular, dataNascimento, registroTRE, idPartido, foto, numero, idCargo, exibe)"
                        +"VALUES (@paramNomeCompleto, @paramNomePop, @paramDataNasc, @paramRegistroTRE, @paramIDPartido, @paramFoto, @paramNumero, @paramIdCargo, @paramExibe)";
                    comando.AddParameter("paramNomeCompleto", t.NomeCompleto);
                    comando.AddParameter("paramNomePop", t.NomePopular);
                    comando.AddParameter("paramDataNasc", t.DataNascimento.ToString("yyyy-MM-dd"));
                    comando.AddParameter("paramRegistroTRE", t.RegistroTRE);
                    comando.AddParameter("paramIDPartido", t.IdPartido);
                    comando.AddParameter("paramFoto", t.Foto);
                    comando.AddParameter("paramNumero", t.Numero);
                    comando.AddParameter("paramIdCargo", t.IdCargo);
                    comando.AddParameter("paramExibe", t.Exibe ? 1 : 0);

                    connection.Open();
                    linhasAfetadas = comando.ExecuteNonQuery();

                    transation.Complete();
                    connection.Close();

                }
            }
            return linhasAfetadas;
        }

        public int DeletarPorID(int id)
        {
            if(id == 1 || id == 2 || id == 3 || id == 4)
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
                    "DELETE FROM Candidato WHERE idCandidato = @paramIdCandidato";
                comando.AddParameter("paramIdCandidato", id);

                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public int DeletarPorNomeCompleto(string nomeCompleto)
        {
            if (nomeCompleto == "Voto Nulo" || nomeCompleto == "Voto em Branco")
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
                    "DELETE FROM Candidato WHERE NomeCompleto = @paramNomeCompleto";
                comando.AddParameter("paramNomeCompleto", nomeCompleto);

                connection.Open();
                linhasAfetadas = comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
            return linhasAfetadas;
        }

        public Candidato BuscarPorId(int id)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, nomeCompleto, "
                    + "nomePopular,dataNascimento, registroTRE, idPartido, foto, "
                    + "numero, idCargo, exibe "
                    + "FROM Candidato WHERE IDCandidato = @paramID";
                comando.AddParameter("paramID", id);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }

        public Candidato BuscarPorNomeCompleto(string nomeCompleto)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, nomeCompleto, "
                    + "nomePopular,dataNascimento, registroTRE, idPartido, foto, "
                    + "numero, idCargo, exibe "
                    + "FROM Candidato WHERE NomeCompleto = @paramNome";
                comando.AddParameter("paramNome", nomeCompleto);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }

        public Candidato BuscarPorNumero(int numero)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, nomeCompleto, "
                    + "nomePopular,dataNascimento, registroTRE, idPartido, foto, "
                    + "numero, idCargo, exibe "
                    + "FROM Candidato WHERE Numero = @paramNumero";
                comando.AddParameter("paramNumero", numero);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }

        public Candidato BuscarPorNomePopular(string nomePopular)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, nomeCompleto, "
                    + "nomePopular,dataNascimento, registroTRE, idPartido, foto, "
                    + "numero, idCargo, exibe "
                    + "FROM Candidato WHERE NomePopular = @paramNome";
                comando.AddParameter("paramNome", nomePopular);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }

        public Candidato BuscarPorRegistroTRE(string registro)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, nomeCompleto, "
                    + "nomePopular,dataNascimento, registroTRE, idPartido, foto, "
                    + "numero, idCargo, exibe "
                    + "FROM Candidato WHERE registroTRE = @paramRegistro";
                comando.AddParameter("paramRegistro", registro);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }
        public Candidato verificarCargoPartido(Candidato candidato)
        {
            Candidato candidatoEncontrado;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT idCandidato, NomeCompleto, NomePopular, DataNascimento, RegistroTRE, c.idPartido, Foto, Numero, c.idCargo, Exibe "
                    + "FROM Candidato c "
                    + "INNER JOIN Cargo ca ON c.IdCargo = ca.IdCargo "
                    + "INNER JOIN Partido p ON p.IDpartido = c.IdPartido "
                    + "WHERE ca.Nome = 'prefeito' and p.idPartido = @paramPartido";

                comando.AddParameter("paramPartido", candidato.IdPartido);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                candidatoEncontrado = reader.Read() ? Parse(reader) : null;

                connection.Close();
            }
            return candidatoEncontrado;
        }

        public bool ValidarCandidato(Candidato t)
        {
            bool nomeCompletoValido = !String.IsNullOrWhiteSpace(t.NomeCompleto) ? true : false;
            bool nomePopularValido = BuscarPorNomePopular(t.NomePopular) == null && !String.IsNullOrWhiteSpace(t.NomePopular) ? true : false;
            bool registroTREValido = BuscarPorRegistroTRE(t.RegistroTRE) == null ? true : false;
            bool numeroValido = BuscarPorNumero(t.Numero) == null ? true : false;
            bool cargoValido = t.IdCargo == 1 ? (verificarCargoPartido(t) == null ? true : false) : true;
            return nomeCompletoValido && nomePopularValido && registroTREValido && numeroValido && cargoValido ? true : false;
        }



        public Candidato Parse(IDataReader reader)
        {
            int idCandidato = Convert.ToInt32(reader["IdCandidato"]);
            string nomeCompleto = reader["NomeCompleto"].ToString();
            string nomePopular = reader["NomePopular"].ToString();
            DateTime dataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
            string registroTRE = reader["RegistroTRE"].ToString();
            int idPartido = Convert.ToInt32(reader["idPartido"]);
            string foto = reader["Foto"].ToString();
            int numero = Convert.ToInt32(reader["Numero"]);
            int idCargo = Convert.ToInt32(reader["IDCargo"]);
            bool exibe = Convert.ToBoolean(Convert.ToInt32(reader["Exibe"]));

            return new Candidato(nomeCompleto, nomePopular, dataNascimento, registroTRE, idPartido, foto, numero, idCargo, exibe) { IdCandidato = idCandidato };
        }

    }
}
