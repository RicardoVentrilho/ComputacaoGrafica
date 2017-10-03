using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            AdicioneOs3Eixos();

            Children.Clear();
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

        public void AdicioneLinha(Ponto primeiroPonto, Ponto ultimoPonto)
        {
            var linha = new Line();
            linha.Stroke = Brushes.Black;

            var metadeDoPlano = Width / 2;

            linha.X1 = (primeiroPonto.X - primeiroPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;
            linha.X2 = (ultimoPonto.X - ultimoPonto.Z * DIRECAO_EIXO_Z) * PROPORCAO + metadeDoPlano;

            linha.Y1 = (-1 * primeiroPonto.Y + primeiroPonto.Z * 0.5) * PROPORCAO + metadeDoPlano;
            linha.Y2 = (-1 * ultimoPonto.Y + ultimoPonto.Z * 0.5) * PROPORCAO + metadeDoPlano;

            Children.Add(linha);
        }

        private void AdicioneEixoX()
        {
            var origem = new Ponto(0, 0, 0);
            var limiteX = new Ponto(Width/2, 0, 0);

            AdicioneLinha(origem, limiteX, Brushes.Red);
        }

        private void AdicioneEixoY()
        {
            var origem = new Ponto(0, 0, 0);
            var limiteY = new Ponto(0, Height / 2, 0);

            AdicioneLinha(origem, limiteY, Brushes.Green);
        }

        private void AdicioneEixoZ()
        {
            var origem = new Ponto(0, 0, 0);
            var limiteY = new Ponto(-1 * (Width / 2), - 1 * (Height / 2), 0);

            AdicioneLinha(origem, limiteY, Brushes.Blue);
        }

        private void AdicioneOs3Eixos()
        {
            AdicioneEixoX();
            AdicioneEixoY();
            AdicioneEixoZ();
        }

        private void AdicioneLinha(Ponto primeiroPonto, Ponto ultimoPonto, Brush estilo)
        {
            var linha = new Line();

            linha.Stroke = estilo;

            linha.X1 = primeiroPonto.X - primeiroPonto.Z * 0.5 + 250;
            linha.X2 = ultimoPonto.X - ultimoPonto.Z * 0.5 + 250;

            linha.Y1 = -1 * primeiroPonto.Y + primeiroPonto.Z * 0.5 + 250;
            linha.Y2 = -1 * ultimoPonto.Y + ultimoPonto.Z * 0.5 + 250;

            Children.Add(linha);
        }
    }
}
