using System;
using System.Text.Json.Serialization;
using app.BusinessLayer.Enums;

namespace app.BusinessLayer.Classes;

public class AuctionCard
{
    public int idLeilao { get; }
    public DateTime dataInicio { get; }
    public DateTime dataFim { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AuctionStatus leilao_estado { get; }
    public float preco_base { get; }
    public float custo_envio { get; }
    public string nome_artista { get; }
    public float prod_comprimento { get; }
    public float prod_altura { get; }
    public float prod_largura { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProdTipo prod_tipo { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProdEstado prod_estado { get; }
    public string prod_tecnica { get; }
    public string prod_descricao { get; }
    public string prod_nome { get; }
    public float prod_peso { get; }
    public string? image { get; } //temporario
    public int idAdmin { get; }

    public AuctionCard(int idLeilao, DateTime dataInicio, DateTime dataFim, AuctionStatus leilao_estado,
        float preco_base, float custo_envio, string nome_artista, float prod_comprimento, float prod_altura,
        float prod_largura, ProdTipo prod_tipo, ProdEstado prod_estado, string prod_tecnica, string prod_descricao,
        string prod_nome, float prod_peso, string image, int idAdmin)
    {
        this.idLeilao = idLeilao;
        this.dataInicio = dataInicio;
        this.dataFim = dataFim;
        this.leilao_estado = leilao_estado;
        this.preco_base = preco_base;
        this.custo_envio = custo_envio;
        this.nome_artista = nome_artista;
        this.prod_comprimento = prod_comprimento;
        this.prod_altura = prod_altura;
        this.prod_largura = prod_largura;
        this.prod_tipo = prod_tipo;
        this.prod_estado = prod_estado;
        this.prod_tecnica = prod_tecnica;
        this.prod_descricao = prod_descricao;
        this.prod_nome = prod_nome;
        this.prod_peso = prod_peso;
        this.image = image;
        this.idAdmin = idAdmin;
    }
}