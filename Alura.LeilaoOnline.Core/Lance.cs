using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor do lançe não pode ser nagativo");
            }
            Cliente = cliente;
            Valor = valor;
        }
    }
}
