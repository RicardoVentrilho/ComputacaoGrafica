using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Interfaces.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ProporcaoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;

namespace PUC.ComputacaoGrafica.Controller.Controladores
{
    public class ControladorTransformacao : IControladorTransformacao
    {
        #region "CONSTRUTOR"

        public ControladorTransformacao(ITelaTransformacao tela)
        {
            Tela = tela;

            Poliedro = new PoliedroProxy();
            PoliedroProjetado = new PoliedroProxy();

            TransformacoesGeometricas = new TransformacaoGeometricaDoPoliedro();
            TransformacoesProjetivas = new TransformacaoProjetivaDoPoliedro();

            PontosSelecionados = new List<Ponto3d>();
        }

        #endregion

        #region "PROPRIEDADES"

        public List<Ponto3d> PontosSelecionados { get; private set; }

        public ITransformacaoGeometrica<PoliedroProxy> TransformacoesGeometricas { get; private set; }

        public PoliedroProxy Poliedro { get; private set; }

        public PoliedroProxy PoliedroProjetado { get; private set; }

        public ITelaTransformacao Tela { get; private set; }

        public ITransformacaoProjetiva<PoliedroProxy> TransformacoesProjetivas { get; private set; }

        #endregion

        public void Translade(double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            ValidePontoSelecionado();

            TransformacoesGeometricas.Translade(Poliedro, deslocamentoX, deslocamentoY, deslocamentoZ);

            AtualizeTela();
        }

        public void RemovaPontoSelecionado()
        {
            if (PontosSelecionados.Any())
            {
                var ponto = PontosSelecionados.First();

                Poliedro.RemovaPonto(ponto);

                PontosSelecionados.Clear();
            }
            else
            {
                throw new Exception("Nenhum ponto selecionado");
            }

            AtualizeTela();
        }

        public void AdicioneAresta(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            var aresta = new Aresta(primeiroPonto, ultimoPonto);

            Poliedro.AdicioneAresta(aresta);

            AtualizeTela();
        }

        public void RemovaAresta(Aresta aresta)
        {
            Poliedro.RemovaAresta(aresta);

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

        public void Escalone(double escalonamentoX, double escalonamentoY, double escalonamentoZ)
        {
            ValidePontoSelecionado();

            TransformacoesGeometricas.Escalone(Poliedro, escalonamentoX, escalonamentoY, escalonamentoZ);

            AtualizeTela();
        }

        public void Cisalhe(double proporcaoX, double proporcaoY, double proporcaoZ, EnumCoordenadas direcao)
        {
            ValidePontoSelecionado();

            var proporcao = new Proporcao(proporcaoX, proporcaoY, proporcaoZ);

            TransformacoesGeometricas.Cisalhe(Poliedro, proporcao, direcao);

            AtualizeTela();
        }

        public void ProjetePlanarPerspectivo(double x, double y, double z, EnumPlano plano)
        {
            ValidePontoSelecionado();

            var ponto = new Ponto3d(x, y, z);

            PoliedroProjetado = TransformacoesProjetivas.ProjeteUmPlanarPerspectivo(Poliedro.Clone(), ponto, plano);

            AtualizeTela();
        }

        public void Desfaca()
        {
            ValidePontoSelecionado();

            Poliedro.Desfaca();

            AtualizeTela();
        }

        public void DesprojetePlanar()
        {
            PoliedroProjetado = null;

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

        public void CalculeAxometrica()
        {
            ValidePontoSelecionado();

            TransformacoesProjetivas.CalculeUmAxiomaIsometrico(Poliedro);

            AtualizeTela();
        }

        public void DesenheCubo()
        {
            ValidePontoSelecionado();

            Poliedro = new PoliedroProxy();
            Poliedro.AdicionaNaPilha();

            Poliedro.Vertices = new List<Ponto3d>
            {
                new Ponto3d(0, 0, 0),
                new Ponto3d(0, 0, 5),
                new Ponto3d(0, 5, 5),
                new Ponto3d(5, 5, 5),
                new Ponto3d(5, 5, 0),
                new Ponto3d(5, 0, 0),
                new Ponto3d(5, 0, 5),
                new Ponto3d(0, 5, 0),
            };

            Poliedro.Arestas = new List<Aresta>
            {
                new Aresta(new Ponto3d(0, 0, 0), new Ponto3d(0, 0, 5)),
                new Aresta(new Ponto3d(0, 0, 0), new Ponto3d(0, 5, 0)),
                new Aresta(new Ponto3d(0, 0, 0), new Ponto3d(5, 0, 0)),
                new Aresta(new Ponto3d(0, 5, 0), new Ponto3d(0, 5, 5)),
                new Aresta(new Ponto3d(0, 5, 0), new Ponto3d(5, 5, 0)),
                new Aresta(new Ponto3d(5, 0, 5), new Ponto3d(5, 0, 0)),
                new Aresta(new Ponto3d(5, 5, 0), new Ponto3d(5, 0, 0)),
                new Aresta(new Ponto3d(5, 5, 5), new Ponto3d(5, 5, 0)),
                new Aresta(new Ponto3d(0, 0, 5), new Ponto3d(5, 0, 5)),
                new Aresta(new Ponto3d(5, 5, 5), new Ponto3d(0, 5, 5)),
                new Aresta(new Ponto3d(0, 0, 5), new Ponto3d(0, 5, 5)),
                new Aresta(new Ponto3d(5, 5, 5), new Ponto3d(5, 0, 5)),
            };

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

            if (PoliedroProjetado != null)
            {
                Tela.AdicionePoliedro(PoliedroProjetado);
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
