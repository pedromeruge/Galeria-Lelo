using System;
using System.Text.Json.Serialization;

namespace Classes.Bids {
    public class Bid {
        public int IdLicitacao {get; set;} = -1;
        public float Valor {get; set; }
        public DateTime DataHora {get; set;}
        public int IdSessao {get; set;}
        public int IdLeilao {get; set;}

        public Bid() {}
        public Bid(float valor, DateTime data, int sessao, int leilao) {
            this.Valor = valor;
            this.DataHora = data;
            this.IdSessao = sessao;
            this.IdLeilao = leilao;
        }

        public override string ToString()
        {
            return $"IdLicitacao: {IdLicitacao}, " +
                   $"Valor: {Valor}, " +
                   $"DataHora: {DataHora}, " +
                   $"IdSessao: {IdSessao}, " +
                   $"IdLeilao: {IdLeilao}";
        }
    }
}