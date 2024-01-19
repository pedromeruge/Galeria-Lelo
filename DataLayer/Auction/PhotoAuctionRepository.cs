using Classes.AuctionCard;
using System.Threading.Tasks;

namespace DataLayer.Auction {

    public class PhotoAuctionRepository {
        private ISqlDataAccess db;
        
        public PhotoAuctionRepository(ISqlDataAccess data)
        {
            db = data;
        }
        public async Task<List<AuctionPhoto>> FindAllFromAuction(int id)
        {
            try {
                // Console.WriteLine("Searching photos for auction with id: " + id);
                //obter da base de dados
                string photoSql = "SELECT foto_id AS _IdFoto, foto AS FotoPath, leilao_id AS IdFoto FROM Foto_leilao WHERE leilao_id = @Id";
                Task<List<PhotoAuctionModel>> photoListTask = db.LoadData<PhotoAuctionModel, dynamic>(photoSql, new {Id = id});
                List<PhotoAuctionModel> photoList = await photoListTask;

                List<AuctionPhoto> auctionPhotos = new List<AuctionPhoto>();

                foreach (var photoModel in photoList)
                {
                    // Console.WriteLine("Got this photo info: " + photoModel.ToString());

                    AuctionPhoto auctionPhoto = new AuctionPhoto(
                        photoModel.IdFoto,
                        photoModel.FotoPath
                    );

                    auctionPhotos.Add(auctionPhoto);
                }
                return auctionPhotos;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        
        public async Task<List<AuctionPhoto>> FindAll()
        {
            string photoSql = "SELECT foto_id AS _IdFoto, foto AS FotoPath, leilao_id AS IdFoto FROM Foto_leilao";
 
            Task<List<PhotoAuctionModel>> photoListTask = db.LoadData<PhotoAuctionModel, dynamic>(photoSql, new {});
            List<PhotoAuctionModel> photoList = await photoListTask;

            List<AuctionPhoto> auctionPhotos = new List<AuctionPhoto>();


            foreach (var photoModel in photoList)
            {
                AuctionPhoto auctionPhoto = new AuctionPhoto(
                    photoModel.IdFoto,
                    photoModel.FotoPath ?? ""
                );

                auctionPhotos.Add(auctionPhoto);
            }
            return auctionPhotos;
        }
    }
}