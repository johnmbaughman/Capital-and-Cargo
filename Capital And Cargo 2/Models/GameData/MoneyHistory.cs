using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("MoneyHistory")]
    public class MoneyHistory : IGameDataType
    {
        [NotNull]
        public string Date { get; set; }

        [NotNull]
        public double Money { get; set; }
    }
}