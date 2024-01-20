using Classes.Bids;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DataLayer.Auction {

    public class BidRepository : IBidRepository {
		private ISqlDataAccess db;

		public BidRepository(ISqlDataAccess data)
        {
            db = data;
        }

		public async Task<Bid> Find(int id_licitacao) {
			const string bidSQL = "SELECT valor AS Valor, data_hora AS DataHora, sessao_id AS IdSessao, leilao_id AS IdLeilao FROM Licitacao WHERE licitacao_id = @Id";
			List<Bid> bidList = await db.LoadData<Bid, dynamic>(bidSQL, new { Id = id_licitacao });
			if (bidList.Count > 0)
			{
				Bid licitacao = bidList[0];
				licitacao.IdLicitacao = id_licitacao;
				return licitacao;
			} else {
				return null;
			}
		}

		public async Task<int> createBid(Bid licitacao) {

			const string bidSQL = "INSERT INTO Licitacao (valor, data_hora, sessao_id, leilao_id) OUTPUT INSERTED.licitacao_id VALUES (@Valor, @DataHora, @SessaoId, @LeilaoId)";// data fim ignorada
			DateTime data = DateTime.Now;
			try {
				int id = await db.ExecuteScalar<dynamic>(bidSQL, new {
					Valor = licitacao.Valor,
					DataHora = licitacao.DataHora,
					SessaoId = licitacao.IdSessao,
					LeilaoId = licitacao.IdLeilao
				});

				Console.WriteLine($"Criada licitacao para a sessao_id={licitacao.IdSessao} , leilao_id={licitacao.IdLeilao}");
				return id;
			} catch (System.NullReferenceException e) {
				Console.WriteLine($"Error creating big; {e}");
				return -1;
			}
		}

		public async Task<Bid> FindHighestBid(int IdLeilao)
        {
            const string bidSQL = "SELECT TOP 1 licitacao_id AS IdLicitacao, valor AS Valor, data_hora AS DataHora, sessao_id AS IdSessao, leilao_id AS IdLeilao FROM Licitacao WHERE leilao_id=@Id ORDER BY valor DESC";

            List<Bid> bidList = await db.LoadData<Bid, dynamic>(bidSQL, new {Id = IdLeilao});
			if (bidList.Count > 0)
			{
				Bid licitacao = bidList[0];
				return licitacao;
			} else {
				return null;
			}
        }
	}
}
