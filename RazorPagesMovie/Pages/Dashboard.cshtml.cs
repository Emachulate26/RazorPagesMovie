using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Data;
using Microsoft.EntityFrameworkCore;

public class DashboardModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public DashboardModel(RazorPagesMovieContext context)
    {
        _context = context;
    }


    public List<string> Genres { get; set; }
    public List<int> GenreCounts { get; set; }

    public async Task OnGetAsync()
    {
        Genres = await _context.Movie
                    .Select(m => m.Genre)
                    .Distinct()
                    .ToListAsync();

        GenreCounts = new List<int>();

        foreach (var genre in Genres)
        {
            int count = await _context.Movie
                        .Where(m => m.Genre == genre)
                        .CountAsync();

            GenreCounts.Add(count);
        }
    }
}
