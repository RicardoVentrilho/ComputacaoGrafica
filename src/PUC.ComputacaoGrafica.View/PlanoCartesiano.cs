using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;

namespace PUC.ComputacaoGrafica.View
{
    public class PlanoCartesiano : Canvas
    {
        private const double PROPORCAO = 10;

        private const double DIRECAO_EIXO_Z = 0.5;

        public PlanoCartesiano()
        {
            Background = Brushes.White;
            Height = 500;
            Width = 500;

            AdicioneOs3Eixos();
        }

        public void Limpe()
        {
            Children.Clear();

            AdicioneOs3Eixos();
        }

        public void AdicionePonto(Ponto3d ponto)
        {
            AdicionePonto(ponto.X, ponto.Y, ponto.Z);
        }

        public void AdicionePonto(double x, double y, double z)
        {
            var ponto = new Ellipse();

            ponto.Width = ponto.Height = 5;
            var margemDoPonto = ponto.Width / 2;
            var metadeDoPlano = Width / 2;

            ponto.Fill = new SolidColorBrush(Colors.Black);

            Children.Add(ponto);

            SetLeft(ponto, (x - z * DIRECAO_EIXO_Z ) * PROPORCAO + metadeDoPlano - margemDoPonto);
            SetTop(ponto, (-1 * y + z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano - margemDoPonto);
        }

        public void AdicionePonto(Ponto3d ponto3d, SolidColorBrush darkRed)
        {
            var ponto = new Ellipse();

            ponto.Width = ponto.Height = 5;
            var margemDoPonto = ponto.Width / 2;
            var metadeDoPlano = Width / 2;

            ponto.Fill = darkRed;

            Children.Add(ponto);

            SetLeft(ponto, (ponto3d.X - ponto3d.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano - margemDoPonto);
            SetTop(ponto, (-1 * ponto3d.Y + ponto3d.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano - margemDoPonto);
        }

        public Point ConvertaPonto3dPara2d(Ponto3d ponto3d)
        {
            var x = (ponto3d.X - ponto3d.Z * DIRECAO_EIXO_Z);
            var y = (ponto3d.Y - ponto3d.Z * DIRECAO_EIXO_Z);

            var ponto2d = new Point(x, y);

            return ponto2d;
        }

        private void AdicioneLinha(Aresta aresta)
        {
            AdicioneLinha(aresta.PrimeiroPonto, aresta.UltimoPonto);
        }

        public void AdicioneLinha(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            var linha = new Line()
            {
                Stroke = Brushes.Black
            };

            var metadeDoPlano = Width / 2;

            linha.X1 = (primeiroPonto.X - primeiroPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;
            linha.X2 = (ultimoPonto.X - ultimoPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;

            linha.Y1 = (-1 * primeiroPonto.Y + primeiroPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;
            linha.Y2 = (-1 * ultimoPonto.Y + ultimoPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;

            Children.Add(linha);
        }

        public void Desenhe(Poliedro poliedro)
        {
            var pontos = poliedro.Vertices;

            foreach (var ponto in pontos)
            {
                AdicionePonto(ponto);
            }

            var arestas = poliedro.Arestas;

            foreach (var aresta in arestas)
            {
                AdicioneLinha(aresta);
            }
        }

        private void AdicioneEixoX()
        {
            var origem = new Ponto3d(0, 0, 0);
            var limiteX = new Ponto3d(Width/2, 0, 0);

            AdicioneLinha(origem, limiteX, Brushes.Red);
        }

        private void AdicioneEixoY()
        {
            var origem = new Ponto3d(0, 0, 0);
            var limiteY = new Ponto3d(0, Height / 2, 0);

            AdicioneLinha(origem, limiteY, Brushes.Green);
        }

        private void AdicioneEixoZ()
        {
            var origem = new Ponto3d(0, 0, 0);
            var limiteY = new Ponto3d(-1 * (Width / 2), - 1 * (Height / 2), 0);

            AdicioneLinha(origem, limiteY, Brushes.Blue);
        }

        private void AdicioneOs3Eixos()
        {
            AdicioneEixoX();
            AdicioneEixoY();
            AdicioneEixoZ();
        }

        private void AdicioneLinha(Ponto3d primeiroPonto, Ponto3d ultimoPonto, Brush estilo)
        {
            var linha = new Line()
            {
                Stroke = estilo,

                X1 = primeiroPonto.X - primeiroPonto.Z * 0.5 + 250,
                X2 = ultimoPonto.X - ultimoPonto.Z * 0.5 + 250,

                Y1 = -1 * primeiroPonto.Y + primeiroPonto.Z * 0.5 + 250,
                Y2 = -1 * ultimoPonto.Y + ultimoPonto.Z * 0.5 + 250
            };
            Children.Add(linha);
        }

        public Point CorvertaCoordenadaParaPonto2d(Point coordenada)
        {
            var x = (coordenada.X - Width/2) - Margin.Left;
            var y = ((-1 * coordenada.Y) + Height/2) + Margin.Top;

            var ponto = new Point(x / PROPORCAO, y / PROPORCAO);

            return ponto;
        }
    }
}
