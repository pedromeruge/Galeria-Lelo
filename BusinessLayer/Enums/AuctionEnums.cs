namespace app.BusinessLayer.Enums
{
    public enum AuctionStatus
    {
        EmLeilao,
        PorPagar,
        PorEnviar,
        PorEntregar,
        Concluido
    }

    public enum ProdTipo
    {
        Desenho,
        Escultura,
        Pintura,
        Fotografia,
        Outro
    }

    public enum ProdEstado
    {
        Excelente,
        Bom,
        Mau,
        Pessimo
    }
}