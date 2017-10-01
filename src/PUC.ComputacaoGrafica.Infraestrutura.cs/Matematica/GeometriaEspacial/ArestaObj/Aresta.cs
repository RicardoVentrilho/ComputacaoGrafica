using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj
{
    public struct Aresta
    {
        private readonly Tuple<Ponto, Ponto> _Aresta;
        
        public Aresta(Ponto primeiroPonto, Ponto ultimoPonto)
        {
            PrimeiroPonto = primeiroPonto;
            UltimoPonto = ultimoPonto;

            _Aresta = new Tuple<Ponto, Ponto>(PrimeiroPonto, UltimoPonto);
        }

        public Ponto PrimeiroPonto { get; private set; }

        public Ponto UltimoPonto { get; private set; }

        public override int GetHashCode()
        {
            return PrimeiroPonto.GetHashCode() * 7993 + UltimoPonto.GetHashCode() * 6553;
        }
    }
}