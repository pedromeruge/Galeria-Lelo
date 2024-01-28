

namespace Classes.AuctionCard
{
    public enum AuctionStatus
    {
        em_leilao,
        por_pagar,
        por_enviar,
        por_entregar,
        concluido
    }

    public enum ProdTipo
    {
        desenho,
        escultura,
        pintura,
        fotografia,
        outro
    }

    public enum ProdEstado
    {
        excelente,
        bom,
        mau,
        pessimo
    }
    
    public static class EnumExtensions
    {
        public static string ToTitleCase(this Enum enumValue)
        {
            string value = enumValue.ToString().ToLower();
            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}