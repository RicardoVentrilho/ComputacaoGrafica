using System;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Interfaces.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using System.Windows;
using System.Linq;

namespace PUC.ComputacaoGrafica.Controller.Controladores
{
    public class ControladorTransformacao : IControladorTransformacao
    {
        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;

            Poliedro = new Poliedro();

            TransformacoesGeometricas = new TransformacaoGeometricaDoPoliedro();

            PontosSelecionados = new List<Point>();
        }

        public List<Point> PontosSelecionados { get; private set; }

        public ITransformacaoGeometrica<Poliedro> TransformacoesGeometricas { get; private set; }

        public Poliedro Poliedro { get; private set; }

        public ITelaTransformacao Tela { get; private set; }

        public void Translade(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            TransformacoesGeometricas.Translade(Poliedro, deslocamentoX, deslocamentoY, deslocamentoZ);

            AtualizeTela();
        }

        public void AdicioneAresta(Ponto primeiroPonto, Ponto ultimoPonto)
        {
            var aresta = new Aresta(primeiroPonto, ultimoPonto);

            Poliedro.AdicioneAresta(aresta);

            Tela.AdicioneAresta(aresta);

            Tela.AtualizePlanoCartesiano(Poliedro);
        }

        public void AdicionePonto(double x, double y, double z)
        {
            var ponto = new Ponto(x, y, z);

            Poliedro.AdicionePonto(ponto);

            Tela.AdicionePonto(ponto);

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

        public void Rotacione(EnumCoordenadas eixo, double angulo)
        {
            TransformacoesGeometricas.Rotacione(Poliedro, eixo, angulo);

            AtualizeTela();
        }

        private void AtualizeTela()
        {
            Tela.AtualizePlanoCartesiano(Poliedro);
            Tela.AtualizePontos(Poliedro);
            Tela.AtualizeArestas(Poliedro);
        }

        public void SelecionePonto(Point coordenada)
        {
            var pontos = Poliedro.ObtenhaVertices2d();

            var selecionados = pontos.Where(ponto => ponto.Equals(coordenada));

            if (selecionados.Any())
            {
                var selecionado = selecionados.First();

                if (PontosSelecionados.Any())
                {
                    var primeiro = PontosSelecionados.First();

                    Poliedro.AdicioneAresta(primeiro, selecionado);
                }
                else
                {
                    PontosSelecionados.Add(selecionado);
                }
            }
        }
    }
}
