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
        #region "CONSTRUTOR"

        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;

            Poliedro = new Poliedro();

            TransformacoesGeometricas = new TransformacaoGeometricaDoPoliedro();

            PontosSelecionados = new List<Ponto3d>();
        }

        #endregion

        #region "PROPRIEDADES"

        public List<Ponto3d> PontosSelecionados { get; private set; }

        public ITransformacaoGeometrica<Poliedro> TransformacoesGeometricas { get; private set; }

        public Poliedro Poliedro { get; private set; }

        public ITelaTransformacao Tela { get; private set; }

        #endregion

        public void Translade(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            ValidePontoSelecionado();

            TransformacoesGeometricas.Translade(Poliedro, deslocamentoX, deslocamentoY, deslocamentoZ);

            AtualizeTela();
        }

        public void AdicioneAresta(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            var aresta = new Aresta(primeiroPonto, ultimoPonto);

            Poliedro.AdicioneAresta(aresta);

            AtualizeTela();
        }

        public void AdicionePonto(double x, double y, double z)
        {
            var ponto = new Ponto3d(x, y, z);

            Poliedro.AdicionePonto(ponto);

            AtualizeTela();
        }

        public void RemovaPonto(double x, double y, double z)
        {
            var ponto = new Ponto3d(x, y, z);

            Poliedro.RemovaPonto(ponto);

            AtualizeTela();
        }

        public void Rotacione(EnumCoordenadas eixo, double angulo)
        {
            ValidePontoSelecionado();

            TransformacoesGeometricas.Rotacione(Poliedro, eixo, angulo);

            AtualizeTela();
        }

        public void SelecionePonto(Point coordenada)
        {
            var pontos3d = Poliedro.Vertices;

            foreach (var ponto3d in pontos3d)
            {
                var ponto2d = Tela.ConvertaPonto3dPara2d(ponto3d);

                if (PontoEstaNaMargem(coordenada, ponto2d))
                {
                    if (PontosSelecionados.Any())
                    {
                        var ponto3dSelecionado = PontosSelecionados.First();

                        if (!ponto3dSelecionado.Equals(ponto3d))
                        {
                            Poliedro.AdicioneAresta(ponto3dSelecionado, ponto3d);
                        }

                        PontosSelecionados.Clear();
                    }
                    else
                    {
                        PontosSelecionados.Add(ponto3d);
                    }
                }
            }

            AtualizeTela();
        }

        #region "MÉTODOS DE APOIO"

        private bool PontoEstaNaMargem(Point coordenada, Point ponto)
            => ((coordenada.X - 0.25) <= ponto.X && ponto.X <= (coordenada.X + 0.25))
                && ((coordenada.Y - 0.25) <= ponto.Y && ponto.Y <= (coordenada.Y + 0.25));

        private void AtualizeTela()
        {
            Tela.AtualizePlanoCartesiano(Poliedro);
            Tela.AtualizeArestas(Poliedro);

            if (PontosSelecionados.Any())
            {
                var ponto = PontosSelecionados.First();

                Tela.AtualizePontoSelecionado(ponto);
            }
        }

        private void ValidePontoSelecionado()
        {
            if (PontosSelecionados.Any())
            {
                throw new Exception("Existe ponto selecionado!");
            }
        }

        #endregion
    }
}
