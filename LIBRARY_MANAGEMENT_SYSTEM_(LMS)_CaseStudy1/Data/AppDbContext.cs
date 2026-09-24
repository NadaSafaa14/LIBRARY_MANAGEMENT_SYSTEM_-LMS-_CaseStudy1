using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library_Management_System_LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.BorrowRecords)
                .WithOne(br => br.Member)
                .HasForeignKey(br => br.MemberId);

            modelBuilder.Entity<Book>()
               .HasMany(m => m.BorrowRecords)
               .WithOne(br => br.Book)
               .HasForeignKey(br => br.BookId);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();    

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Email)
                .IsUnique();

            modelBuilder.Entity<BorrowRecord>()
                .Property(br => br.BorrowDate)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Member>()
                .HasData
                (new Member
                {
                    Id = 1,
                    FullName = "Nada Safaa",
                    Email = "nada@gmail.com" ,
                    PhoneNumber = "01000000000",
                },
                new Member
                {
                    Id = 2,
                    FullName = "Belal Mohamed",
                    Email = "belal@gmail.com",
                    PhoneNumber = "01100000000",
                });

            modelBuilder.Entity<Book>()
                .HasData
                (
                    new Book
                    {
                        Id = 1,
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        PublishedYear = 1925,
                        Price = 10.99m,
                        AvailableCopies = 5,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "To Kill a Mockingbird",
                        Author = "Harper Lee",
                        PublishedYear = 1960,
                        Price = 12.99m,
                        AvailableCopies = 3,
                        CategoryId = 2
                    }
                );

            modelBuilder.Entity<Category>()
                .HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Fiction"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Classic"
                    }
                );

            modelBuilder.Entity<BorrowRecord>()
                .HasData
                (
                    new BorrowRecord
                    {
                        Id = 1,
                        BookId = 1,
                        MemberId = 1,
                        BorrowDate = DateTime.Now,
                        ReturnDate = null
                    },
                    new BorrowRecord
                    {
                        Id = 2,
                        BookId = 2,
                        MemberId = 2,
                        BorrowDate = DateTime.Now,
                        ReturnDate = null
                    }
                );
        }
    }
}
