using System;
using PUC.ComputacaoGrafica.Infraestrutura.Matematica.GeometriaEspacial.PontoObj;
using PUC.ComputacaoGrafica.Persistencia.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PUC.ComputacaoGrafica.Persistencia.Repositorio
{
    public class RepositorioPonto : IRepositorio<Ponto>, IDisposable
    {
        private static RepositorioPonto _Instancia;

        private IDictionary<int, Ponto> _Dicionario;

        private RepositorioPonto()
        {
            _Dicionario = new Dictionary<int, Ponto>();
        }

        public static RepositorioPonto ObtenhaInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new RepositorioPonto();
            }

            return _Instancia;
        }

        public void Apague(Ponto elemento)
        {
            var codigo = elemento.GetHashCode();

            _Dicionario.Remove(codigo);
        }

        public void Cadastre(Ponto elemento)
        {
            var codigo = elemento.GetHashCode();

            _Dicionario.Add(codigo, elemento);
        }

        public IList<Ponto> Consulte(Func<Ponto, bool> filtro)
        {
            return _Dicionario.Values.ToList().Where(filtro).ToList();
        }

        public void Dispose()
        {
        }
    }
}
