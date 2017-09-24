using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public class Escalonamento : ITransformacao
    {
        private static readonly Escalonamento _Instancia = new Escalonamento(0, 0, 0);
        
        private Escalonamento(int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            EscalonamentoX = escalonamentoX;
            EscalonamentoY = escalonamentoY;
            EscalonamentoZ = escalonamentoZ;
        }

        public int EscalonamentoX { get; set; }
        public int EscalonamentoY { get; set; }
        public int EscalonamentoZ { get; set; }

        public static Escalonamento ObtenhaInstancia(int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            _Instancia.EscalonamentoX = escalonamentoX;
            _Instancia.EscalonamentoY = escalonamentoY;
            _Instancia.EscalonamentoZ = escalonamentoZ;

            return _Instancia;
        }

        public Ponto Calcule(Ponto ponto)
        {
            throw new NotImplementedException();
        }
    }
}