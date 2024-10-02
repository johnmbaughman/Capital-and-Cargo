using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("factories")]
    public class Factory : IGameDataType
    {
        [Column("CityName")]
        [Indexed("factory_citycargo", 0)]
        [NotNull]
        public string Name { get; set; }

        [Column("CargoType")]
        [Indexed("factory_citycargo", 1)]
        [NotNull]
        public string Type { get; set; }

        [NotNull]
        public int Level { get; set; }

        [NotNull]
        public int AmountProduced { get; set; }

        public int ProductionBonus { get; set; }

        public bool AutoSellProduced { get; set; }

        public bool AutoSellImported { get; set; }

        public bool AutoExport { get; set; }

        public bool AutoExportDestination { get; set; }

        public bool AutoExportTreshold { get; set; }

        public bool AutoExportUseTruck { get; set; }
    }
}