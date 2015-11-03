using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula4Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class EstatisticaTests
    {
        [TestMethod()]
        public void EstatisticaTest()
        {
            Estatistica estatistica = new Estatistica("Candidato", "Cargo", "Partido", 70);
            Assert.AreEqual("Candidato", estatistica.Nome);
            Assert.AreEqual("Cargo", estatistica.Cargo);
            Assert.AreEqual("Partido", estatistica.Partido);
            Assert.AreEqual(70, estatistica.Votos);
        }
    }
}