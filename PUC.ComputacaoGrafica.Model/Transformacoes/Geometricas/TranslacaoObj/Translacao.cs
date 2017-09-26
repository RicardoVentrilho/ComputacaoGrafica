using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj
{
    public class Translacao : ITransformacao<Ponto>
    {
        private static readonly Translacao _Instancia = new Translacao(0, 0, 0);

        private Translacao(int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            DeslocamentoX = deslocamentoX;
            DeslocamentoY = deslocamentoY;
            DeslocamentoZ = deslocamentoZ;
        }

        public int DeslocamentoX { get; set; }

        public int DeslocamentoY { get; set; }

        public int DeslocamentoZ { get; set; }

        public static Translacao ObtenhaInstancia(int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            _Instancia.DeslocamentoX = deslocamentoX;
            _Instancia.DeslocamentoY = deslocamentoY;
            _Instancia.DeslocamentoZ = deslocamentoZ;

            return _Instancia;
        }

        public Ponto Calcule(Ponto conceito)
        {
            throw new NotImplementedException();
        }
    }
}