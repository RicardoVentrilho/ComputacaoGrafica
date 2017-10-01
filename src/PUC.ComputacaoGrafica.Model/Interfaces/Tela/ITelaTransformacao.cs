using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Tela
{
    public interface ITelaTransformacao
    {
        void AtualizeTela();

        void AdicionePonto(Ponto ponto);
    }
}
