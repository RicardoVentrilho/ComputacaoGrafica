//-----------------------------------------------------------------------
// <copyright file="TestesDeMatriz.cs" company="PUC Goiás">
//     Copyright © PUC Goiás. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;

namespace PUC.ComputacaoGrafica.Infraestrutura.Matematica.MatrizObj
{
    /// <summary>
    /// TODO: Atualize comentário.
    /// </summary>
    public class Matriz<T>
    {
        private ValidacoesMatriz _Validacao;
        private int[][] _Matriz;

        public short TotalDeColunas { get; set; }

        public short TotalDeLinhas { get; set; }

        public Matriz(int[][] matriz)
        {
            _Validacao = new ValidacoesMatriz();

            _Validacao.AssineRegraDeCriacaoDeMatriz(matriz);

            TotalDeLinhas = (short)matriz.Length;
            TotalDeColunas = (short)matriz.First().Length;

            _Matriz = matriz;
        }

        public static Matriz<T> operator *(Matriz<T> matrizEsquerda, Matriz<T> matrizDireita)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
