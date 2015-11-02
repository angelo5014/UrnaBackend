using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    class EleicaoRepositorio : IRepositorio<Eleicao>
    {
        public int Atualizar(Eleicao t)
        {
            throw new NotImplementedException();
        }

        public Eleicao BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Eleicao t)
        {
            int linhasAfetadas = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

            if ()
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

        public Eleicao Parse(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
