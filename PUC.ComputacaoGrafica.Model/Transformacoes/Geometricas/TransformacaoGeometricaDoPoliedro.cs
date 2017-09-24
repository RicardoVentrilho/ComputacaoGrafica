using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public static class TransformacaoGeometricaDoPoliedro
    {
        public static Poliedro Translade(this Poliedro poliedro, int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            throw new NotImplementedException();
        }

        public static Poliedro Escalone(this Poliedro poliedro, int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            throw new NotImplementedException();
        }

        public static Poliedro Rotacione(this Poliedro poliedro)
        {
            throw new NotImplementedException();
        }

        public static Poliedro Cisalhe(this Poliedro poliedro, Direcao direcao, EnumCoordenadas proporcao)
        {
            throw new NotImplementedException();
        }
    }
}
