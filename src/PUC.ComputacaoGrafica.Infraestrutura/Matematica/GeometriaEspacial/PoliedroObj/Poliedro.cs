using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;
using System;
using System.Windows;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj
{
    public class Poliedro
    {
        public ValidacoesPoliedro Validacoes { get; private set; }

        public Poliedro()
        {
            Validacoes = new ValidacoesPoliedro();

            Vertices = new List<Ponto3d>();

            Arestas = new List<Aresta>();
        }

        public IList<Ponto3d> Vertices { get; set; }

        public IList<Aresta> Arestas { get; set; }

        public void AdicionePonto(Ponto3d ponto)
        {
            Vertices.Add(ponto);
        }

        public void RemovaPonto(Ponto3d ponto)
        {
            throw new NotImplementedException();
        }

        public void AdicioneAresta(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            var aresta = new Aresta(primeiroPonto, ultimoPonto);

            Arestas.Add(aresta);
        }

        public void AdicioneAresta(Aresta aresta)
        {
            Arestas.Add(aresta);
        }

        public void LimpeArestas()
        {
            Arestas.Clear();
        }

        public void LimpeVertices()
        {
            Vertices.Clear();
        }

        public IList<Point> ObtenhaVertices2d()
        {
            throw new NotImplementedException();
        }
    }
}
