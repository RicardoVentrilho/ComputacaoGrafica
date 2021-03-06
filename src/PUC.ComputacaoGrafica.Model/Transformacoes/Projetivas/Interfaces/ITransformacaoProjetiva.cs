﻿using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces
{
    public interface ITransformacaoProjetiva<T>
    {
        T ProjeteUmPlanarPerspectivo(T poliedro, Ponto3d ponto, EnumPlano plano);

        T CalculeUmAxiomaIsometrico(T poliedro);
    }
}
