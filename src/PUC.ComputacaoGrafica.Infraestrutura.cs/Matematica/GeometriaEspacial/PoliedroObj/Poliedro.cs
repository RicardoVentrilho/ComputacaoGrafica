using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.FaceObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj
{
    public class Poliedro
    {
        public ValidacoesPoliedro Validacoes { get; private set; }

        public Poliedro(List<Ponto> vertices, List<Aresta> arestas)
        {
            Validacoes = new ValidacoesPoliedro();

            Validacoes.AssineRegraDeCriacao(vertices, arestas);

            Vertices = vertices;
            Arestas = arestas;
        }

        public IList<Ponto> Vertices { get; private set; }

        public IList<Aresta> Arestas { get; private set; }
    }
}
