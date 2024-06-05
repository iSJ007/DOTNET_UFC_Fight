using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace UFCFantasyFight.Models
{
    [Table("Fighter")]
    public class Fighter
    {
        [Key]
        public int FighterId { get; set; }

        // [Column(TypeName = "int(4)")]


        public int OldFighterId { get; set; }

        public string FighterName { get; set; }


        public string FighterHeight { get; set; }


        public string FighterWeight { get; set; }


        public string FighterReach { get; set; }


        public string FighterStance { get; set; }


        public string? FighterDob { get; set; }


        [Column(TypeName = "decimal(4,2)")]
        public decimal? FighterSlpm { get; set; }

        [Column(TypeName = "decimal(3,2)")]// nullable decimal
        public decimal? FighterStracc { get; set; }
        [Column(TypeName = "decimal(3,2)")] // nullable decimal


        public decimal? FighterStrdef { get; set; }

        [Column(TypeName = "decimal(4,2)")] // nullable decimal

        public decimal? FighterTdavg { get; set; }

        [Column(TypeName = "decimal(3,2)")] // nullable decimal

        public decimal? FighterTdacc { get; set; }

        [Column(TypeName = "decimal(3,2)")] // nullable decimal

        public decimal? FighterTddef { get; set; }

        [Column(TypeName = "decimal(3,1)")] // nullable decimal

        public decimal? FighterSubavg { get; set; }

        [Column(TypeName = "varchar(33)")] // nullable decimal


        public string FighterNick { get; set; }
        [Column(TypeName = "varchar(17)")]

        public string FighterClass { get; set; }
        [Column(TypeName = "varchar(40)")]

        public string FighterLoc { get; set; }
        [Column(TypeName = "varchar(25)")]

        public string FighterCountry { get; set; }
    }
}