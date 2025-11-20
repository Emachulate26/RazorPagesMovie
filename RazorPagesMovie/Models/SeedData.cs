using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "ADULTING",
                    ReleaseDate = DateTime.Parse("2024-2-12"),
                    Genre = "SERIES",
                    Price = 7M,
                    Rating = 5,
                    ImageUrl = "/images/adulting.jpg"



                },

                new Movie
                {
                    Title = "BEL AIR",
                    ReleaseDate = DateTime.Parse("2024-3-13"),
                    Genre = "COMEDY",
                    Price = 8,
                    Rating = 5,
                    ImageUrl = "/images/bel air.jpg"

                },

                new Movie
                {
                    Title = "KINGS OF JOBURG",
                    ReleaseDate = DateTime.Parse("2025-2-23"),
                    Genre = "ACTION",
                    Price = 9.99M,
                    Rating = 5,
                    ImageUrl = "/images/kings of joburg.jpg"
                },

                new Movie
                {
                    Title = "NE ZHA 1",
                    ReleaseDate = DateTime.Parse("2024-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = 5,
                    ImageUrl = "/images/ne zha 1.jpj"
                },

                new Movie
                {
                    Title = "NE ZHA 2",
                    ReleaseDate = DateTime.Parse("2024-5-19"),
                    Genre = "DRAMA",
                    Price = 6.99M,
                    Rating = 5,
                    ImageUrl = "/images/ne zha 2.jpg"
                },

                new Movie
                {
                    Title = "OUTLAWS",
                    ReleaseDate = DateTime.Parse("2024-6-09"),
                    Genre = "THRILLER",
                    Price = 10M,
                    Rating = 5,
                    ImageUrl = "/images/outlaws.jpg"
                },

                new Movie
                {
                    Title = "SHAKA ILEMBE",
                    ReleaseDate = DateTime.Parse("2024-7-11"),
                    Genre = "ROMANCE",
                    Price = 12M,
                    Rating = 5,
                    ImageUrl = "/images/shaka ilembe.jpg"
                },

                new Movie
                {
                    Title = "AVATAR: THE LAST AIRBENDER",
                    ReleaseDate = DateTime.Parse("2024-8-21"),
                    Genre = "MYSTERY",
                    Price = 14M,
                    Rating = 5,
                    ImageUrl = "/images/the last airbendor.jpg"
                },

                new Movie
                {
                    Title = "THE LION KING",
                    ReleaseDate = DateTime.Parse("2024-9-29"),
                    Genre = "SCI-FI",
                    Price = 15M,
                    Rating = 5,
                    ImageUrl = "/images/the lion king.jpg"
                },

                new Movie
                {
                    Title = "UNDERGROUND RAILROAD",
                    ReleaseDate = DateTime.Parse("2024-10-31"),
                    Genre = "FANTASY",
                    Price = 20M,
                    Rating = 5,
                    ImageUrl = "/images/underground railroad.jpg"
                },


                new Movie
                {
                    Title = "WOMEN KING",
                    ReleaseDate = DateTime.Parse("2024-11-15"),
                    Genre = "ADVENTURE",
                    Price = 25M,
                    Rating = 5,
                    ImageUrl = "/images/women king.jpg"
                },


                new Movie
                {
                    Title = "YOUNGINS",
                    ReleaseDate = DateTime.Parse("2024-12-25"),
                    Genre = "ANIMATION",
                    Price = 30M,
                    Rating = 5,
                    ImageUrl = "/images/youngings.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}