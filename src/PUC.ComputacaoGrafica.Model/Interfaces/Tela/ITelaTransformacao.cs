using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using System.Windows;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Tela
{
    public interface ITelaTransformacao
    {
        void AdicioneAresta(Aresta aresta);

        void AtualizePlanoCartesiano(Poliedro poliedro);

        void AtualizeArestas(Poliedro poliedro);

        Point ConvertaPonto3dPara2d(Ponto3d ponto3d);

        void AtualizePontoSelecionado(Ponto3d ponto);
    }
}
