using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Aula4Ado.Tests
{
    [TestClass]
    public class CargoTests
    {
        [TestMethod]
        public void CargoTest()
        {
            Cargo cargo = new Cargo("Cargo", 'A');
            Assert.AreEqual("Cargo", cargo.Nome);
            Assert.AreEqual(0, cargo.IdCargo);
            Assert.AreEqual('A', cargo.Situacao);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string esperado = string.Format("{4,-10}{1}{0}{5,-10}{2}{0}{6,-10}{3}",
                Environment.NewLine, 96, "teste", 'A', "IdCargo:", "Nome:", "Situação:");
            Cargo atual = new Cargo("teste", 'A')
            {
                IdCargo = 96
            };
            Assert.AreEqual(esperado, atual.ToString());
        }

        [TestMethod]
        public void EqualsTest()
        {
            Cargo cargo1 = new Cargo("96", 'I');
            Cargo cargo2 = new Cargo("96", 'I');
            Assert.AreEqual(cargo1, cargo2);
        }
    }
}