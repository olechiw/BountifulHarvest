using System;
using System.Data.Linq.Mapping;

namespace Common
{
    [Table(Name = "Visits")]
    public class Visit
    {
        [Column] public string Ages;
        [Column] public bool Christmas;

        [Column] public DateTime DateOfVisit;

        [Column] public bool Easter;

        [Column] public string Genders;

        [Column] public bool Halloween;

        [Column] public int PatronID;

        [Column] public bool School;

        [Column] public bool Thanksgiving;

        [Column] public int TotalPounds;

        [Column(IsPrimaryKey = true)] public int VisitID;

        [Column] public bool Winter;
    }
}