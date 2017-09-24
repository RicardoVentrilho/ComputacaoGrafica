using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.CisalhamentoObj
{
    public class Cisalhamento : ITransformacao
    {
        private static readonly Cisalhamento _Instancia = new Cisalhamento(null, EnumCoordenadas.X);

        public Cisalhamento(Direcao direcao, EnumCoordenadas proporcao)
        {
            Direcao = direcao;
            Proporcao = proporcao;
        }

        public Direcao Direcao { get; set; }
        public EnumCoordenadas Proporcao { get; set; }

        public static Cisalhamento ObtenhaInstancia(Direcao direcao, EnumCoordenadas proporcao)
        {
            _Instancia.Direcao = direcao;
            _Instancia.Proporcao = proporcao;

            return _Instancia;
        }

        public Ponto Calcule(out Ponto ponto)
        {
            throw new NotImplementedException();
        }
    }
}