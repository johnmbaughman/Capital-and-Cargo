using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("Player")]
    public class Player : IGameDataType
    {
        [NotNull]
        public string Date { get; set; }

        [NotNull]
        public double Money { get; set; }

        [Column("productionBonusPool")]
        [NotNull]
        public int ProductionBonusPool { get; set; }


        [Column("displayStartPopup")]
        [NotNull]
        public bool DisplayStartPopup { get; set; }

    }
}