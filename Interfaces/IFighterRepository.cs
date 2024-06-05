using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UFCFantasyFight.Models;
using UFCFantasyFight.Dtos;

namespace UFCFantasyFight.Interfaces
{
    public interface IFighterRepository
    {
        Task<Fighter?> GetByIdAsync(int id);
        Task<IEnumerable<FighterAutoCompleteDto?>> FighterAutoComplete(string term);
        Task<Fighter?> GetWinnerAsync(int fighter1Id, int fighter2Id);
    }
}