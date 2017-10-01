using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using System;
using System.Windows.Media.Media3D;
using _3DTools;
using System.Windows.Media;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using System.Windows.Controls;

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
            Controlador.Translade(0, 0, 0);
        }

        public void AtualizeTela()
        {
            throw new NotImplementedException();
        }

        public void AdicionePonto(Ponto ponto)
        {
            pontos.Items.Add(ponto);
            pontosSecundarios.Items.Add(ponto);
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
            var ponto = pontos.SelectedItem;

            var pontoSecudario = pontosSecundarios.SelectedItem;

            Controlador.AdicioneAresta(ponto, pontoSecudario);
        }

        private void RemovePontoDaListBoxPontosSecundarios(object sender, SelectionChangedEventArgs e)
        {
            var ponto = pontos.SelectedItem;

            var itens = Controlador.ObtenhaPonto();

            pontosSecundarios.Items.Clear();

            foreach (var item in itens)
            {
                pontosSecundarios.Items.Add(item);
            }

            pontos.Items.Remove(ponto);
        }

        private void RemovePontoDaListBoxPontos(object sender, SelectionChangedEventArgs e)
        {
            var ponto = pontosSecundarios.SelectedItem;

            var itens = Controlador.ObtenhaPonto();

            pontos.Items.Clear();

            foreach (var item in itens)
            {
                pontos.Items.Add(item);
            }

            pontos.Items.Remove(ponto);
        }
    }
}
