using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.CisalhamentoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.RotacionamentoObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public class TransformacaoGeometricaDoPoliedro : ITransformacaoGeometrica<Poliedro>
    {
        public Poliedro Translade(Poliedro poliedro, int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            throw new NotImplementedException();
        }

        public Poliedro Escalone(Poliedro poliedro, int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            throw new NotImplementedException();
        }

        public Poliedro Cisalhe(Poliedro poliedro, Direcao direcao, EnumCoordenadas proporcao)
        {
            var cisalhamento = Cisalhamento.ObtenhaInstancia(direcao, proporcao);

            throw new NotImplementedException();
        }

        public Poliedro Rotacione(Poliedro poliedro, EnumCoordenadas eixo, double angulo)
        {
            var rotacionamento = Rotacionamento.ObtenhaInstancia(eixo, angulo);

            throw new NotImplementedException();
        }
    }
}
