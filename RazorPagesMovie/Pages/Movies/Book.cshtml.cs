using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BookModel : PageModel
{
	[BindProperty] public int MovieId { get; set; }
	[BindProperty] public string TimeSlot { get; set; }

	public Movie Movie { get; set; }

	public IActionResult OnPost()
	{
		Movie = MoviesModel.Movies.FirstOrDefault(m => m.Id == MovieId);

		var count = MoviesModel.Bookings
			.Count(b => b.MovieId == MovieId && b.TimeSlot == TimeSlot);

		if (count >= Movie.Capacity)
			return RedirectToPage("Index");   // Fully booked, send back

		MoviesModel.Bookings.Add(new Booking
		{
			MovieId = MovieId,
			TimeSlot = TimeSlot,
			UserId = "demo-user" // Replace with logged-in user
		});

		return Page();
	}
}
