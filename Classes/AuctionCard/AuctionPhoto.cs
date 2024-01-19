using System;
using System.Text.Json.Serialization;

namespace Classes.AuctionCard
{
    public class AuctionPhoto
    {
        public int IdFoto { get; }
        public string Path { get; }

        public AuctionPhoto(int idfoto, string path)
        {
            this.IdFoto = idfoto;
            this.Path = path;
        }
    }
}