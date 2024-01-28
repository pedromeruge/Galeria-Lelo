using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using DataLayer; // Assuming this is your namespace for the provided SQL data access class

namespace DataLayer.AuctionUpdateService
{
    public class AuctionUpdateService
    {
        private readonly ISqlDataAccess db;
        private readonly TimeSpan interval = TimeSpan.FromMinutes(15);

        public AuctionUpdateService(ISqlDataAccess sqlDataAccess)
        {
            db = sqlDataAccess;
        }

        public void Start()
        {
            var timer = new Timer(async _ =>
            {
                await UpdateAuctionsAsync();
            }, null, TimeSpan.Zero, interval);
            Console.WriteLine("Começado o timer");
        }

        private async Task UpdateAuctionsAsync()
        {
            try
            {
                string storedProcedureName = "UpdateLeilaoState";
                object parameters = null;

                var result = await db.ExecuteProcedure<object, object>(storedProcedureName, parameters);
                Console.WriteLine($"Ocorreu update, resultados > number: {result.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating auctions: {ex.Message}");
            }
        }
    }
}