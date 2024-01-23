using System;
using System.Text.Json.Serialization;
using Classes.Bids;

namespace Classes.AuctionCard {
    public class AuctionCard
    {
        public int IdLeilao { get; set;}
        public DateTime DataInicio { get; set;}
        public DateTime DataFim { get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AuctionStatus Leilao_estado { get; set;}
        public decimal Preco_base { get; set;}
        public decimal Custo_envio { get; set;}
        public string Nome_artista { get; set;} ="";
        public decimal Prod_comprimento { get; set;}
        public decimal Prod_altura { get; set;}
        public decimal Prod_largura { get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProdTipo Prod_tipo { get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProdEstado Prod_estado { get; set;}
        public string Prod_tecnica { get; set;} = "";
        public string Prod_descricao { get; set;} = "";
        public string Prod_nome { get; set;} ="";
        public decimal Prod_peso { get; set;}
        public List<AuctionPhoto>? Images { get; set;}
        public Bid? Maior_licitacao {get; set;}
        public int IdAdmin { get; set;}

        public AuctionCard() {}
        public AuctionCard(int idLeilao, DateTime dataInicio, DateTime dataFim, AuctionStatus leilao_estado,
            decimal preco_base, decimal custo_envio, string nome_artista, decimal prod_comprimento, decimal prod_altura,
            decimal prod_largura, ProdTipo prod_tipo, ProdEstado prod_estado, string prod_tecnica, string prod_descricao,
            string prod_nome, decimal prod_peso, List<AuctionPhoto> fotos, Bid bid, int idAdmin)
        {
            this.IdLeilao = idLeilao;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
            this.Leilao_estado = leilao_estado;
            this.Preco_base = preco_base;
            this.Custo_envio = custo_envio;
            this.Nome_artista = nome_artista;
            this.Prod_comprimento = prod_comprimento;
            this.Prod_altura = prod_altura;
            this.Prod_largura = prod_largura;
            this.Prod_tipo = prod_tipo;
            this.Prod_estado = prod_estado;
            this.Prod_tecnica = prod_tecnica;
            this.Prod_descricao = prod_descricao;
            this.Prod_nome = prod_nome;
            this.Prod_peso = prod_peso;
            this.Images = fotos;
            this.Maior_licitacao = bid;
            this.IdAdmin = idAdmin;
        }

        public override string ToString()
        {
            decimal maior_bid = Maior_licitacao != null ? Maior_licitacao.Valor : -1;
            return $"IdLeilao: {IdLeilao}, " +
                   $"DataInicio: {DataInicio}, " +
                   $"DataFim: {DataFim}, " +
                   $"Leilao_estado: {Leilao_estado}, " +
                   $"Preco_base: {Preco_base}, " +
                   $"Custo_envio: {Custo_envio}, " +
                   $"Nome_artista: {Nome_artista}, " +
                   $"Prod_comprimento: {Prod_comprimento}, " +
                   $"Prod_altura: {Prod_altura}, " +
                   $"Prod_largura: {Prod_largura}, " +
                   $"Prod_tipo: {Prod_tipo}, " +
                   $"Prod_estado: {Prod_estado}, " +
                   $"Prod_tecnica: {Prod_tecnica}, " +
                   $"Prod_descricao: {Prod_descricao}, " +
                   $"Prod_nome: {Prod_nome}, " +
                   $"Prod_peso: {Prod_peso}, " +
                   $"Maior_licitacao: {maior_bid}, " +
                   $"IdAdmin: {IdAdmin}";
        }
    }
}