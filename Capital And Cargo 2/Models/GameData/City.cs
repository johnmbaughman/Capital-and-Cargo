using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData;

[Table("cities")]
public class City : IGameDataType
{
    [PrimaryKey, AutoIncrement]
    [Column("ID")]
    public int Id { get; set; }

    [Column("City")]
    [NotNull]
    public string Name { get; set; }

    [NotNull]
    public double Latitude { get; set; }

    [NotNull]
    public double Longitude { get; set; }

    [NotNull]
    public string Continent { get; set; }

    [NotNull]
    public string Country { get; set; }

    [NotNull]
    public int Imported { get; set; }

    [NotNull]
    public int Exported { get; set; }

    [NotNull]
    public int Bought { get; set; }

    [NotNull]
    public int Sold { get; set; }

    public bool Unlocked { get; set; }

    public bool AutoSellProducedUnlocked { get; set; }

    public bool AutoSellImportedUnlocked { get; set; }

    public bool AutoExportUnlocked { get; set; }

}