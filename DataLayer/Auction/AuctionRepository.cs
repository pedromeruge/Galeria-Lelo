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
        string leilaoSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio AS DataInicio, Data_hora_fim AS DataFim, estado AS Leilao_estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao WHERE leilao_id = @Id";
        List<AuctionCard> auctionList = await db.LoadData<AuctionCard, dynamic>(leilaoSql, new { Id = id }); // forma diferente de fazer isto

        if (auctionList.Count > 0)
        {
            AuctionCard auction = auctionList[0];
            List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);
            auction.Images = fotosLeilao;

            Bid maiorLicitacao = await br.FindHighestBid(auction.IdLeilao);
            auction.Maior_licitacao = maiorLicitacao;
            // Console.WriteLine("Got auction from DB " +  auction.ToString());
            return auction;
        } else {
            throw new InvalidOperationException();
        }
    }

    public async Task<List<AuctionCard>> FindAllFromUserInState(int userId, AuctionStatus estado)
    {
        string procedureName = "FindAllAuctionsFromUserInState";

        // Console.WriteLine($"Giving to procedure values userID: {userId} and estado: {estado}");

        List<AuctionCard> auctionList = await db.ExecuteProcedure<AuctionCard, dynamic>(procedureName, new {User_id = userId, Estado = estado.ToString()});

        // Console.WriteLine("Got number of auctions " + auctionList.Count);
        foreach (var auction in auctionList)
        {
            // Console.WriteLine("Got auction from DB " +  auction.ToString());
            List<AuctionPhoto> fotosLeilao = await par.FindAllFromAuction(auction.IdLeilao);

            auction.Images = fotosLeilao;

            Bid maiorLicitacao = await br.FindHighestBid(auction.IdLeilao);
            auction.Maior_licitacao = maiorLicitacao;
            // Console.WriteLine("Got biggest bid " + maiorLicitacao.Valor + "for leilaoID: " + auction.IdLeilao);
        }

        return auctionList;
    }

        public async Task<List<AuctionCard>> FindAll()
        {
            string leiloesSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio AS DataInicio, Data_hora_fim AS DataFim, estado AS Leilao_estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao";
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

        public async Task<List<AuctionCard>> FindAllInState(AuctionStatus estado)
        {
            string leiloesSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio AS DataInicio, Data_hora_fim AS DataFim, estado AS Leilao_estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao WHERE estado = @Estado";
            List<AuctionCard> auctionList = await db.LoadData<AuctionCard, dynamic>(leiloesSql, new {Estado = estado.ToString()});

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

        // procedure para vendas de admins
        public async Task<List<AuctionCard>> FindAllInStateSortedByStartDate(AuctionStatus estado)
        {
            string leiloesSql = "SELECT leilao_id AS IdLeilao, Data_hora_inicio AS DataInicio, Data_hora_fim AS DataFim, estado AS Leilao_estado, preco_base, custo_envio, prod_nome_artista AS Nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id AS IdAdmin FROM Leilao WHERE estado = @Estado ORDER BY DataInicio DESC, DataFim DESC";
            List<AuctionCard> auctionList = await db.LoadData<AuctionCard, dynamic>(leiloesSql, new {Estado = estado.ToString()});

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

        	public async Task<int> createAuction(AuctionCard auction, List<string> fotos) {
			try {
			    const string auctionSQL = "INSERT INTO Leilao (Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, prod_nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id) OUTPUT INSERTED.leilao_id VALUES (@Data_hora_inicio,@Data_hora_fim,@Estado,@Preco_base,@Custo_envio,@Prod_nome_artista,@Prod_comprimento,@Prod_altura,@Prod_largura,@Prod_tipo,@Prod_estado,@Prod_tecnica,@Prod_descricao,@Prod_nome,@Prod_peso,@Admin_id)";

				int id = await db.ExecuteScalar<dynamic>(auctionSQL, new {
                    Data_hora_inicio = auction.DataInicio,
                    Data_hora_fim = auction.DataFim,
                    Estado = auction.Leilao_estado.ToString(),
                    Preco_base = auction.Preco_base,
                    Custo_envio = auction.Custo_envio,
                    Prod_nome_artista = auction.Nome_artista,
                    Prod_comprimento= auction.Prod_comprimento,
                    Prod_altura= auction.Prod_altura,
                    Prod_largura= auction.Prod_largura,
                    Prod_tipo = auction.Prod_tipo.ToString(),
                    Prod_estado = auction.Prod_estado.ToString(),
                    Prod_tecnica= auction.Prod_tecnica,
                    Prod_descricao= auction.Prod_descricao,
                    Prod_nome= auction.Prod_nome,
                    Prod_peso = auction.Prod_peso,
                    Admin_id = auction.IdAdmin
				});

                const string photoSQL = "INSERT INTO Foto_leilao (foto, leilao_id) VALUES (@Foto_path,@Leilao_id)";
                foreach (var foto in fotos) {
                    await db.ExecuteScalar<dynamic>(photoSQL, new {
                    Foto_path = foto,
                    Leilao_id = id
                    });
                }
				return id;
			} catch (NullReferenceException) {
				return -1;
			}
		}

        public async Task Update(AuctionCard auction) {
			const string sessionSQL = "UPDATE Leilao SET estado=@Leilao_estado WHERE leilao_id=@IdLeilao";
            var parameters = new {Leilao_estado = auction.Leilao_estado.ToString(), IdLeilao = auction.IdLeilao};
		    await db.SaveData(sessionSQL, parameters);
        }

        public Task Remove(int id) {
            throw new NotImplementedException();
        }
    }
}