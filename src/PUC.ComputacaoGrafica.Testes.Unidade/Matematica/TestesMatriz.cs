using NUnit.Framework;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.MatrizObj;
using PUC.ComputacaoGrafica.Testes.Unidade;

namespace PUC.ComputacaoGrafica.Testes.Matematica
{
    /// <summary>
    /// Classe responsável pelos testes de matriz.
    /// </summary>
    [TestFixture]
    public sealed class TestesMatriz
    {
        private Matriz<int> _Matriz;
        private Matriz<int> _MatrizParaMultiplicacaoComTamanhoIgual;
        private Matriz<int> _MatrizParaMultiplicacaoComTotalDeLinhasEColunasIguais;
        private Matriz<int> _MatrizParaMultiplicacaoComTotalDeLinhaEColunaDiferente;

        [SetUp]
        public void Inicializa()
        {
            _Matriz = FabricaDeObjetos.CrieMatrizComum();

            _MatrizParaMultiplicacaoComTamanhoIgual = FabricaDeObjetos.CrieMatrizParaMultiplicacaoComTamanhoIgual();

            _MatrizParaMultiplicacaoComTotalDeLinhasEColunasIguais = FabricaDeObjetos.CrieMatrizParaMultiplicacaoComTotalDeLinhasEColunasIguais();

            _MatrizParaMultiplicacaoComTotalDeLinhaEColunaDiferente = FabricaDeObjetos.CrieMatrizParaMultiplicacaoComTotalDeLinhasEColunasDiferentes();
        }

        [Test]
        public void TestaCriacaoDeMatrizAssimetrica()
        {
            var matriz = new Matriz<int>(
                new []
                {
                    new [] { 1, 2 },
                    new [] { 1 }
                });
        }

        [Test]
        public void TestaMultiplicacaoComTamanhoIguais()
        {
            var resultado = _Matriz * _MatrizParaMultiplicacaoComTamanhoIgual;

            Assert.AreEqual(resultado, resultado);
        }

        [Test]
        public void TestaMultiplicacaoComTotalDeLinhaEColunaIgual()
        {
            var resultado = _Matriz * _MatrizParaMultiplicacaoComTotalDeLinhasEColunasIguais;

            Assert.AreEqual(resultado, resultado);
        }

        [TestCase]
        public void TestaMultiplicacaoComTotalDeLinhaEColunasDiferente()
        {
            var resultado = _Matriz * _MatrizParaMultiplicacaoComTotalDeLinhaEColunaDiferente;

            Assert.AreEqual(resultado, resultado);
        }
    }
}
