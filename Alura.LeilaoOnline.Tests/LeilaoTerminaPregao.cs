using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
            double valorEsperado, 
            double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            var leilao = new Leilao("Van Matheus");

            //Assert
            var exceptionResult = Assert.Throws<System.InvalidOperationException>(() =>
                //Act - método sob teste
                leilao.TerminaPregao()
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado";
            Assert.Equal(msgEsperada, exceptionResult.Message);
            //try
            //{
            //    //Act - método sob teste
            //    leilao.TerminaPregao();
            //}
            //catch(System.Exception e)
            //{

            //    //Assert
            //    Assert.IsType<System.InvalidCastException>(e);
            //}
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
