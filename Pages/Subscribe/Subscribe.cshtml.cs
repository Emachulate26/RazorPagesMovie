using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SubscribeModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public SubscribeModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Subscriber Subscriber { get; set; } = new Subscriber();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Check if email already exists
        if (_context.Subscribers.Any(s => s.Email == Subscriber.Email))
        {
            ModelState.AddModelError(string.Empty, "This email is already subscribed.");
            return Page();
        }

        _context.Subscribers.Add(Subscriber);
        await _context.SaveChangesAsync();

        TempData["Message"] = "Thank you for subscribing!";
        return RedirectToPage("/Index");
    }
}
