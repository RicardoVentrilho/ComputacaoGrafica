using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Extensoes;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.EscalonamentoObj
{
    public class Escalonamento : ITransformacao<Ponto3d>
    {
        private static readonly Escalonamento _Instancia = new Escalonamento(0, 0, 0);
        
        private Escalonamento(int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            EscalonamentoX = escalonamentoX;
            EscalonamentoY = escalonamentoY;
            EscalonamentoZ = escalonamentoZ;
        }

        public int EscalonamentoX { get; private set; }

        public int EscalonamentoY { get; private set; }

        public int EscalonamentoZ { get; private set; }

        public DenseMatrix MatrizParaEscalonamento { get; private set; }

        public static Escalonamento ObtenhaInstancia(int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            _Instancia.EscalonamentoX = escalonamentoX;
            _Instancia.EscalonamentoY = escalonamentoY;
            _Instancia.EscalonamentoZ = escalonamentoZ;

            _Instancia.MatrizParaEscalonamento = DenseMatrix.OfArray(new double[,]
            {
                { escalonamentoX, 0, 0, 0 },
                { 0, escalonamentoY, 0, 0 },
                { 0, 0, escalonamentoZ, 0 },
                { 0, 0, 0, 1 }
            });

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizVertical();

            var resultado = MatrizParaEscalonamento * pontoComoMatriz;

            var ponto = resultado.ConvertaHorizontalParaPonto();

            return ponto;
        }
    }
}