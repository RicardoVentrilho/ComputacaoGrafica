using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.View.Adaptadores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using System;

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
            LimpaPlanoCartesiano();

            var linhas = ScreenSpaceLines3DAdapter.Adapte(poliedro);

            foreach (var linha in linhas)
            {
                planoCartesiano.Children.Add(linha);
            }
        }

        #endregion

        #region "EVENTOS"

        private void AdicionePonto(object sender, RoutedEventArgs e)
        {
            var x = double.Parse(caixaDeTextoX.Text);
            var y = double.Parse(caixaDeTextoY.Text);
            var z = double.Parse(caixaDeTextoZ.Text);

            Controlador.AdicionePonto(x, y, z);
        }

        private void AdicioneAresta(object sender, RoutedEventArgs e)
        {
            var primeiroPonto = (Ponto)pontosListBox.SelectedItem;
            var ultimoPonto = (Ponto)pontosSecundariosListBox.SelectedItem;

            Controlador.AdicioneAresta(primeiroPonto, ultimoPonto);
        }

        private void Translade(object sender, RoutedEventArgs e)
        {
            var deslocamentoX = double.Parse(deslocamentoXTextBox.Text);
            var deslocamentoY = double.Parse(deslocamentoYTextBox.Text);
            var deslocamentoZ = double.Parse(deslocamentoZTextBox.Text);

            Controlador.Translade(deslocamentoX, deslocamentoY, deslocamentoZ);
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void LimpaPlanoCartesiano()
        {
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
    }
}
