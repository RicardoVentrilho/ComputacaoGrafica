using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Basicos;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj
{
    public sealed class Ponto3d : ObjetoAbstratoComCodigo
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Ponto3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Ponto3d primeiroPonto, Ponto3d segundoPonto) =>
            primeiroPonto.Equals(segundoPonto);

        public static bool operator !=(Ponto3d primeiroPonto, Ponto3d segundoPonto) => 
            !primeiroPonto.Equals(segundoPonto);

        public override bool Equals(object obj)
        {
            if (obj is Ponto3d)
            {
                var ponto = (Ponto3d)obj;

                return ponto.X == X && ponto.Y == Y && ponto.Z == Z;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)X * 6553 + (int)Y * 7993 + (int)Z * 6553;
        }

        public Matrix<double> ConvertaParaMatrizVertical()
        {
            var matriz = DenseMatrix.OfArray(new double[,] 
            {
                { X },
                { Y },
                { Z },
                { 1 }
            });

            return matriz;
        }

        public Matrix<double> ConvertaParaMatrizHorizontal()
        {
            var matriz = DenseMatrix.OfArray(new double[,] { { X, Y, Z, 1 } });

            return matriz;
        }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z};)";
        }
    }
}