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
    public class PartidoTests
    {
        [TestMethod()]
        public void PartidoTest()
        {
            Partido atual = new Partido("", "Slo", null);
            Assert.AreEqual("", atual.Nome);
            Assert.AreEqual("Slo", atual.Slogan);
            Assert.AreEqual(null, atual.Sigla);
            Assert.AreEqual(0, atual.IdPartido);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Partido partido = new Partido("Par", "Slo", null);
            string esperado = string.Format("{5,-10}{1}{0}{6,-10}{2}{0}{7,-10}{3}{0}{8,-10}{4}",
                Environment.NewLine, partido.IdPartido, partido.Nome, partido.Slogan, partido.Sigla, "IdCargo:", "Nome:", "Situação:", "Sigla:");

            Assert.AreEqual(esperado, partido.ToString());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Partido esperado = new Partido("Par", "Slo", null);
            Partido atual = new Partido("Par", "Slo", null);
            Assert.AreEqual(esperado, atual);
        }
    }
}