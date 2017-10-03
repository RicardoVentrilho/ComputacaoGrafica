﻿using System;
using System.Collections.Generic;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj
{
    public class ValidacoesPoliedro
    {
        public void AssineRegraDeCriacao(IList<Ponto3d> vertices, IList<Aresta> arestas)
        {
            AssineRegraDosVertices(vertices);
            AssineRegraDeEuler(vertices, arestas);
        }

        private void AssineRegraDosVertices(IList<Ponto3d> vertices)
        {
            var quantidadeDeVertices = vertices.Count;

            if (quantidadeDeVertices > 3) { }
        }

        private void AssineRegraDeEuler(IList<Ponto3d> vertices, IList<Aresta> arestas)
        {
            throw new NotImplementedException();
        }
    }
}
