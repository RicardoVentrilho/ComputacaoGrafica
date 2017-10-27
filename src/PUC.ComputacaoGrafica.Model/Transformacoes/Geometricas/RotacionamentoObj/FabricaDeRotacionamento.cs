using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.RotacionamentoObj
{
    public class FabricaDeRotacionamento
    {
        public static Matrix<double> Crie(EnumCoordenadas eixo, double angulo)
        {
            Matrix<double> matriz;

            switch (eixo)
            {
                case Z:
                    matriz = DenseMatrix.OfArray(new[,]
                    {
                        { Math.Cos(angulo), -1 * Math.Sin(angulo), 0, 0 },
                        { Math.Sin(angulo), Math.Cos(angulo), 0, 0 },
                        { 0, 0, 1, 0 },
                        { 0, 0, 0, 1 },
                    });
                    break;
                case X:
                    matriz = DenseMatrix.OfArray(new[,]
                    {
                        { 1, 0, 0, 0 },
                        { 0, Math.Cos(angulo), -1 * Math.Sin(angulo), 0},
                        { 0, Math.Sin(angulo), Math.Cos(angulo), 0},
                        { 0, 0, 0, 1 },
                    });

                    break;
                case Y:
                    matriz = DenseMatrix.OfArray(new[,]
                    {
                        { Math.Cos(angulo), 0, Math.Sin(angulo), 0 },
                        { 0, 1, 0, 0 },
                        { -1 * Math.Sin(angulo), 0, Math.Cos(angulo), 0 },
                        { 0, 0, 0, 1 },
                    });
                    break;
                default:
                    throw new ArgumentException("EnumCoordenada eixo : Não existe na FabricaDeRotacionamento.");
            }

            return matriz;
        }
    }
}