using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;
using System;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas
{
    public class TransformacaoProjetivaDoPoliedro : ITransformacaoProjetiva<Poliedro>
    {
        public Poliedro ProjeteUmAxiomaIsometrico()
        {
            throw new NotImplementedException();
        }

        public Poliedro ProjeteUmPlanarPerspectivo(Poliedro poliedro, double dPonto, EnumPlano plano)
        {
            var planarPerspectivo = PlanarPerspectivo.ObtenhaInstancia(dPonto, plano);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto3d>();

            foreach (var aresta in poliedro.Arestas)
            {
                var primeiroPonto = planarPerspectivo.Calcule(aresta.PrimeiroPonto);
                var ultimoPonto = planarPerspectivo.Calcule(aresta.UltimoPonto);

                var arestaCalculada = new Aresta(primeiroPonto, ultimoPonto);

                arestas.Add(arestaCalculada);
            }

            poliedro.LimpeArestas();
            poliedro.Arestas = arestas;

            foreach (var ponto in poliedro.Vertices)
            {
                var pontoCalculado = planarPerspectivo.Calcule(ponto);
                pontos.Add(pontoCalculado);
            }

            poliedro.LimpeVertices();
            poliedro.Vertices = pontos;

            return poliedro;
        }
    }
}
