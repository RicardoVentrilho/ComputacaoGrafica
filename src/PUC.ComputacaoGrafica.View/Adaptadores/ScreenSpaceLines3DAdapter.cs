using System;
using _3DTools;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using System.Windows.Media;

namespace PUC.ComputacaoGrafica.View.Adaptadores
{
    public static class ScreenSpaceLines3DAdapter
    {
        public static ScreenSpaceLines3D Adapte(Aresta aresta)
        {
            var linha = new ScreenSpaceLines3D();

            var primeiroPonto = Point3dAdapter.Adapte(aresta.PrimeiroPonto);
            var ultimoPonto = Point3dAdapter.Adapte(aresta.UltimoPonto);

            linha.Points.Add(primeiroPonto);
            linha.Points.Add(ultimoPonto);

            linha.Color = Colors.Black;

            return linha;
        }
    }
}