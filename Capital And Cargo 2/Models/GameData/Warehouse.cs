using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("warehouse")]
    public class Warehouse : IGameDataType
    {
        [Column("CityName")]
        [NotNull]
        public string Name { get; set; }

        [Column("CargoType")]
        [NotNull]
        public string Type { get; set; }

        [NotNull]
        public int Amount { get; set; }

        [NotNull]
        public double PurchasePrice { get; set; }
    }
}