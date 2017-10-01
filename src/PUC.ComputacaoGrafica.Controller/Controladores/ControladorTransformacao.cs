using System;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Interfaces.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Persistencia.Repositorio;
using System.Collections.Generic;
using PUC.ComputacaoGrafica.Persistencia.Repositorios;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;

namespace PUC.ComputacaoGrafica.Controller.Controladores
{
    public class ControladorTransformacao : IControladorTransformacao
    {
        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;

            Poliedro = new Poliedro();

            TransformacoesGeometricas = new TransformacaoGeometricaDoPoliedro();
        }

        public ITransformacaoGeometrica<Poliedro> TransformacoesGeometricas { get; private set; }

        public Poliedro Poliedro { get; private set; }

        public ITelaTransformacao Tela { get; private set; }

        public void Translade(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            Poliedro = TransformacoesGeometricas.Translade(Poliedro, deslocamentoX, deslocamentoY, deslocamentoZ);

            Tela.AtualizePlanoCartesiano(Poliedro);
            Tela.AtualizePontos(Poliedro);
            Tela.AtualizeArestas(Poliedro);
        }

        public void AdicioneAresta(Ponto primeiroPonto, Ponto ultimoPonto)
        {
            using (var persistencia = RepositorioAresta.ObtenhaInstancia())
            {
                var aresta = new Aresta(primeiroPonto, ultimoPonto);

                Poliedro.AdicioneAresta(aresta);

                persistencia.Cadastre(aresta);

                Tela.AdicioneAresta(aresta);
            }

            Tela.AtualizePlanoCartesiano(Poliedro);
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

            Tela.AtualizePlanoCartesiano(Poliedro);
        }

        public IList<Ponto> ObtenhaPontos()
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
