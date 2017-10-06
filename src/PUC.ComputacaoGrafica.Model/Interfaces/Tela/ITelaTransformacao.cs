using System.Windows;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Tela
{
    public interface ITelaTransformacao
    {
        void AdicioneAresta(Aresta aresta);

        void AtualizePlanoCartesiano(PoliedroProxy poliedro);

        void AtualizeArestas(PoliedroProxy poliedro);

        Point ConvertaPonto3dPara2d(Ponto3d ponto3d);

        void AtualizePontoSelecionado(Ponto3d ponto);

        void AdicionePoliedro(PoliedroProxy poliedroProjetado);
    }
}
