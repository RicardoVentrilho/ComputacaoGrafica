using MathNet.Numerics.LinearAlgebra;
using PUC.ComputacaoGrafica.Infraestrutura.Extensoes;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using static PUC.ComputacaoGrafica.Infraestrutura.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.RotacionamentoObj
{
    public class Rotacionamento : ITransformacao<Ponto3d>
    {
        private static Rotacionamento _Instancia = new Rotacionamento(X, 0);

        private Rotacionamento(EnumCoordenadas eixo, double angulo)
        {
            Eixo = eixo;
            Angulo = angulo;
        }

        public EnumCoordenadas Eixo { get; private set; }

        public Matrix<double> MatrizParaRotacionamento { get; private set; }

        public double Angulo { get; private set; }

        public static Rotacionamento ObtenhaInstancia(EnumCoordenadas eixo, double angulo)
        {
            _Instancia.Eixo = eixo;
            _Instancia.Angulo = angulo;

            _Instancia.MatrizParaRotacionamento = FabricaDeRotacionamento.Crie(eixo, angulo);

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizVertical();

            var resultado = MatrizParaRotacionamento * pontoComoMatriz;

            var ponto = resultado.ConvertaVerticalParaPonto();

            return ponto;
        }
    }
}
