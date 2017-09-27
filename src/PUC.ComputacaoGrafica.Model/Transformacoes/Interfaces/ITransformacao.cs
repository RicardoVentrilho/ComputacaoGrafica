namespace PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces
{
    public interface ITransformacao<T>
    {
        T Calcule(T elemento);
    }
}
