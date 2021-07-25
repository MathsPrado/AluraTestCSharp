using Alura.LeilaoOnline.Core.Interfaces;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        private IModalidadeAvaliacao _avaliador;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca, IModalidadeAvaliacao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            _avaliador = avaliador;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (Estado == EstadoLeilao.LeilaoEmAndamento)
            {
                _lances.Add(new Lance(cliente, valor));
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado";
                throw new System.InvalidOperationException(msgEsperada);
            }
            Ganhador = _avaliador.Avalia(this);
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
