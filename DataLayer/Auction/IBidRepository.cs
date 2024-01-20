using Classes.Bids;

namespace DataLayer.Auction {
    public interface IBidRepository {
		Task<Bid> Find(int id_licitacao);
		Task<int> createBid(Bid licitacao);
		Task<Bid> FindHighestBid(int IdLeilao);
	}
}
