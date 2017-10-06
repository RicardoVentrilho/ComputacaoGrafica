using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.View
{
    public class PlanoCartesiano : Canvas
    {
        #region "CAMPOS"

        private double _Proporcao;

        private double _DirecaoEixoZ;

        #endregion

        #region "PROPRIEDADES"

        public double Proporcao
        {
            set { _Proporcao = value; }
            get { return _Proporcao; }
        }

        public double DirecaoEixoZ
        {
            set { _DirecaoEixoZ = value; }
            get { return _DirecaoEixoZ; }
        }

        public double Tamanho
        {
            get { return Height; }
            set
            {
                Height = value;
                Width = value;

                AdicioneOs3Eixos();
            }
        }

        #endregion

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

            SetLeft(ponto, (x - z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano - margemDoPonto);
            SetTop(ponto, (-1 * y + z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano - margemDoPonto);
        }

        public void AdicionePonto(Ponto3d ponto3d, SolidColorBrush darkRed)
        {
            var ponto = new Ellipse();

            ponto.Width = ponto.Height = 5;
            var margemDoPonto = ponto.Width / 2;
            var metadeDoPlano = Width / 2;

            ponto.Fill = darkRed;

            Children.Add(ponto);

            SetLeft(ponto, (ponto3d.X - ponto3d.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano - margemDoPonto);
            SetTop(ponto, (-1 * ponto3d.Y + ponto3d.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano - margemDoPonto);
        }

        public Point ConvertaPonto3dPara2d(Ponto3d ponto3d)
        {
            var x = (ponto3d.X - ponto3d.Z * _DirecaoEixoZ);
            var y = (ponto3d.Y - ponto3d.Z * _DirecaoEixoZ);

            var ponto2d = new Point(x, y);

            return ponto2d;
        }



        public void AdicioneLinha(Ponto3d primeiroPonto, Ponto3d ultimoPonto)
        {
            var linha = new Line()
            {
                Stroke = Brushes.Black
            };

            var metadeDoPlano = Width / 2;

            linha.X1 = (primeiroPonto.X - primeiroPonto.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano;
            linha.X2 = (ultimoPonto.X - ultimoPonto.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano;

            linha.Y1 = (-1 * primeiroPonto.Y + primeiroPonto.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano;
            linha.Y2 = (-1 * ultimoPonto.Y + ultimoPonto.Z * _DirecaoEixoZ) * _Proporcao + metadeDoPlano;

            Children.Add(linha);
        }

        public Point CorvertaParaPonto2D(Point coordenada)
        {
            var x = (coordenada.X - Width / 2) - Margin.Left;
            var y = ((-1 * coordenada.Y) + Height / 2) + Margin.Top;

            var ponto = new Point(x / _Proporcao, y / _Proporcao);

            return ponto;
        }

        public void Desenhe(PoliedroProxy poliedro)
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

        #region "MÉTODO PRIVADOS"

        private void AdicioneLinha(Aresta aresta)
        {
            AdicioneLinha(aresta.PrimeiroPonto, aresta.UltimoPonto);
        }

        private void AdicioneEixoX()
        {
            var origem = new Ponto3d(0, 0, 0);
            var limiteX = new Ponto3d(Width / 2, 0, 0);

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
            var limiteY = new Ponto3d(-1 * (Width / 2), -1 * (Height / 2), 0);

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
            var linha = new Line
            {
                Stroke = estilo,

                X1 = primeiroPonto.X - primeiroPonto.Z * 0.5 + 250,
                X2 = ultimoPonto.X - ultimoPonto.Z * 0.5 + 250,

                Y1 = -1 * primeiroPonto.Y + primeiroPonto.Z * 0.5 + 250,
                Y2 = -1 * ultimoPonto.Y + ultimoPonto.Z * 0.5 + 250
            };
            Children.Add(linha);
        }

        #endregion
    }
}
