using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Basicos;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj
{
    public sealed class Ponto : ObjetoAbstratoComCodigo
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Ponto(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Ponto primeiroPonto, Ponto segundoPonto) =>
            primeiroPonto.Equals(segundoPonto);

        public static bool operator !=(Ponto primeiroPonto, Ponto segundoPonto) => 
            !primeiroPonto.Equals(segundoPonto);

        public override bool Equals(object obj)
        {
            if (obj is Ponto)
            {
                var ponto = (Ponto)obj;

                return ponto.X == X && ponto.Y == Y && ponto.Z == Z;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)X * 6553 + (int)Y * 7993 + (int)Z * 6553;
        }

        public Matrix<double> ConvertaParaMatriz()
        {
            var matriz = DenseMatrix.OfArray(new double[,] { { X, Y, Z } });

            return matriz;
        }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z};)";
        }
    }
}