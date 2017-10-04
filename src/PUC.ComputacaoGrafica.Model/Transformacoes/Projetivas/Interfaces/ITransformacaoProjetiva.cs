using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces
{
    public interface ITransformacaoProjetiva<T>
    {
        T ProjeteUmAxiomaIsometrico();

        T ProjeteUmPlanarPerspectivo(Poliedro poliedro, double dPonto, EnumPlano plano);
    }
}
