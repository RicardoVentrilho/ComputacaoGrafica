using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using PUC.ComputacaoGrafica.Controller.cs.Controladores;

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

        private void AdicionePonto(object sender, RoutedEventArgs e)
        {
            var x = double.Parse(PontoWindow.caixaDeTextoX.Text);
            var y = double.Parse(PontoWindow.caixaDeTextoY.Text);
            var z = double.Parse(PontoWindow.caixaDeTextoZ.Text);

            Controlador.AdicionePonto(x, y, z);
        }

        private void AdicioneAresta(object sender, RoutedEventArgs e)
        {
            Controlador.AdicioneAresta();
        }

        private void Translade(object sender, RoutedEventArgs e)
        {
            Controlador.Translade(0, 0, 0);
        }
    }
}
