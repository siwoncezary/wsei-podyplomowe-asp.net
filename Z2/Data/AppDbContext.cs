using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Z2.Models;

namespace Z2.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    private string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.CurrentDirectory;
        DbPath = Path.Join(folder, "books.db");
    }

    // public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        string adminId = Guid.NewGuid().ToString();
        IdentityRole adminRole = new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "admin",
            NormalizedName = "ADMIN"
        };
        modelBuilder.Entity<IdentityRole>().HasData(
            adminRole
        );

        IdentityUser adminUser = new()
        {
            Id = adminId,
            UserName = "admin@wsei.edu.pl",
            NormalizedEmail = "admin@wsei.edu.pl".ToUpper(),
            NormalizedUserName = "admin@wsei.edu.pl".ToUpper(),
            Email = "admin@wsei.edu.pl",
            EmailConfirmed = true,
            ConcurrencyStamp = adminId,
        };
        PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "1234Abcd!");
        modelBuilder.Entity<IdentityUser>().HasData(
            adminUser
        );
        // skojarzenie użytkownika z jego rolami
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                UserId = adminId,
                RoleId = adminRole.Id
            }
        );
        // Dodaj dwóch autorów, pierwszy o danych z książki powyżej
        modelBuilder.Entity<Author>().HasData(
            new Author()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Freeman",
                Email = "freeman@wsei.edu.pl"
            },
            new Author()
            {
                Id = 2,
                FirstName = "Robert",
                LastName = "Martin",
                Email = "unclebob@wsei.edu.pl"
            }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book()
            {
                Id = 1,
                Title = "ASP.NET Core 3.0",
                AuthorId = 1,
                Published = new DateOnly(2022, 10, 10),
                ISBN = "334324233545",
                Pages = 1023
            }
        );
    }
}