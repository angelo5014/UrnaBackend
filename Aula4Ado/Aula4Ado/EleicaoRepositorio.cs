using DbExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            return 0;
        }

        public Eleicao Parse(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
