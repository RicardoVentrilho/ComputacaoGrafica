using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public static class TransformacaoGeometrica
    {
        public static Ponto Translade(Ponto ponto, int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            var translacao = Translacao.ObtenhaInstancia(deslocamentoX, deslocamentoY, deslocamentoZ);

            var pontoCalculado = translacao.Calcule(ponto);

            return pontoCalculado;
        }

        public static Ponto Escalone(Ponto ponto, int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            var escalonamento = Escalonamento.ObtenhaInstancia(escalonamentoX, escalonamentoY, escalonamentoZ);

            var pontoCalculado = escalonamento.Calcule(ponto);

            return pontoCalculado;
        }

        public static Ponto Rotacione(Ponto ponto)
        {
            throw new NotImplementedException();
        }

        public static Ponto Cisalhe(Ponto ponto, Direcao direcao, EnumCoordenadas proporcao)
        {
            var cisalhamento = Cisalhamento.ObtenhaInstancia(direcao, proporcao);

            var pontoCalculado = cisalhamento.Calcule(ponto);

            return pontoCalculado;
        }
    }
}
