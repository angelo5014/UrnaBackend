using System;
using System.Data;

namespace Aula4Ado
{
    public class EleitorRepositorio : IRepositorio<Eleitor>
    {
        public int Atualizar(Eleitor t)
        {
            throw new NotImplementedException();
        }

        public Eleitor BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Eleitor t)
        {
            throw new NotImplementedException();
        }

        public Eleitor Parse(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public bool PodeVotarPorCpf(string cpf)
        {
            Eleitor eleitor = BuscarPorCpf(cpf);
            return eleitor != null && eleitor.Votou == 'N';
        }

        public bool Validar(Eleitor t)
        {
            throw new NotImplementedException();
        }

        private Eleitor BuscarPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}