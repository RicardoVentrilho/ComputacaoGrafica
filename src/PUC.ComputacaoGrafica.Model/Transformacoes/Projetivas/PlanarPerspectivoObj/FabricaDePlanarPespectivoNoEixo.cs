using System;
using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumPlano;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj
{
    public class FabricaDePlanarPespectivoNoEixo
    {
        public static Matrix<double> Crie(EnumPlano plano, double dPonto)
        {
            Matrix<double> matriz;

            switch (plano)
            {
                case XY:
                    matriz = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 1, 0, 0 },
                        { 0, 0, 0, 1 / dPonto },
                        { 0, 0, 0, 1 }
                    });
                    break;

                case YZ:
                    matriz = DenseMatrix.OfArray(new double[,]
                    {
                        { 0, 0, 0, 1 / dPonto },
                        { 0, 1, 0, 0 },
                        { 0, 0, 1, 0 },
                        { 0, 0, 0, 1 }
                    });
                    break;

                case XZ:
                    matriz = DenseMatrix.OfArray(new double[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, 0, 0, 1 / dPonto },
                        { 0, 0, 1, 0 },
                        { 0, 0, 0, 1 }
                    });
                    break;

                default:
                    throw new ArgumentException("EnumPlano plano : Não existe na FabricaDePlanarPerspectivo.");
            }

            return matriz;
        }
    }
}