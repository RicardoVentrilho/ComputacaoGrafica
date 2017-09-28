using System;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Interfaces.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;

namespace PUC.ComputacaoGrafica.Controller.Controladores
{
    public class ControladorTransformacao : IControladorTransformacao
    {
        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;
        }

        public ITelaTransformacao Tela { get; private set; }

        public void Desenhe(Poliedro poliedro)
        {
            throw new NotImplementedException();
        }

        public Poliedro Cisalhe(Poliedro poliedro, Direcao direcao, EnumCoordenadas proporcao)
        {
            throw new NotImplementedException();
        }

        public Poliedro Escalone(Poliedro poliedro, int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            throw new NotImplementedException();
        }

        public Poliedro Translade(Poliedro poliedro, int deslocamentoX, int deslocamentoY, int deslocamentoZ)
        {
            throw new NotImplementedException();
        }

        public void Translade(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }

        public Poliedro ProjeteUmAxiomaIsometrico()
        {
            throw new NotImplementedException();
        }

        public Poliedro ProjeteUmPlanarPerspectivo()
        {
            throw new NotImplementedException();
        }

        public Poliedro Rotacione(Poliedro poliedro, EnumCoordenadas eixo, double angulo)
        {
            throw new NotImplementedException();
        }

        public void AdicionePonto(double d, double d1, double d2)
        {
            throw new NotImplementedException();
        }

        public void AdicioneAresta()
        {
            throw new NotImplementedException();
        }
    }
}
