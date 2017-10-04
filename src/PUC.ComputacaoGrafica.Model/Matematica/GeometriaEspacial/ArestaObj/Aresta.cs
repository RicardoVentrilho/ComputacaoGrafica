using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj
{
    public sealed class Aresta
    {
        private readonly Tuple<Ponto3d, Ponto3d> _Aresta;
        
        public Aresta(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            PrimeiroPonto = primeiroPonto;
            UltimoPonto = ultimoPonto;

            _Aresta = new Tuple<Ponto3d, Ponto3d>(PrimeiroPonto, UltimoPonto);
        }

        public Ponto3d PrimeiroPonto { get; private set; }

        public Ponto3d UltimoPonto { get; private set; }

        public override int GetHashCode()
        {
            return PrimeiroPonto.GetHashCode() * 7993 + UltimoPonto.GetHashCode() * 6553;
        }

        public override string ToString()
        {
            return $"{PrimeiroPonto} -> {UltimoPonto}";
        }
    }
}