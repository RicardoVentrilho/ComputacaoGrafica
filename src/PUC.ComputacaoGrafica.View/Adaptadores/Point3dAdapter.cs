using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Windows.Media.Media3D;

namespace PUC.ComputacaoGrafica.View.Adaptadores
{
    public static class Point3dAdapter
    {
        public static Point3D Adapte(Ponto ponto)
        {
            var x = ponto.X;
            var y = ponto.Y;
            var z = ponto.Z;

            var ponto3d = new Point3D(x, y, z);

            return ponto3d;
        }
    }
}