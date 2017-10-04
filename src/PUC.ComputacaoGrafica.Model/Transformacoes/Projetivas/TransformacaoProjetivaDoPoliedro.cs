using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;
using System;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas
{
    public class TransformacaoProjetivaDoPoliedro : ITransformacaoProjetiva<Poliedro>
    {
        public Poliedro ProjeteUmAxiomaIsometrico()
        {
            throw new NotImplementedException();
        }

        public Poliedro ProjeteUmPlanarPerspectivo()
        {
            throw new NotImplementedException();
        }
    }
}
