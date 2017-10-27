// -----------------------------------------------------------------------
// <copyright file="PoliedroProxy.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj
{
    public class PoliedroProxy
    {
        private Poliedro _Poliedro;

        private static readonly Stack<Poliedro> _PilhaDePoliedros = new Stack<Poliedro>();

        public PoliedroProxy()
        {
            _Poliedro = new Poliedro();
        }

        public IList<Ponto3d> Vertices
        {
            get
            {
                return _Poliedro.Vertices;
            }
            set { _Poliedro.Vertices = value; }
        }

        public IList<Aresta> Arestas
        {
            get
            {
                return _Poliedro.Arestas;
            }
            set { _Poliedro.Arestas = value; }
        }

        public void AdicionePonto(Ponto3d ponto)
        {
            AdicionaNaPilha();

            _Poliedro.AdicionePonto(ponto);
        }

        public void RemovaPonto(Ponto3d ponto)
        {
            AdicionaNaPilha();

            _Poliedro.RemovaPonto(ponto);
        }

        public void AdicioneAresta(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            AdicionaNaPilha();

            _Poliedro.AdicioneAresta(primeiroPonto, ultimoPonto);
        }

        public void AdicioneAresta(Aresta aresta)
        {
            AdicionaNaPilha();

            _Poliedro.AdicioneAresta(aresta);
        }

        public void LimpeArestas()
        {
            _Poliedro.LimpeArestas();
        }

        public void LimpeVertices()
        {
            _Poliedro.LimpeVertices();
        }

        public PoliedroProxy Clone()
        {
            var poliedro = new PoliedroProxy
            {
                Arestas = Arestas.ToList(),
                Vertices = Vertices.ToList()
            };

            return poliedro;
        }

        public void RemovaAresta(Aresta aresta)
        {
            AdicionaNaPilha();

            _Poliedro.RemovaAresta(aresta);
        }

        public void Desfaca()
        {
            _Poliedro = _PilhaDePoliedros.Pop();
        }

        public void AdicionaNaPilha()
        {
            _PilhaDePoliedros.Push(_Poliedro.Clone());
        }
    }
}
