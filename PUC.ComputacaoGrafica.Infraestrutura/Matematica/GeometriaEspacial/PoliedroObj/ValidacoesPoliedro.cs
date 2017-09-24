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
            AssineRegraDeEuler(vertices, arestas, faces);
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
