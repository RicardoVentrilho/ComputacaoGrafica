using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes
{
    public interface ITransformacao
    {
        Ponto Calcule(out Ponto ponto);
    }
}
