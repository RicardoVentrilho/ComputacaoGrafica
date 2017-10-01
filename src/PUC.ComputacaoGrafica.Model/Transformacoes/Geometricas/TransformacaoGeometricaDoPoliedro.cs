using PUC.ComputacaoGrafica.Infraestrutura.Enumeradores;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.DirecaoObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj;
using System;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public class TransformacaoGeometricaDoPoliedro : ITransformacaoGeometrica<Poliedro>
    {
        public Poliedro Cisalhe(Poliedro poliedro, Direcao direcao, EnumCoordenadas proporcao)
        {
            throw new NotImplementedException();
        }

        public Poliedro Escalone(Poliedro poliedro, int escalonamentoX, int escalonamentoY, int escalonamentoZ)
        {
            throw new NotImplementedException();
        }

        public Poliedro Rotacione(Poliedro poliedro, EnumCoordenadas eixo, double angulo)
        {
            throw new NotImplementedException();
        }

        public void Translade(Poliedro poliedro, double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            var translacao = Translacao.ObtenhaInstancia(deslocamentoX, deslocamentoY, deslocamentoZ);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto>();

            foreach (var aresta in poliedro.Arestas)
            {
                var primeiroPonto = translacao.Calcule(aresta.PrimeiroPonto);
                var ultimoPonto = translacao.Calcule(aresta.UltimoPonto);

                var arestaTransladada = new Aresta(primeiroPonto, ultimoPonto);

                arestas.Add(arestaTransladada);
            }

            poliedro.LimpeArestas();
            poliedro.Arestas = arestas;

            foreach (var ponto in poliedro.Vertices)
            {
                var pontoTransladado = translacao.Calcule(ponto);
                pontos.Add(pontoTransladado);
            }

            poliedro.LimpeVertices();
            poliedro.Vertices = pontos;
        }
    }
}
