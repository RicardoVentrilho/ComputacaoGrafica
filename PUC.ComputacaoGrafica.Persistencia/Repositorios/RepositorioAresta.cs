using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.ArestaObj;
using PUC.ComputacaoGrafica.Persistencia.Interfaces;
using System;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Persistencia.Repositorios
{
    public class RepositorioAresta : IRepositorio<Aresta>
    {
        private static RepositorioAresta _Instancia;

        private IDictionary<int, Aresta> _Dicionario;

        private RepositorioAresta()
        {
            _Dicionario = new Dictionary<int, Aresta>();
        }

        public static RepositorioAresta ObtenhaInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new RepositorioAresta();
            }

            return _Instancia;
        }

        public void Apague(Aresta elemento)
        {
            var codigo = elemento.GetHashCode();

            _Dicionario.Remove(codigo);
        }

        public void Cadastre(Aresta elemento)
        {
            var codigo = elemento.GetHashCode();

            _Dicionario.Add(codigo, elemento);
        }

        public IList<Aresta> Consulte(Func<Aresta, bool> filtro)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
