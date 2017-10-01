using _3DTools;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using System.Windows.Media;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using System.Collections.Generic;

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
            linha.Thickness = 2;

            return linha;
        }

        public static IList<ScreenSpaceLines3D> Adapte(Poliedro poliedro)
        {
            var arestas = poliedro.Arestas;
            var linhas = new List<ScreenSpaceLines3D>();

            foreach (var aresta in arestas)
            {
                var linha = Adapte(aresta);

                linhas.Add(linha);
            }

            return linhas;
        }
    }
}