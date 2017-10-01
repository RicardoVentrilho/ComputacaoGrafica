using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;

namespace PUC.ComputacaoGrafica.Model.Interfaces.Controladores
{
    public interface IControladorTransformacao
        : ITransformacaoGeometrica<Poliedro>, ITransformacaoProjetiva<Poliedro>
    {
        void Desenhe();

        void AdicionePonto(double x, double y, double z);
    }
}
