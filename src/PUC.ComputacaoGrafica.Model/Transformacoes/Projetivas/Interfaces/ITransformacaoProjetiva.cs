using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces
{
    public interface ITransformacaoProjetiva<T>
    {
        T ProjeteUmPlanarPerspectivo(Poliedro poliedro, double dPonto, EnumPlano plano);

        T ProjeteUmAxiomaIsometrico(Poliedro poliedro, Ponto3d ponto, EnumPlano plano);
    }
}
