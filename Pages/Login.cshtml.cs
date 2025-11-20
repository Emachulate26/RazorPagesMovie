using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class LoginModel : PageModel
{
	[BindProperty]
	public InputModel Input { get; set; }

	public class InputModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}

	public void OnGet()
	{
	}

	public IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		// ?? Example check: only allow admin email
		if (Input.Email == "admin@example.com" && Input.Password == "Admin@123")
		{
			// TODO: Add authentication logic here
			return RedirectToPage("/Admin/Dashboard");
		}

		ModelState.AddModelError(string.Empty, "Invalid login attempt.");
		return Page();
	}
}
