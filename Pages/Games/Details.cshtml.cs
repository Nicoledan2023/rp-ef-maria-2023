using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rp_ef_maria.Models;

namespace rp_ef_maria.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly StoreContext _context;

        public DetailsModel(StoreContext context)
        {
            _context = context;
        }

    

        
           [FromQuery(Name = "msg")]
        public String Message { get; set; } = default!; 
        public Game Game { get; set; } = default!; 
     

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

        
            var game = await _context.Game.FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            else 
            {
                Game = game;
            }
            return Page();
        }
    }
}
