using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SMS.Models
{
    public class AppdbContext: DbContext
    {
       
            public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
            {

            }

            
            public DbSet<Registration> Registration { get; set; }
   
    }
    }
