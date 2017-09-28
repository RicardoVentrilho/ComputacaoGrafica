using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces
{
    public interface ITransformacaoGeometrica<T>
    {
        T Translade(T poliedro, int deslocamentoX, int deslocamentoY, int deslocamentoZ);

        T Escalone(T poliedro, int escalonamentoX, int escalonamentoY, int escalonamentoZ);

        T Rotacione(T poliedro, EnumCoordenadas eixo, double angulo);

        T Cisalhe(T poliedro, Direcao direcao, EnumCoordenadas proporcao);
    }
}
