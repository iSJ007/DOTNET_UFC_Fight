using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UFCFantasyFight.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using UFCFantasyFight.Data;
using UFCFantasyFight.Interfaces;

namespace UFCFantasyFight.Controllers
{
    [Route("[controller]")]
    public class FighterController : Controller
    {
        private readonly ILogger<FighterController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IFighterRepository _fighterRepo;
        public FighterController(ILogger<FighterController> logger, ApplicationDbContext context, IFighterRepository fighterRepo)
        {
            _logger = logger;
            _context = context;
            _fighterRepo = fighterRepo;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Autocomplete/{term}")]

        public async Task<IActionResult> Autocomplete(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return NotFound();
            }

            var fighters = await _fighterRepo.FighterAutoComplete(term);
            return Ok(fighters);


        }

        [HttpGet("Details/{id}")]

        public async Task<IActionResult> GetById(int id)
        {


            var fighter = await _fighterRepo.GetByIdAsync(id);

            if (fighter == null)
            {
                return NotFound();
            }

            return Ok(fighter);
        }

        [HttpGet("Winner/{fighter1Id}/{fighter2Id}")]
        public async Task<IActionResult> GetWinner(int fighter1Id, int fighter2Id)
        {
            try
            {
                var winner = await _fighterRepo.GetWinnerAsync(fighter1Id, fighter2Id);
                return Ok(winner);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, $"Error determining winner: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}