using PUC.ComputacaoGrafica.Controller.Controladores;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;
using System.Windows;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.View.Adaptadores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;

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

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void LimpaPlanoCartesiano()
        {
        }

        #endregion
    }
}
