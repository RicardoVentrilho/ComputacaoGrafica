namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces
{
    public interface ITransformacaoProjetiva<T>
    {
        T ProjeteUmAxiomaIsometrico();

        T ProjeteUmPlanarPerspectivo();
    }
}
