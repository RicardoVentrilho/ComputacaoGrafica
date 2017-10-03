using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using System;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using System.Windows.Input;

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

        public void AdicionePonto(Ponto ponto)
        {
            pontosListBox.Items.Add(ponto);
            pontosSecundariosListBox.Items.Add(ponto);
        }

        public void AdicioneAresta(Aresta aresta)
        {
            arestasListBox.Items.Add(aresta);
        }

        public void AtualizePlanoCartesiano(Poliedro poliedro)
        {
            _PlanoCartesiano.Limpe();
            _PlanoCartesiano.Desenhe(poliedro);
        }

        public void AtualizePontos(Poliedro poliedro)
        {
            var pontos = poliedro.Vertices;

            pontosListBox.Items.Clear();
            pontosSecundariosListBox.Items.Clear();

            foreach (var ponto in pontos)
            {
                pontosListBox.Items.Add(ponto);
                pontosSecundariosListBox.Items.Add(ponto);
            }
        }

        public void AtualizeArestas(Poliedro poliedro)
        {
            var arestas = poliedro.Arestas;

            arestasListBox.Items.Clear();

            foreach (var aresta in arestas)
            {
                arestasListBox.Items.Add(aresta);
            }
        }

        #endregion

        #region "EVENTOS"

        private void AdicionePonto(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = double.Parse(caixaDeTextoX.Text);
                var y = double.Parse(caixaDeTextoY.Text);
                var z = double.Parse(caixaDeTextoZ.Text);

                _PlanoCartesiano.AdicionePonto(x, y, z);

                Controlador.AdicionePonto(x, y, z);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void AdicioneAresta(object sender, RoutedEventArgs e)
        {
            try
            {
                var primeiroPonto = (Ponto)pontosListBox.SelectedItem;
                var ultimoPonto = (Ponto)pontosSecundariosListBox.SelectedItem;

                _PlanoCartesiano.AdicioneLinha(primeiroPonto, ultimoPonto);

                Controlador.AdicioneAresta(primeiroPonto, ultimoPonto);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void Translade(object sender, RoutedEventArgs e)
        {
            try
            {
                var deslocamentoX = double.Parse(deslocamentoXTextBox.Text);
                var deslocamentoY = double.Parse(deslocamentoYTextBox.Text);
                var deslocamentoZ = double.Parse(deslocamentoZTextBox.Text);

                Controlador.Translade(deslocamentoX, deslocamentoY, deslocamentoZ);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void Rotacione(object sender, RoutedEventArgs e)
        {
            try
            {
                var angulo = double.Parse(anguloTextBox.Text);

                var eixo = (EnumCoordenadas)eixosComboBox.SelectedItem;

                Controlador.Rotacione(eixo, angulo);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void AtualizeComponentes()
        {
            eixosComboBox.ItemsSource = new []{ EnumCoordenadas.X, EnumCoordenadas.Y, EnumCoordenadas.Z };
        }

        #endregion

        private void CliqueBotaoEsquerdo(object sender, MouseButtonEventArgs e)
        {
            var coordenada = e.GetPosition(this);

            Controlador.SelecionePonto(coordenada);
        }
    }
}
