using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UFCFantasyFight.Data;
using UFCFantasyFight.Dtos;
using UFCFantasyFight.Interfaces;
using UFCFantasyFight.Models;
using Microsoft.EntityFrameworkCore;
namespace UFCFantasyFight.Repository
{
    public class FighterRepository : IFighterRepository
    {
        private readonly ApplicationDbContext _context;
        public FighterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Fighter?> GetByIdAsync(int id)
        {
            return await _context.Fighter.FirstOrDefaultAsync(f => f.FighterId == id);
        }

        public async Task<IEnumerable<FighterAutoCompleteDto?>> FighterAutoComplete(string term)
        {
            return await _context.Fighter
                .Where(f => f.FighterName.Contains(term))
                .Select(f => new FighterAutoCompleteDto { FighterId = f.FighterId, FighterName = f.FighterName })
                .ToListAsync();
        }

        public async Task<Fighter> GetWinnerAsync(int fighter1Id, int fighter2Id)
        {
            // Get both fighters
            var fighter1 = await _context.Fighter.FirstOrDefaultAsync(f => f.FighterId == fighter1Id);
            var fighter2 = await _context.Fighter.FirstOrDefaultAsync(f => f.FighterId == fighter2Id);

            if (fighter1 == null || fighter2 == null)
            {
                throw new ArgumentException("One or both fighter IDs are invalid.");
            }

            // Check ranking
            var fighter1Ranking = await _context.Ranking.FirstOrDefaultAsync(r => r.FighterId == fighter1Id);
            var fighter2Ranking = await _context.Ranking.FirstOrDefaultAsync(r => r.FighterId == fighter2Id);

            // Winner by ranking
            if (fighter1Ranking != null && fighter2Ranking == null)
            {
                return fighter1;
            }
            else if (fighter1Ranking == null && fighter2Ranking != null)
            {
                return fighter2;
            }
            else if (fighter1Ranking != null && fighter2Ranking != null)
            {
                // Winner by ranking score (higher rank wins)
                return fighter1Ranking.Rank > fighter2Ranking.Rank ? fighter1 : fighter2;
            }

            // No ranking, calculate total stats
            var fighter1Stats = GetTotalStats(fighter1);
            var fighter2Stats = GetTotalStats(fighter2);

            // Winner by total stats
            return fighter1Stats > fighter2Stats ? fighter1 : fighter2;
        }

        private decimal GetTotalStats(Fighter fighter)
        {
            return (fighter.FighterSlpm ?? 0) +
                   (fighter.FighterStracc ?? 0) +
                   (fighter.FighterStrdef ?? 0) +
                   (fighter.FighterTdavg ?? 0) +
                   (fighter.FighterTdacc ?? 0) +
                   (fighter.FighterTddef ?? 0) +
                   (fighter.FighterSubavg ?? 0);
        }

    }
}