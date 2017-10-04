using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Controladores
{
    public interface IControladorTransformacao
    {
        void AdicionePonto(double x, double y, double z);
    }
}
