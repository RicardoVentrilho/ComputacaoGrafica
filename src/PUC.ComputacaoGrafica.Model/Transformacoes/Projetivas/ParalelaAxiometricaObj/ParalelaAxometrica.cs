using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Model.Extensoes;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.ParalelaAxiometricaObj
{
    public class ParalelaAxometrica : ITransformacao<Ponto3d>
    {
        private static readonly ParalelaAxometrica _Instancia = new ParalelaAxometrica();

        private ParalelaAxometrica()
        {
        }

        public Matrix<double> MatrizParaParalelaAxometrixaIsometrica { get; private set; }

        public static ParalelaAxometrica ObtenhaInstancia()
        {
            _Instancia.MatrizParaParalelaAxometrixaIsometrica = DenseMatrix.OfArray(new[,]
            {
                { 0.707, 0.408, 0, 0},
                { 0, 0.816, 0, 0},
                { 0.707, -0.408, 0, 0 },
                { 0, 0, 0, 1 }
            });

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizHorizontal();

            var resultado = pontoComoMatriz * MatrizParaParalelaAxometrixaIsometrica;

            var ponto = resultado.ConvertaHorizontalParaPonto();

            return ponto;
        }
    }
}
