using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Extensoes;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj
{
    public class Translacao : ITransformacao<Ponto3d>
    {
        private static readonly Translacao _Instancia = new Translacao(0, 0, 0);

        private Translacao(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            DeslocamentoX = deslocamentoX;
            DeslocamentoY = deslocamentoY;
            DeslocamentoZ = deslocamentoZ;
        }

        public double DeslocamentoX { get; private set; }

        public double DeslocamentoY { get; private set; }

        public double DeslocamentoZ { get; private set; }

        public Matrix<double> MatrizParaTranslacao { get; private set; }

        public static Translacao ObtenhaInstancia(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
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

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizVertical();

            var resultado = MatrizParaTranslacao * pontoComoMatriz;

            var ponto = resultado.ConvertaVerticalParaPonto();

            return ponto;
        }
    }
}