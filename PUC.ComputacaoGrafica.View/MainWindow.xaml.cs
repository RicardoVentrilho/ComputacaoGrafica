using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var poliedro = new Poliedro(null, null, null);

            Controlador.Desenhe(poliedro);
        }
    }
}
