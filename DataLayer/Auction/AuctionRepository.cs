using System.Data;
using Classes.AuctionCard;
using Classes.Bids;

namespace DataLayer.Auction {

    public class AuctionRepository: IAuctionRepository {
        private ISqlDataAccess db;
        private PhotoAuctionRepository par;

        private BidRepository br;
        public AuctionRepository(ISqlDataAccess data)
        {
            db = data;
            par = new PhotoAuctionRepository(data);
            br = new BidRepository(data);
        }

    public async Task<AuctionCard> Find(int id) {
        string leilaoSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio AS DataInicio, Data_hora_fim AS DataFim, estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao WHERE leilao_id = @Id";
        List<AuctionCard> auctionList = await db.LoadData<AuctionCard, dynamic>(leilaoSql, new { Id = id }); // forma diferente de fazer isto

        if (auctionList.Count > 0)
        {
            AuctionCard auction = auctionList[0];
            List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);
            auction.Images = fotosLeilao;

            Bid maiorLicitacao = await br.FindHighestBid(auction.IdLeilao);
            auction.Maior_licitacao = maiorLicitacao;

            return auction;
        } else {
            throw new InvalidOperationException();
        }
    }

        public async Task<List<AuctionCard>> FindAll()
        {
            string leiloesSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao";
            List<AuctionCard> auctionList = await db.LoadData<AuctionCard, dynamic>(leiloesSql, new { });

            foreach (var auction in auctionList)
            {
                // Console.WriteLine("Got auction from DB " +  auction.ToString());
                List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);
                // Console.WriteLine("Got number of images " + fotosLeilao.Count + "for leilaoID: " + auction.IdLeilao);

                auction.Images = fotosLeilao;

                Bid maiorLicitacao = await br.FindHighestBid(auction.IdLeilao);
                // Console.WriteLine("Got biggest bid " + maiorLicitacao.Valor + "for leilaoID: " + auction.IdLeilao);
                auction.Maior_licitacao = maiorLicitacao;
            }

            return auctionList;
        }

        public async Task<List<AuctionCard>> SearchAuctions(string inputQuery)
        {
            string procedureName = "SearchAuctionsWithInput";

            List<AuctionCard> auctionList = await db.ExecuteProcedure<AuctionCard, dynamic>(procedureName, new {SearchTerm = inputQuery});

            // Console.WriteLine("Got number of auctions " + auctionList.Count);
            foreach (var auction in auctionList)
            {
                // Console.WriteLine("Got auction from DB " +  auction.ToString());
                List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);

                auction.Images = fotosLeilao;

                Bid maiorLicitacao = await br.FindHighestBid(auction.IdLeilao);
                // Console.WriteLine("Got biggest bid " + maiorLicitacao.Valor + "for leilaoID: " + auction.IdLeilao);
                auction.Maior_licitacao = maiorLicitacao;
            }

            return auctionList;
        }

        public Task<AuctionCard> Update(AuctionCard card) {
            throw new NotImplementedException();
        }
        public Task Remove(int id) {
            throw new NotImplementedException();
        }
    }
}