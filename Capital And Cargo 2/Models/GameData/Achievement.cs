using CapitalAndCargo2.Interfaces;
using SQLite;

namespace CapitalAndCargo2.Models.GameData
{
    [Table("achievements")]
    public class Achievement : IGameDataType
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public int Id { get; set; }

        [Indexed(Unique = true)]
        [NotNull]
        public string Key { get; set; }

        [NotNull]
        public string Path { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Text { get; set; }

        [NotNull]
        public string RewardText { get; set; }

        [NotNull]
        public int Target { get; set; }

        [Column("checkSql")]
        [NotNull]
        public string CheckSql { get; set; }

        [Column("updateSql")]
        [NotNull]
        public string UpdateSql { get; set; }

        [Column("achieved")]
        [NotNull]
        public bool Achieved { get; set; }

        [Column("achievedDate")]
        [NotNull]
        public DateTime AchievedDate { get; set; }
    }
}