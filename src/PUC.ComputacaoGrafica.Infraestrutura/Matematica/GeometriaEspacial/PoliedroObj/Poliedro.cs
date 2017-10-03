﻿using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
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

            Vertices = new List<Ponto>();

            Arestas = new List<Aresta>();
        }

        public IList<Ponto> Vertices { get; set; }

        public IList<Aresta> Arestas { get; set; }

        public void AdicionePonto(Ponto ponto)
        {
            Vertices.Add(ponto);
        }

        public void RemovaPonto(Ponto ponto)
        {
            throw new NotImplementedException();
        }

        public void AdicioneAresta(Ponto primeiroPonto, Ponto ultimoPonto)
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
