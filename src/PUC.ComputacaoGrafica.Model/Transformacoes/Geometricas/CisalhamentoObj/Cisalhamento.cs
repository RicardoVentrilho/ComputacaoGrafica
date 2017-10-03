using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Extensoes;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Interfaces;
using static PUC.ComputacaoGrafica.Infraestrutura.Enumeradores.EnumCoordenadas;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.CisalhamentoObj
{
    public class Cisalhamento : ITransformacao<Ponto3d>
    {
        private static readonly Cisalhamento _Instancia = new Cisalhamento(default(Direcao), EnumCoordenadas.X);

        public Cisalhamento(Direcao direcao, EnumCoordenadas proporcao)
        {
            Direcao = direcao;
            Proporcao = proporcao;
        }

        public Matrix<double> MatrizParaCisalhamento { get; private set; }

        public Direcao Direcao { get; private set; }

        public EnumCoordenadas Proporcao { get; private set; }

        public static Cisalhamento ObtenhaInstancia(Direcao direcao, EnumCoordenadas proporcao)
        {
            _Instancia.Direcao = direcao;
            _Instancia.Proporcao = proporcao;

            _Instancia.MatrizParaCisalhamento = DenseMatrix.CreateIdentity(3);

            _Instancia.MatrizParaCisalhamento[(int)proporcao, (int)X] = direcao.X;
            _Instancia.MatrizParaCisalhamento[(int)proporcao, (int)Y] = direcao.Y;
            _Instancia.MatrizParaCisalhamento[(int)proporcao, (int)Z] = direcao.Z;

            return _Instancia;
        }

        public Ponto3d Calcule(Ponto3d elemento)
        {
            var pontoComoMatriz = elemento.ConvertaParaMatrizVertical();

            var resultado = MatrizParaCisalhamento * pontoComoMatriz;

            var ponto = resultado.ConvertaVerticalParaPonto();

            return ponto;
        }
    }
}