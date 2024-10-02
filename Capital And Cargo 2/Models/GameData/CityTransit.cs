using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("city_transit")]
    public class CityTransit : IGameDataType
    {
        [PrimaryKey, AutoIncrement]
        [Column("TransitID")]
        public int Id { get; set; }

        [NotNull]
        public string OriginCity { get; set; }

        [NotNull]
        public string DestinationCity { get; set; }

        [NotNull]
        public double Distance { get; set; }

        [NotNull]
        public double Progress { get; set; }

        [NotNull]
        public double ProgressKM { get; set; }

        [NotNull]
        public string CargoType { get; set; }

        [NotNull]
        public int CargoAmount { get; set; }

        [NotNull]
        public string TransportationMethod { get; set; }

        [NotNull]
        public double Price { get; set; }

        [NotNull]
        public double PurchasePrice { get; set; }
    }
}