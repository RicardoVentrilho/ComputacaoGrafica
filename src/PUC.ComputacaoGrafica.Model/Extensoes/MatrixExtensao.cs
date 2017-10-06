// -----------------------------------------------------------------------
// <copyright file="MatrixExtensao.cs" company="PUC GO">
// DIREITOS RESERVADOS - PUC GOIÁS.
// </copyright>
// -----------------------------------------------------------------------

using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Model.Extensoes
{
    public static class MatrixExtensao
    {
        public static Ponto3d ConvertaHorizontalParaPonto(this Matrix<double> matriz)
        {
            double x = matriz[0, (int)X];
            double y = matriz[0, (int)Y];
            double z = matriz[0, (int)Z];

            var ponto = new Ponto3d(x, y, z);

            return ponto;
        }

        public static Ponto3d ConvertaVerticalParaPonto(this Matrix<double> matriz)
        {
            double x = matriz[(int)X, 0];
            double y = matriz[(int)Y, 0];
            double z = matriz[(int)Z, 0];

            var ponto = new Ponto3d(x, y, z);

            return ponto;
        }
    }
}
