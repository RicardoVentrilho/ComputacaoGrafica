using PUC.ComputacaoGrafica.Model.Enumeradores;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PoliedroObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Model.Matematica.GeometriaEspacial.ProporcaoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.CisalhamentoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.EscalonamentoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.Interfaces;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.RotacionamentoObj;
using PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas.TranslacaoObj;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Model.Transformacoes.Geometricas
{
    public class TransformacaoGeometricaDoPoliedro : ITransformacaoGeometrica<Poliedro>
    {
        public void Cisalhe(Poliedro poliedro, Proporcao proporcao, EnumCoordenadas direcao)
        {
            var cisalhamento = Cisalhamento.ObtenhaInstancia(proporcao, direcao);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto3d>();

            foreach (var aresta in poliedro.Arestas)
            {
                var primeiroPonto = cisalhamento.Calcule(aresta.PrimeiroPonto);
                var ultimoPonto = cisalhamento.Calcule(aresta.UltimoPonto);

                var arestaCisalhada = new Aresta(primeiroPonto, ultimoPonto);

                arestas.Add(arestaCisalhada);
            }

            poliedro.LimpeArestas();
            poliedro.Arestas = arestas;

            foreach (var ponto in poliedro.Vertices)
            {
                var pontoCisalhado = cisalhamento.Calcule(ponto);
                pontos.Add(pontoCisalhado);
            }

            poliedro.LimpeVertices();
            poliedro.Vertices = pontos;
        }

        public void Escalone(Poliedro poliedro, double escalonamentoX, double escalonamentoY, double escalonamentoZ)
        {
            var escalonamento = Escalonamento.ObtenhaInstancia(escalonamentoX, escalonamentoY, escalonamentoZ);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto3d>();

            foreach (var aresta in poliedro.Arestas)
            {
                var primeiroPonto = escalonamento.Calcule(aresta.PrimeiroPonto);
                var ultimoPonto = escalonamento.Calcule(aresta.UltimoPonto);

                var arestaEscalonada = new Aresta(primeiroPonto, ultimoPonto);

                arestas.Add(arestaEscalonada);
            }

            poliedro.LimpeArestas();
            poliedro.Arestas = arestas;

            foreach (var ponto in poliedro.Vertices)
            {
                var pontoEscalonado = escalonamento.Calcule(ponto);
                pontos.Add(pontoEscalonado);
            }

            poliedro.LimpeVertices();
            poliedro.Vertices = pontos;
        }

        public void Rotacione(Poliedro poliedro, EnumCoordenadas eixo, double angulo)
        {
            var rotacao = Rotacionamento.ObtenhaInstancia(eixo, angulo);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto3d>();

            foreach (var aresta in poliedro.Arestas)
            {
                var primeiroPonto = rotacao.Calcule(aresta.PrimeiroPonto);
                var ultimoPonto = rotacao.Calcule(aresta.UltimoPonto);

                var arestaRotacionada = new Aresta(primeiroPonto, ultimoPonto);

                arestas.Add(arestaRotacionada);
            }

            poliedro.LimpeArestas();
            poliedro.Arestas = arestas;

            foreach (var ponto in poliedro.Vertices)
            {
                var pontoRotacionado = rotacao.Calcule(ponto);
                pontos.Add(pontoRotacionado);
            }

            poliedro.LimpeVertices();
            poliedro.Vertices = pontos;
        }

        public void Translade(Poliedro poliedro, double deslocamentoX, double deslocamentoY, double deslocamentoZ)
        {
            var translacao = Translacao.ObtenhaInstancia(deslocamentoX, deslocamentoY, deslocamentoZ);

            var arestas = new List<Aresta>();
            var pontos = new List<Ponto3d>();

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
