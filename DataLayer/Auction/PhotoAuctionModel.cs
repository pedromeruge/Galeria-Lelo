namespace DataLayer.Auction {

    public record PhotoAuctionModel {
        public string? _IdFoto { get; init; }
        public int IdFoto { get; init;}
        public string? FotoPath {get; init;}
        public override string ToString() {
            return $"_IdFoto: {_IdFoto},\n" +
                   $"    IdFoto: {IdFoto},\n" +
                   $"    FotoPath: {FotoPath}\n";
        }
    }
}