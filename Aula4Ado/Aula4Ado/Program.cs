using System;
using System.Collections.Generic;

namespace Aula4Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { -1, 0, -1, 0, 20, 20102, 20103, 30, 30200, 30300 };
            int votosContabilizados = 0;
            Random random = new Random();
            EleitorRepositorio eleitorRepositorio = new EleitorRepositorio();
            Eleicao eleicao = new Eleicao();

            eleicao.IniciarEleicoes();
            Console.WriteLine("Eleições iniciadas");

            for (int i = 4001; i < 4200; i++)
            {
                int numero = (int)(random.NextDouble() * 10);
                Eleitor eleitor = eleitorRepositorio.BuscarPorId(i);
                if (eleicao.Votar(eleitor.CPF, numeros[numero]))
                {
                    Console.WriteLine(eleitor.Nome + " votou");
                    votosContabilizados++;
                }
            }

            eleicao.FinalizarEleicoes();
            Console.WriteLine("Eleições finalizadas");


            Console.WriteLine("\nBuscando estatísticas\n");
            IList<Estatistica> estatisticas = new EstatisticaRepositorio().BuscarEstatisticas();
            foreach (Estatistica estatistica in estatisticas)
            {
                Console.WriteLine(estatistica.ToString() + "\n");
            }

            Console.WriteLine("\nPronto. {0} votos contabilizados", votosContabilizados);

            Console.WriteLine(Estatistica.PorcentagemEquivalente(estatisticas));

            Console.Read();
        }
    }
}
