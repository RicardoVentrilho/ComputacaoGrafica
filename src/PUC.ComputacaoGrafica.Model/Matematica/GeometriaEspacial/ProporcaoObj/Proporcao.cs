namespace PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ProporcaoObj
{
    public class Proporcao
    {
        public Proporcao(double proporcaoX, double proporcaoY, double proporcaoZ)
        {
            X = proporcaoX;
            Y = proporcaoY;
            Z = proporcaoZ;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }
}