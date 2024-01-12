using System;
using System.Text.Json.Serialization;

namespace app.Components.ClassBlocks.AuctionCard;

public class AuctionCard
{
    public int IdLeilao { get; }
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AuctionStatus Leilao_estado { get; }
    public float Preco_base { get; }
    public float Custo_envio { get; }
    public string Nome_artista { get; }
    public float Prod_comprimento { get; }
    public float Prod_altura { get; }
    public float Prod_largura { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProdTipo Prod_tipo { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProdEstado Prod_estado { get; }
    public string Prod_tecnica { get; }
    public string Prod_descricao { get; }
    public string Prod_nome { get; }
    public float Prod_peso { get; }
    public string Image { get; } //temporario
    public int IdAdmin { get; }

    public AuctionCard(int idLeilao, DateTime dataInicio, DateTime dataFim, AuctionStatus leilao_estado,
        float preco_base, float custo_envio, string nome_artista, float prod_comprimento, float prod_altura,
        float prod_largura, ProdTipo prod_tipo, ProdEstado prod_estado, string prod_tecnica, string prod_descricao,
        string prod_nome, float prod_peso, string image, int idAdmin)
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
        this.Image = image;
        this.IdAdmin = idAdmin;
    }
}