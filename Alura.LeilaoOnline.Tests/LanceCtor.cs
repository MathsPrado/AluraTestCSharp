using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExcepetionDadoValorNegativo()
        {
            //Arranje
            var valor = -100;

            //Assert
            Assert.Throws<System.ArgumentException>(() => new Lance(null, valor));
        }
    }
}
