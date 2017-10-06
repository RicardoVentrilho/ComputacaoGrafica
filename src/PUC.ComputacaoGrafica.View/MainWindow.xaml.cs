using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITelaTransformacao
    {
        public MainWindow()
        {
            Controlador = new ControladorTransformacao(this);

            InitializeComponent();

            AtualizeComponentes();
        }

        public ControladorTransformacao Controlador { get; private set; }

        #region "MÉTODOS PÚBLICOS"

        public void AtualizePontoSelecionado(Ponto3d ponto)
        {
            _PlanoCartesiano.AdicionePonto(ponto, Brushes.Red);
        }

        public Point ConvertaPonto3dPara2d(Ponto3d ponto3d)
        {
            return _PlanoCartesiano.ConvertaPonto3dPara2d(ponto3d);
        }

        public void AdicioneAresta(Aresta aresta)
        {
            arestasListBox.Items.Add(aresta);
        }

        public void AtualizePlanoCartesiano(PoliedroProxy poliedro)
        {
            _PlanoCartesiano.Limpe();
            _PlanoCartesiano.Desenhe(poliedro);
        }

        public void AtualizeArestas(PoliedroProxy poliedro)
        {
            var arestas = poliedro.Arestas;

            arestasListBox.Items.Clear();

            foreach (var aresta in arestas)
            {
                arestasListBox.Items.Add(aresta);
            }
        }

        public void AdicionePoliedro(PoliedroProxy poliedroProjetado)
        {
            _PlanoCartesiano.Desenhe(poliedroProjetado);
        }

        #endregion

        #region "EVENTOS"

        private void RemovaPonto(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() => 
            {
                Controlador.RemovaPontoSelecionado();
            });
        }

        private void RemovaAresta(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() => 
            {
                var aresta = (Aresta)arestasListBox.SelectedItem;

                Controlador.RemovaAresta(aresta);
            });
        }

        private void AdicionePonto(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var x = double.Parse(caixaDeTextoX.Text);
                var y = double.Parse(caixaDeTextoY.Text);
                var z = double.Parse(caixaDeTextoZ.Text);

                _PlanoCartesiano.AdicionePonto(x, y, z);

                Controlador.AdicionePonto(x, y, z);
            });
        }

        private void Translade(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var deslocamentoX = double.Parse(deslocamentoXTextBox.Text);
                var deslocamentoY = double.Parse(deslocamentoYTextBox.Text);
                var deslocamentoZ = double.Parse(deslocamentoZTextBox.Text);

                Controlador.Translade(deslocamentoX, deslocamentoY, deslocamentoZ);
            });
        }

        private void Rotacione(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var angulo = double.Parse(anguloTextBox.Text);

                var eixo = (EnumCoordenadas)eixosComboBox.SelectedItem;

                Controlador.Rotacione(eixo, angulo);
            });
        }

        private void Escalone(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var escalonamentoX = double.Parse(escalonamentoXTextBox.Text);
                var escalonamentoY = double.Parse(escalonamentoYTextBox.Text);
                var escalonamentoZ = double.Parse(escalonamentoZTextBox.Text);

                Controlador.Escalone(escalonamentoX, escalonamentoY, escalonamentoZ);
            });
        }

        private void Cisalhe(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var proporcaoX = double.Parse(proporcaoXTextBox.Text);
                var proporcaoY = double.Parse(proporcaoYTextBox.Text);
                var proporcaoZ = double.Parse(proporcaoZTextBox.Text);

                var direcao = (EnumCoordenadas)proporcaoComboBox.SelectedItem;

                Controlador.Cisalhe(proporcaoX, proporcaoY, proporcaoZ, direcao);
            });
        }

        private void CliqueBotaoEsquerdo(object sender, MouseButtonEventArgs e)
        {
            MetodoProxy(() =>
            {
                var coordenada = e.GetPosition(this);
                var ponto = _PlanoCartesiano.CorvertaParaPonto2D(coordenada);

                Controlador.SelecionePonto(ponto);
            });
        }

        private void Desfaca(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                Controlador.Desfaca();
            });
        }

        private void ProjetePlanar(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var dPonto = double.Parse(pontoPlanoTextBox.Text);

                var plano = (EnumPlano)planosComboBox.SelectedIndex;

                Controlador.ProjetePlanarPerspectivo(dPonto, plano);
            });
        }

        private void ProjeteAxometrica(object sender, RoutedEventArgs e)
        {
            MetodoProxy(() =>
            {
                var x = double.Parse(pontoXAxometricaTextBox.Text);
                var y = double.Parse(pontoYAxometricaTextBox.Text);
                var z = double.Parse(pontoZAxometricaTextBox.Text);

                var plano = (EnumPlano)planosAxometricoComboBox.SelectedIndex;

                Controlador.ProjeteAxometrica(x, y, z, plano);
            });
        }

        private void DesprojetePlanar(object sender, MouseEventArgs e)
        {
            MetodoProxy(() =>
            {
                Controlador.DesprojetePlanar();
            });
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void AtualizeComponentes()
        {
            eixosComboBox.ItemsSource = new[] { EnumCoordenadas.X, EnumCoordenadas.Y, EnumCoordenadas.Z };

            proporcaoComboBox.ItemsSource = new[] { EnumCoordenadas.X, EnumCoordenadas.Y, EnumCoordenadas.Z };

            planosComboBox.ItemsSource = new[] { EnumPlano.XY, EnumPlano.XZ, EnumPlano.YZ };

            planosAxometricoComboBox.ItemsSource = new[] { EnumPlano.XY, EnumPlano.XZ, EnumPlano.YZ };
        }

        private void MetodoProxy(Action acao)
        {
            try
            {
                acao.Invoke();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion
    }
}
