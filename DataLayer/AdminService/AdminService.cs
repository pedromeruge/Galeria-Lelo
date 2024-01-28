using Classes.Admin;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Classes.AuctionCard;

namespace DataLayer.AdminService {

    public class AdminService : IAdminService {
		private ISqlDataAccess db;

		public AdminService(ISqlDataAccess data)
        {
            db = data;
        }

		public async Task<Admin> getAdmin(string email) {
			const string adminSQL = "SELECT admin_id, email, pass_hash FROM Administrador WHERE email = @Email";
			List<Admin> adminList = await db.LoadData<Admin, dynamic>(adminSQL, new { Email = email });
			if (adminList.Count > 0)
			{
				Admin admin = adminList[0];
				return admin;
			} else {
				return null;
			}
		}

		public async Task<bool> checkAdminValid(Admin admin) {
			Admin dbAdmin = await getAdmin(admin.email);
			if (dbAdmin != null && admin.pass_hash == dbAdmin.pass_hash) {
				return true;
			}
			return false;
		}

		public async Task<float> getLucroEntre(DateTime start, DateTime end) {
			string functionName = "DECLARE @Result DECIMAL(10, 2); SET @Result = dbo.GetLucrosEntre(@DataInicio, @DataFim); SELECT @Result AS TotalProfit;";
            return (float) await db.ExecuteScalar2<dynamic>(functionName, new {DataInicio = start, DataFim = end});
		}

		public async Task<int> getNumeroLeiloesConcluidosEntre(DateTime start, DateTime end) {
			string SQL = "SELECT COUNT(leilao_id) FROM Leilao WHERE Data_hora_fim >= @DataInicio AND Data_hora_fim <= @DataFim";
			return await db.ExecuteScalar<dynamic>(SQL, new {DataInicio = start, DataFim = end});

		}
		public async Task<int> getNumeroLeiloesIniciadosEntre(DateTime start, DateTime end) {
			string SQL = "SELECT COUNT(leilao_id) FROM Leilao WHERE Data_hora_inicio >= @DataInicio AND Data_hora_inicio <= @DataFim";
			return await db.ExecuteScalar<dynamic>(SQL, new {DataInicio = start, DataFim = end});
		}

		public async Task<float> getLucroMedioEntre(DateTime start, DateTime end) {
			string functionName = "DECLARE @Result DECIMAL(10, 2); SET @Result = dbo.GetMediaLucrosEntre(@DataInicio, @DataFim); SELECT @Result AS TotalProfit;";
			// esta funcao funciona mas vai truncar para um int, nao sei resolver nao vejo onde esta a API que retorna float, por agora tbm nao interessa
            return (float)await db.ExecuteScalar2<dynamic>(functionName, new {DataInicio = start, DataFim = end});
		}

		public async Task<int> getNumeroNovosUsersEntre(DateTime start, DateTime end) {
			string newUsersSQL = "SELECT COUNT(user_id) FROM Utilizador WHERE data_registo >= @DataInicio AND data_registo <= @DataFim";
			return await db.ExecuteScalar<dynamic>(newUsersSQL, new {DataInicio = start, DataFim = end});
		}
		public async Task<int> getNumeroLoginsEntre(DateTime start, DateTime end) {
			string loginsSQL = "SELECT COUNT(sessao_id) FROM Sessao WHERE data_hora_inicio >= @DataInicio AND data_hora_fim <= @DataFim";
			return await db.ExecuteScalar<dynamic>(loginsSQL, new {DataInicio = start, DataFim = end});
		}

		public async Task<float> getMediaLicitacaoFinalEntre(DateTime start, DateTime end) {
			string functionName = "DECLARE @Result DECIMAL(10, 2); SET @Result = dbo.GetMediaLicitacoesEntre(@DataInicio, @DataFim); SELECT @Result AS TotalProfit;";
            return (float)await db.ExecuteScalar2<dynamic>(functionName, new {DataInicio = start, DataFim = end});
		}

		public async Task<ProdTipo?> getTipoMaisPopularEntre(DateTime start, DateTime end) {
			try {
				string functionName = "DECLARE @Result VARCHAR(10); SET @Result = dbo.GetTipoMaisPopularEntre(@DataInicio, @DataFim); SELECT @Result;";
				string result = await db.ExecuteScalar3<dynamic,string>(functionName, new {DataInicio = start, DataFim = end});
				Console.WriteLine("got tipoMaisPopular:" + result);
				if (string.IsNullOrEmpty(result)) {
					return null;
				}
				Enum.TryParse<ProdTipo>(result, out ProdTipo tipo);
				return tipo;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteScalar: {ex.Message}");
                throw;
            }
		}

		public async Task<ProdEstado?> getEstadoMaisPopularEntre(DateTime start, DateTime end) {
			try {
				string functionName = "DECLARE @Result VARCHAR(10); SET @Result = dbo.GetEstadoMaisPopularEntre(@DataInicio, @DataFim); SELECT @Result;";
				string result = await db.ExecuteScalar3<dynamic,string>(functionName, new {DataInicio = start, DataFim = end});
				Console.WriteLine("got estadoMaisPopular:" + result);
				if (string.IsNullOrEmpty(result)) {
					return null;
				}
				Enum.TryParse<ProdEstado>(result, out ProdEstado tipo);
				return tipo;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteScalar: {ex.Message}");
                throw;
            }
		}
	}
}
