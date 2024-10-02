using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("HistoryDetail")]
    public class HistoryDetail : IGameDataType
    {
        [Indexed(Name = "idx_city_date_cargo", Order = 1, Unique = true)]
        public string Date { get; set; }

        public double Income { get; set; }

        public double Spend { get; set; }

        [Indexed(Name = "idx_city_date_cargo", Order = 0, Unique = true)]
        [Indexed("idx_city_cargo", 0)]
        [Indexed("idx_city", 0)]
        public string City { get; set; }

        [Indexed(Name = "idx_city_date_cargo", Order = 2, Unique = true)]
        [Indexed("idx_city_cargo", 1)]
        public string CargoType { get; set; }

        public int Import { get; set; }

        public int Export { get; set; }

        public int Production { get; set; }
    }
}