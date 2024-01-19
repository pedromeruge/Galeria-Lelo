using Classes.AuctionCard;

namespace DataLayer.Auction {

    public class AuctionRepository: IAuctionRepository {
        private ISqlDataAccess db;
        private PhotoAuctionRepository par;
        public AuctionRepository(ISqlDataAccess data)
        {
            db = data;
            par = new PhotoAuctionRepository(data);
        }

    public async Task<AuctionCard> Find(int id) {
        string leilaoSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao WHERE leilao_id = @Id";
        Task<List<AuctionModel>> auctionListTask = db.LoadData<AuctionModel, dynamic>(leilaoSql, new { Id = id }); // forma diferente de fazer isto
        
        List<AuctionModel> auctionList = await auctionListTask;

        if (auctionList.Count > 0)
        {
            AuctionModel auction = auctionList[0];
            List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);

            AuctionCard auctionCard = new AuctionCard(
                auction.IdLeilao,
                auction.DataInicio,
                auction.DataFim,
                auction.Leilao_estado,
                auction.Preco_base,
                auction.Custo_envio,
                auction.Nome_artista,
                auction.Prod_comprimento,
                auction.Prod_altura,
                auction.Prod_largura,
                auction.Prod_tipo,
                auction.Prod_estado,
                auction.Prod_tecnica,
                auction.Prod_descricao,
                auction.Prod_nome,
                auction.Prod_peso,
                fotosLeilao,
                auction.IdAdmin
            );

            return auctionCard;
        } else {
            throw new InvalidOperationException();
        }
    }

        public async Task<List<AuctionCard>> FindAll()
        {
            string leiloesSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao";
            Task<List<AuctionModel>> auctionListTask = db.LoadData<AuctionModel, dynamic>(leiloesSql, new { });
            
            List<AuctionModel> auctionList = await auctionListTask;
            List<AuctionCard> auctionCardList = new List<AuctionCard>();

            foreach (var auction in auctionList)
            {
                // Console.WriteLine("Got auction from DB " +  auction.ToString());
                List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);
                // Console.WriteLine("Got number of images " + fotosLeilao.Count + "for leilaoID: " + auction.IdLeilao);

                AuctionCard auctionCard = new AuctionCard(
                    auction.IdLeilao,
                    Convert.ToDateTime(auction.DataInicio),
                    auction.DataFim.ToLocalTime(),
                    auction.Leilao_estado,
                    auction.Preco_base,
                    auction.Custo_envio,
                    auction.Nome_artista,
                    auction.Prod_comprimento,
                    auction.Prod_altura,
                    auction.Prod_largura,
                    auction.Prod_tipo,
                    auction.Prod_estado,
                    auction.Prod_tecnica,
                    auction.Prod_descricao,
                    auction.Prod_nome,
                    auction.Prod_peso,
                    fotosLeilao,
                    auction.IdAdmin
                );

                auctionCardList.Add(auctionCard);
            }

            return auctionCardList;
        }

        public Task<AuctionCard> Update(AuctionCard card) {
            throw new NotImplementedException();
        }
        public Task Remove(int id) {
            throw new NotImplementedException();
        }
    }
}