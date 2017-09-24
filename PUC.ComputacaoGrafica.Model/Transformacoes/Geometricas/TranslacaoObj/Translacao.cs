using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj
{
    public class Translacao : ITransformacao
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

        public Ponto Calcule(out Ponto ponto)
        {
            throw new NotImplementedException();
        }
    }
}