using System;
using PUC.ComputacaoGrafica.Model.Interfaces.Tela;

namespace PUC.ComputacaoGrafica.Controller.cs.Controladores
{
    public class ControladorPoliedro
    {
        public ControladorPoliedro(ITelaTransformacao tela)
        {
            Tela = tela;
        }

        public ITelaTransformacao Tela { get; set; }

        public void AdicionePonto(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public void AdicioneAresta()
        {
            throw new NotImplementedException();
        }
    }
}
