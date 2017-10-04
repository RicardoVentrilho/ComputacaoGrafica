using System;
using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumPlano;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.ParalelaAxiometricaObj
{
    public static class FabricaDeAxiometricoIsometrico
    {
        public static Matrix<double> Crie(Ponto3d ponto, EnumPlano plano)
        {
            Matrix<double> matriz;

            switch (plano)
            {
                case XY:
                    matriz = FabricaDePlanarPespectivo.Crie(plano, ponto.Z);

                    var primeiraMultiplicacao = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { ponto.X, ponto.Y, 0, 1 }
                    });

                    var segundaMultiplicacaoXY = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { -1 * ponto.X, -1 * ponto.Y, 0, 1 }
                    });

                    matriz = matriz * primeiraMultiplicacao;

                    matriz = segundaMultiplicacaoXY * matriz;

                    break;

                case XZ:
                    matriz = FabricaDePlanarPespectivo.Crie(plano, ponto.Y);

                    var primeiraMultiplicacaoXZ = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { ponto.X, 0, ponto.Z, 1 }
                    });

                    var segundaMultiplicacaoXZ = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { -1 * ponto.X, 0, -1 * ponto.Z, 1 }
                    });

                    matriz = matriz * primeiraMultiplicacaoXZ;

                    matriz = segundaMultiplicacaoXZ * matriz;

                    break;

                case YZ:
                    matriz = FabricaDePlanarPespectivo.Crie(plano, ponto.X);

                    var primeiraMultiplicacaoYZ = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { 0, ponto.Y, ponto.Z, 1 }
                    });

                    var segundaMultiplicacaoYZ = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { 0, -1 * ponto.Y, -1 * ponto.Z, 1 }
                    });

                    matriz = matriz * primeiraMultiplicacaoYZ;

                    matriz = segundaMultiplicacaoYZ * matriz;

                    break;

                default:
                    throw new ArgumentException("EnumPlano plano : Não existe na FabricaDePlanarPerspectivo.");
            }

            return matriz;
        }
    }
}