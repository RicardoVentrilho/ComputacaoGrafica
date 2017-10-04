using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ProporcaoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces
{
    public interface ITransformacaoGeometrica<T>
    {
        void Translade(T poliedro, double deslocamentoX, double deslocamentoY, double deslocamentoZ);

        void Escalone(T poliedro, double escalonamentoX, double escalonamentoY, double escalonamentoZ);

        void Rotacione(T poliedro, EnumCoordenadas eixo, double angulo);

        void Cisalhe(T poliedro, Proporcao proporcao, EnumCoordenadas direcao);
    }
}
