using System;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumPlano;
using PUC.ComputacaoGrafica.Model.Extensoes;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj
{
    public class PlanarPerspectivo : ITransformacao<Ponto3d>
    {
        private static readonly PlanarPerspectivo _Instancia = new PlanarPerspectivo(0, XY);

        private PlanarPerspectivo(double dPonto, EnumPlano plano)
        {
            DPonto = dPonto;
            Plano = plano;
        }

        public Matrix<double> MatrizParaPlanarPerspectivo { get; private set; }

        public double DPonto { get; private set; }

        public EnumPlano Plano { get; private set; }

        public static PlanarPerspectivo ObtenhaInstancia(double dPonto, EnumPlano plano)
        {
            _Instancia.DPonto = dPonto;
            _Instancia.Plano = plano;

            _Instancia.MatrizParaPlanarPerspectivo = FabricaDePlanarPespectivo.Crie(plano, dPonto);

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizHorizontal();

            var resultado = pontoComoMatriz * MatrizParaPlanarPerspectivo ;

            var ponto = resultado.ConvertaHorizontalParaPonto();

            return ponto;
        }
    }
}
