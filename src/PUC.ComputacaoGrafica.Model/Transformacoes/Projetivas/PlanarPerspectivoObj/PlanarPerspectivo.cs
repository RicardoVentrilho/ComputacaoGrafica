using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Model.Extensoes;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumPlano;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj
{
    public class PlanarPerspectivo : ITransformacao<Ponto3d>
    {
        private static readonly PlanarPerspectivo _Instancia = new PlanarPerspectivo(null, XY);

        private PlanarPerspectivo(Ponto3d ponto, EnumPlano plano)
        {
            Ponto = ponto;
            Plano = plano;
        }

        public Matrix<double> MatrizParaParalelaAxometrixaIsometrica { get; private set; }

        public EnumPlano Plano { get; private set; }

        public Ponto3d Ponto { get; private set; }

        public static PlanarPerspectivo ObtenhaInstancia(Ponto3d ponto, EnumPlano plano)
        {
            _Instancia.Ponto = ponto;
            _Instancia.Plano = plano;

            _Instancia.MatrizParaParalelaAxometrixaIsometrica = FabricaDePlanarPerspectivo.Crie(ponto, plano);

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
