using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aula4Ado.Tests
{
    [TestClass()]
    public class CargoRepositorioTests
    {
        [TestMethod()]
        public void AtualizarTest()
        {
            CargoRepositorio repositorio = new CargoRepositorio();
            Cargo cargo = repositorio.BuscarPorId(1);
            char situacao = cargo.Situacao;
            cargo.Situacao = 'I';
            int atual = repositorio.Atualizar(cargo);

            Assert.AreEqual(1, atual);

            cargo.Situacao = situacao;
            atual = repositorio.Atualizar(cargo);

            Assert.AreEqual(1, atual);

        }

        [TestMethod()]
        public void BuscarPorIdTest()
        {
            Cargo atual = new CargoRepositorio().BuscarPorId(1);
            Assert.AreEqual("Prefeito", atual.Nome);
        }

        [TestMethod()]
        public void BuscarPorNomeTest()
        {
            Cargo atual = new CargoRepositorio().BuscarPorNome("Prefeito");
            Assert.AreEqual("Prefeito", atual.Nome);
        }

        [TestMethod()]
        public void AtualizarSituacaoTest()
        {
            CargoRepositorio repositorio = new CargoRepositorio();
            Cargo cargo = repositorio.BuscarPorId(1);
            char situacao = cargo.Situacao;
            cargo.Situacao = 'I';
            int atual = repositorio.AtualizarSituacao(cargo);

            Assert.AreEqual(1, atual);

            cargo.Situacao = situacao;
            repositorio.AtualizarSituacao(cargo);
        }

        [TestMethod()]
        public void ValidarTest()
        {
            CargoRepositorio repositorio = new CargoRepositorio();
            Cargo cargo = new Cargo("Cargo", 'A');
            Assert.IsFalse(repositorio.Validar(cargo));
            cargo.IdCargo = 1;
            Assert.IsTrue(repositorio.Validar(cargo));
        }
    }
}