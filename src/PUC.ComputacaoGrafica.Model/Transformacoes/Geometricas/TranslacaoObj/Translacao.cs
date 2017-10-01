using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Extensoes;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj
{
    public class Translacao : ITransformacao<Ponto>
    {
        private static readonly Translacao _Instancia = new Translacao(0, 0, 0);

        private Translacao(int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            DeslocamentoX = deslocamentoX;
            DeslocamentoY = deslocamentoY;
            DeslocamentoZ = deslocamentoZ;
        }

        public int DeslocamentoX { get; private set; }

        public int DeslocamentoY { get; private set; }

        public int DeslocamentoZ { get; private set; }

        public Matrix<double> MatrizParaTranslacao { get; private set; }

        public static Translacao ObtenhaInstancia(int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            _Instancia.DeslocamentoX = deslocamentoX;
            _Instancia.DeslocamentoY = deslocamentoY;
            _Instancia.DeslocamentoZ = deslocamentoZ;

            _Instancia.MatrizParaTranslacao = DenseMatrix.OfArray(new double[,] 
            {
                { 1, 0, 0, deslocamentoX },
                { 0, 1, 0, deslocamentoY },
                { 0, 0, 1, deslocamentoZ },
                { 0, 0, 0, 1 }
            });

            return _Instancia;
        }

        public Ponto Calcule(Ponto elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatriz();

            var resultado = MatrizParaTranslacao * pontoComoMatriz;

            var ponto = resultado.ConvertaParaPonto();

            return ponto;
        }
    }
}