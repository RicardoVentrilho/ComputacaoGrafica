using System;
using System.Collections.Generic;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.FaceObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj
{
    public class ValidacoesPoliedro
    {
        public void AssineRegraDeCriacao(IList<Ponto> vertices, IList<Aresta> arestas, IList<Face> faces)
        {
            AssineRegraDosVertices(vertices);
            AssineRegraDeEuler(vertices, arestas, faces);
        }

        private void AssineRegraDosVertices(IList<Ponto> vertices)
        {
            var quantidadeDeVertices = vertices.Count;

            if (quantidadeDeVertices > 3) { }

            throw new NotImplementedException();
        }

        private void AssineRegraDeEuler(IList<Ponto> vertices, IList<Aresta> arestas, IList<Face> faces)
        {
            var quantidadeDeVertices = vertices.Count;
            var quantidadeDeArestas = arestas.Count;
            var quantidadeDeFaces = faces.Count;

            throw new NotImplementedException();
        }
    }
}
