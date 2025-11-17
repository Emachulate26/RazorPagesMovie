using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class RazorPagesMovieContext : IdentityDbContext
{
    public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
        : base(options)
    {
    }

    // Your existing DbSets here
}


