using System.Collections.Generic;
using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.ParalelaAxiometricaObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas.PlanarPerspectivoObj;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Projetivas
{
    public class TransformacaoProjetivaDoPoliedro : ITransformacaoProjetiva<PoliedroProxy>
    {
        public PoliedroProxy ProjeteUmAxiomaIsometrico(PoliedroProxy poliedro, Ponto3d ponto3d, EnumPlano plano)
        {
            var planarPerspectivo = ParalelaAxiometricaIsometrica.ObtenhaInstancia(ponto3d, plano);

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

        public PoliedroProxy ProjeteUmPlanarPerspectivo(PoliedroProxy poliedro, double dPonto, EnumPlano plano)
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
