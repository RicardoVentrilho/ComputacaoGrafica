using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces
{
    public interface ITransformacaoGeometrica<T>
    {
        void Translade(T poliedro, double deslocamentoX, double deslocamentoY, double deslocamentoZ);

        void Escalone(T poliedro, double escalonamentoX, double escalonamentoY, double escalonamentoZ);

        void Rotacione(T poliedro, EnumCoordenadas eixo, double angulo);

        void Cisalhe(T poliedro, Direcao direcao, EnumCoordenadas proporcao);
    }
}
