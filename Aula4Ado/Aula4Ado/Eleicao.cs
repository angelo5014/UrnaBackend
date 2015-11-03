namespace Aula4Ado
{
    public class Eleicao
    {
        public static bool EleicoesIniciadas { get; private set; } = false;

        VotoRepositorio votoRepositorio = new VotoRepositorio();
        EleitorRepositorio eleitorRepositorio = new EleitorRepositorio();

        public bool Votar(string cpf, int numeroCandidato)
        {
            Voto voto = new Voto(numeroCandidato);
            Eleitor eleitor = eleitorRepositorio.BuscarPorCpf(cpf);
            if (EleicoesIniciadas && eleitor != null && eleitor.Votou == 'N' && eleitor.Situacao == 'A')
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
