using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;
using System;

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

        public IList<Ponto> Vertices { get; private set; }

        public IList<Aresta> Arestas { get; private set; }

        public void AdicionePonto(Ponto ponto)
        {
            Vertices.Add(ponto);
        }

        public void RemovaPonto(Ponto ponto)
        {
            throw new NotImplementedException();
        }
    }
}
