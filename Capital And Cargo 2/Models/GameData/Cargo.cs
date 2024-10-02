using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData;

[Table("cargoTypes")]
public class Cargo : IGameDataType
{
    [PrimaryKey, AutoIncrement]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CargoType")]
    [NotNull]
    public string Type { get; set; }

    [NotNull]
    public string Unit { get; set; }

    [NotNull]
    public double BasePrice { get; set; }

    [NotNull]
    public double MinPrice { get; set; }

    [NotNull]
    public double MaxPrice { get; set; }

    [NotNull]
    public double BaseFactoryPrice { get; set; }

    [NotNull]
    public double BaseFactoryProduction { get; set; }

    public bool Unlocked { get; set; }
}