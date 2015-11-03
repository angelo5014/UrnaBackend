using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class EstatisticaRepositorioTests
    {
        [TestMethod()]
        public void BuscarEstatisticasTest()
        {
            IList<Estatistica> esperado = new List<Estatistica>();
            esperado.Add(new Estatistica("Voto Nulo", "Prefeito", "TRE", 13));
            esperado.Add(new Estatistica("Voto em Branco", "Prefeito", "TRE", 7));
            IList<Estatistica> atual = new EstatisticaRepositorio().BuscarEstatisticas();

            Assert.AreEqual(esperado[0], atual[0]);
            Assert.AreEqual(esperado[1], atual[1]);
        }
    }
}