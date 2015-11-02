using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado
{
    public class Eleicao
    {
        public static bool EleicoesIniciadas { get; set; } = false;

        CandidatoRepositorio candidatoRepositorio = new CandidatoRepositorio();
        VotoRepositorio votoRepositorio = new VotoRepositorio();
        CargoRepositorio cargoRepositorio = new CargoRepositorio();
        PartidoRepositorio partidoRepositorio = new PartidoRepositorio();
        EleicaoRepositorio eleicaoRepositorio = new EleicaoRepositorio();
        EleitorRepositorio eleitorRepositorio = new EleitorRepositorio();
        EstatisticaRepositorio estatisticaRepositorio = new EstatisticaRepositorio();

        public Eleicao()
        {
        }

        public bool Votar(string cpf, Voto voto)
        {
            Eleitor eleitor = eleitorRepositorio.BuscarPorCpf(cpf);
            if (eleitor != null && eleitor.Votou == 'N' && eleitor.Situacao == 'A')
            {
                votoRepositorio.Inserir(voto);
                eleitor.Votou = 'S';
                eleitorRepositorio.Atualizar(eleitor);
                return true;
            }
            return false;
        }

        public void IniciarEleicoes()
        {
            EleicoesIniciadas = true;
        }

        public void FinalizarEleicoes()
        {
            EleicoesIniciadas = false;
        }
    }
}
