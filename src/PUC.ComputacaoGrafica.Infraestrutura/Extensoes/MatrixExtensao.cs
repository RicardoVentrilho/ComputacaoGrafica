using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using static PUC.ComputacaoGrafica.Infraestrutura.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Infraestrutura.Extensoes
{
    public static class MatrixExtensao
    {
        public static Ponto ConvertaHorizontalParaPonto(this Matrix<double> matriz)
        {
            double x = matriz[0, (int)X];
            double y = matriz[0, (int)Y];
            double z = matriz[0, (int)Z];

            var ponto = new Ponto(x, y, z);

            return ponto;
        }

        public static Ponto ConvertaVerticalParaPonto(this Matrix<double> matriz)
        {
            double x = matriz[(int)X, 0];
            double y = matriz[(int)Y, 0];
            double z = matriz[(int)Z, 0];

            var ponto = new Ponto(x, y, z);

            return ponto;
        }
    }
}
