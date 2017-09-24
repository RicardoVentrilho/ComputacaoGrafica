using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.FaceObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj
{
    public partial class Poliedro
    {
        public ValidacoesPoliedro Validacoes { get; private set; }

        public Poliedro(IList<Ponto> vertices, IList<Aresta> arestas, IList<Face> faces)
        {
            Validacoes = new ValidacoesPoliedro();

            Validacoes.AssineRegraDeCriacao(vertices, arestas, faces);

            Vertices = vertices;
            Arestas = arestas;
            Faces = faces;
        }

        public IList<Ponto> Vertices { get; private set; }

        public IList<Aresta> Arestas { get; private set; }

        public IList<Face> Faces { get; private set; }
    }
}
