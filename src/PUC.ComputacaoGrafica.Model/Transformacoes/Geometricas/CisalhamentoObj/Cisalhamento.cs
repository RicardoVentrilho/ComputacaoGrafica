using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Extensoes;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ProporcaoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using static PUC.ComputacaoGrafica.Model.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.CisalhamentoObj
{
    public class Cisalhamento : ITransformacao<Ponto3d>
    {
        private static readonly Cisalhamento _Instancia = new Cisalhamento(default(Proporcao), X);

        public Cisalhamento(Proporcao direcao, EnumCoordenadas proporcao)
        {
            Direcao = direcao;
            Proporcao = proporcao;
        }

        public Matrix<double> MatrizParaCisalhamento { get; private set; }

        public Proporcao Direcao { get; private set; }

        public EnumCoordenadas Proporcao { get; private set; }

        public static Cisalhamento ObtenhaInstancia(Proporcao proporcao, EnumCoordenadas direcao)
        {
            _Instancia.Direcao = proporcao;
            _Instancia.Proporcao = direcao;

            _Instancia.MatrizParaCisalhamento = DenseMatrix.CreateIdentity(3);

            _Instancia.MatrizParaCisalhamento[(int)direcao, (int)X] = proporcao.X;
            _Instancia.MatrizParaCisalhamento[(int)direcao, (int)Y] = proporcao.Y;
            _Instancia.MatrizParaCisalhamento[(int)direcao, (int)Z] = proporcao.Z;

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizVertical(3);

            var resultado = MatrizParaCisalhamento * pontoComoMatriz;

            var ponto = resultado.ConvertaVerticalParaPonto();

            return ponto;
        }
    }
}