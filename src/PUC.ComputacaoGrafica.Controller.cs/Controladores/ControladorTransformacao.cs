using System;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Interfaces.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Persistencia.Repositorio;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Controller.Controladores
{
    public class ControladorTransformacao : IControladorTransformacao
    {
        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;

            Poliedro = new Poliedro();
        }

        public Poliedro Poliedro { get; private set; }

        public ITelaTransformacao Tela { get; private set; }

        public void Desenhe()
        {
            Tela.AtualizeTela();
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

        public void AdicioneAresta(object ponto, object pontoSecudario)
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

        public void AdicionePonto(double x, double y, double z)
        {
            using (var persistencia = RepositorioPonto.ObtenhaInstancia())
            {
                var ponto = new Ponto(x, y, z);

                Poliedro.AdicionePonto(ponto);

                persistencia.Cadastre(ponto);

                Tela.AdicionePonto(ponto);
            }
        }

        public IList<Ponto> ObtenhaPonto()
        {
            return Poliedro.Vertices;
        }

        public void RemovaPonto(double x, double y, double z)
        {
            var ponto = new Ponto(x, y, z);

            Poliedro.RemovaPonto(ponto);
        }
    }
}
