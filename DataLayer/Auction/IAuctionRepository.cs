using Classes.AuctionCard;

namespace DataLayer.Auction {
    public interface IAuctionRepository {
        Task<AuctionCard> Find(int id);
        Task<List<AuctionCard>> FindAll();
        Task<List<AuctionCard>> FindAllFromUserInState(int userId, AuctionStatus estado);
        Task<List<AuctionCard>> SearchAuctions(string inputQuery);
        Task<AuctionCard> Update(AuctionCard card);
        Task Remove(int id);
    } 
}
