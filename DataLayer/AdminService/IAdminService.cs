using System.Diagnostics.Contracts;
using Classes.Admin;
using Classes.AuctionCard;

namespace DataLayer.AdminService {
    public interface IAdminService {
		Task<Admin> getAdmin(string email);
		Task<bool> checkAdminValid(Admin admin); // ve se email existe e se password bate certo (o resto por agora nao interessa)

		// estatísticas de venda
		Task<float> getLucroEntre(DateTime start, DateTime end);
		Task<int> getNumeroLeiloesConcluidosEntre(DateTime start, DateTime end);
		Task<int> getNumeroLeiloesIniciadosEntre(DateTime start, DateTime end);
		Task<float> getLucroMedioEntre(DateTime start, DateTime end);
		Task<float> getMediaLicitacaoFinalEntre(DateTime start, DateTime end);
		Task<ProdTipo?> getTipoMaisPopularEntre(DateTime start, DateTime end);
		Task<ProdEstado?> getEstadoMaisPopularEntre(DateTime start, DateTime end);


		// estatísticas de crescimento
		Task<int> getNumeroNovosUsersEntre(DateTime start, DateTime end);
		Task<int> getNumeroLoginsEntre(DateTime start, DateTime end);
	}
}

// falta: top 5 vendas com licitação final maior
// falta: nada
// falta: artigos mais vendidos, técnica de artigo mais vendida, localização geográfica mais popular, método de pagamento preferido
