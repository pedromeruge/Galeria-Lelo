using Classes.AuctionCard;

namespace DataLayer.Auction {
    public interface IAuctionRepository {
        Task<AuctionCard> Find(int id);
        Task<List<AuctionCard>> FindAll();
        Task<AuctionCard> Update(AuctionCard card);
        Task Remove(int id);
    } 
}
