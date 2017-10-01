using System;
using System.Collections.Generic;

namespace PUC.ComputacaoGrafica.Persistencia.Interfaces
{
    public interface IRepositorio<T>
    {
        IList<T> Consulte(Func<T, bool> filtro);

        void Cadastre(T elemento);

        void Apague(T elemento);
    }
}
