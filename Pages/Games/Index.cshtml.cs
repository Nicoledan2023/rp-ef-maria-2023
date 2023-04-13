using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		public IList<Game> Game { get; set; } = default!;

		[BindProperty(SupportsGet = true)]
		public string Query { get; set; } = default!;

        //add for lab2
		 [BindProperty(SupportsGet = true)]
        public bool checkboxbool { get; set; }

        [BindProperty(SupportsGet = true)]
		[DataType(DataType.Date)]
		public DateTime? StartTime { get; set; }

		[BindProperty(SupportsGet = true)]
		[DataType(DataType.Date)]
    	public DateTime? EndTime { get; set; }

		public async Task OnGetAsync()
		{
			IQueryable<Game> games =_context.Game; 

			if (StartTime.HasValue && EndTime.HasValue && EndTime < StartTime)
			{
				ModelState.AddModelError("EndTime", "End time must be greater than or equal to start time.");          
            }
            else
            {
                if (Query != null)
                {
                    // if title query is not empty, search for titles that contain the query
                    games = _context.Game.Where(g => g.Title.Contains(Query));
					
                }

                if (checkboxbool)
                {
                     games = _context.Game.Where(g => g.Title.Contains(Query));
                }
				else{
					if (StartTime.HasValue)
                    {
                        games = games.Where(g => g.ReleaseDate >= StartTime);
                    }

                    if (EndTime.HasValue)
                    {
                        games = games.Where(g => g.ReleaseDate <= EndTime);
                    }
				}
            }

            Game = await games.ToListAsync();
			// render the page
			Page();

		}

	}
}