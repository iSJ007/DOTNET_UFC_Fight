using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace UFCFantasyFight.Models
{
    [Table("Ranking")]
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }

        public int OldRankingId { get; set; }

        public string Name { get; set; }


        public int Rank { get; set; }
        [Column(TypeName = "int")]
        [MaxLength(4)]
        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
    }
}