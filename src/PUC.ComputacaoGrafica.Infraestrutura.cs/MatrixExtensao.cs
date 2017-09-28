using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using static PUC.ComputacaoGrafica.Infraestrutura.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Infraestrutura.cs
{
    public static class MatrixExtensao
    {
        public static Ponto ConvertaParaPonto(this Matrix<double> matriz)
        {
            double x = matriz[0, (int)X];
            double y = matriz[0, (int)Y];
            double z = matriz[0, (int)Z];

            var ponto = new Ponto(x, y, z);

            return ponto;
        }
    }
}
