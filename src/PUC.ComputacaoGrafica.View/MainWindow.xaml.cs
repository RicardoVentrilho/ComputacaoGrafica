using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using System;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Windows.Input;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.View.Adaptadores;

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

        private void Translade(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AtualizeTela()
        {
            throw new NotImplementedException();
        }

        public void AdicionePonto(Ponto ponto)
        {
            pontosListBox.Items.Add(ponto);
            pontosSecundariosListBox.Items.Add(ponto);
        }

        public void AdicioneAresta(Aresta aresta)
        {
            arestasListBox.Items.Add(aresta);
        }

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

        private void PlanoCartesianoClique(object sender, MouseEventArgs e)
        {
            var posicao = e.GetPosition(planoCartesiano);
        }

        private void ArestasListBoxDuploClique(object sender, MouseButtonEventArgs e)
        {
            var aresta = (Aresta)arestasListBox.SelectedItem;

            var linha = ScreenSpaceLines3DAdapter.Adapte(aresta);

            planoCartesiano.Children.Add(linha);
        }
    }
}
