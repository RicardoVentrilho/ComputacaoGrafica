namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj
{
    public class Ponto
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Ponto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Ponto primeiroPonto, Ponto segundoPonto) =>
            primeiroPonto.Equals(segundoPonto);

        public static bool operator !=(Ponto primeiroPonto, Ponto segundoPonto) => 
            !primeiroPonto.Equals(segundoPonto);

        public override bool Equals(object obj)
        {
            if (obj is Ponto)
            {
                var ponto = (Ponto)obj;

                return ponto.X == X && ponto.Y == Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X * 6553 + Y * 7993;
        }
    }
}