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
    public class IndexModel : PageModel
    {
        private readonly StoreContext _context;

        public IndexModel(StoreContext dbcontext)
        {
            _context = dbcontext;
        }


        public IList<Game> Game { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Game != null)
            {
                Game = await _context.Game.ToListAsync();
            }
        }
    }
}
