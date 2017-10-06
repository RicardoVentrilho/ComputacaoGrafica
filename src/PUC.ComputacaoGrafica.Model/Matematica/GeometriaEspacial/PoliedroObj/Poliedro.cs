using System;
using System.Collections.Generic;
using System.Linq;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj
{
    internal class Poliedro
    {
        public Poliedro()
        {
            Vertices = new List<Ponto3d>();

            Arestas = new List<Aresta>();
        }

        public IList<Ponto3d> Vertices { get; set; }

        public IList<Aresta> Arestas { get; set; }

        public void AdicionePonto(Ponto3d ponto)
        {
            Vertices.Add(ponto);
        }

        public void RemovaPonto(Ponto3d pontoSelecionado)
        {
            Vertices = Vertices.Where(ponto => !ponto.Equals(pontoSelecionado)).ToList();
            Arestas = Arestas.Where(aresta => !aresta.PrimeiroPonto.Equals(pontoSelecionado)
                                              && !aresta.UltimoPonto.Equals(pontoSelecionado)).ToList();
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

        public Poliedro Clone()
        {
            var poliedro = new Poliedro
            {
                Arestas = Arestas.ToList(),
                Vertices = Vertices.ToList()
            };

            return poliedro;
        }

        public void RemovaAresta(Aresta arestaSelecionada)
        {
            Arestas = Arestas.Where(aresta => !aresta.Equals(arestaSelecionada)).ToList();
        }
    }
}
