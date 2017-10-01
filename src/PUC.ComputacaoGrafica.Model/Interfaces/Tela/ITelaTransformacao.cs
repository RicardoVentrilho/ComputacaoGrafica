using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Tela
{
    public interface ITelaTransformacao
    {
        void AdicionePonto(Ponto ponto);

        void AdicioneAresta(Aresta aresta);

        void AtualizePlanoCartesiano(Poliedro poliedro);

        void AtualizePontos(Poliedro poliedro);

        void AtualizeArestas(Poliedro poliedro);
    }
}
