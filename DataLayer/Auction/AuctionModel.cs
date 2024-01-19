using Classes.AuctionCard;

namespace DataLayer.Auction {
    public record AuctionModel {
        public string? _IdLeilao { get; set; }
        public int IdLeilao { get; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public AuctionStatus Leilao_estado { get; }
        public float Preco_base { get; }
        public float Custo_envio { get; }
        public string Nome_artista { get; } = "";
        public float Prod_comprimento { get; }
        public float Prod_altura { get; }
        public float Prod_largura { get; }
        public ProdTipo Prod_tipo { get; }
        public ProdEstado Prod_estado { get; }
        public string Prod_tecnica { get; } = "";
        public string Prod_descricao { get; } = "";
        public string Prod_nome { get; } = "";
        public float Prod_peso { get; }
        public int IdAdmin { get; }

        public override string ToString()
        {
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
                   $"IdAdmin: {IdAdmin}";
        }
    }
}