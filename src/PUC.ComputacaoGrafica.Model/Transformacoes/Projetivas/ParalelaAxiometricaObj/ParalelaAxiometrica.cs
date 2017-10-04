using System;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using MathNet.Numerics.LinearAlgebra;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumPlano;
using PUC.ComputacaoGrafica.Model.Extensoes;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.ParalelaAxiometricaObj
{
    public class ParalelaAxiometricaIsometrica : ITransformacao<Ponto3d>
    {
        private static readonly ParalelaAxiometricaIsometrica _Instancia = new ParalelaAxiometricaIsometrica(null, XY);

        private ParalelaAxiometricaIsometrica(Ponto3d ponto, EnumPlano plano)
        {
            Ponto = ponto;
            Plano = plano;
        }

        public Matrix<double> MatrizParaParalelaAxometrixaIsometrica { get; private set; }

        public EnumPlano Plano { get; private set; }

        public Ponto3d Ponto { get; private set; }

        public static ParalelaAxiometricaIsometrica ObtenhaInstancia(Ponto3d ponto, EnumPlano plano)
        {
            _Instancia.Ponto = ponto;
            _Instancia.Plano = plano;

            _Instancia.MatrizParaParalelaAxometrixaIsometrica = FabricaDeAxiometricoIsometrico.Crie(ponto, plano);

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
