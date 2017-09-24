using PUC.ComputacaoGrafica.Infraestrutura.Matematica.MatrizObj;

namespace PUC.ComputacaoGrafica.Testes.Unidade
{
    public static class FabricaDeObjetos
    {
        public static Matriz<int> CrieMatrizComum()
        {
            return new Matriz<int>(
                new[]
                {
                    new [] { 2, 2 },
                    new [] { 2, 2 }
                });
        }

        public static Matriz<int> CrieMatrizParaMultiplicacaoComTamanhoIgual()
        {
            return new Matriz<int>(
                new[]
                {
                    new [] { 2, 2 },
                    new [] { 2, 2 }
                });
        }

        public static Matriz<int> CrieMatrizParaMultiplicacaoComTotalDeLinhasEColunasIguais()
        {
            return new Matriz<int>(
                new[]
                {
                    new [] { 2, 2 },
                    new [] { 2, 2 }
                });
        }

        public static Matriz<int> CrieMatrizParaMultiplicacaoComTotalDeLinhasEColunasDiferentes()
        {
            return new Matriz<int>(
                new[]
                {
                    new [] { 2, 2 },
                    new [] { 2, 2 }
                });
        }
    }
}
