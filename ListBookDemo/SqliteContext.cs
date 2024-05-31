using Microsoft.EntityFrameworkCore;


namespace ListBookDemo.DB
{
    public class SqliteContext : DbContext
    {
        public SqliteContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=GameDb.db");
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<User> Users { get; set; }

        public DbSet<BookHistory> BookHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { UserId= 1 ,  Name="TestUser"},

                });

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book { BookId=1 , Name="C# Для  чайников"  , Experience=100 , Price = 50  , ImagePath= @"/Image\NoImage.png" },
                    new Book { BookId=2,  Name="C# Для  мидлов"  , Experience=1000 , Price = 500  , ImagePath= @"/Image\NoImage.png" },
                    new Book {  BookId=3, Name="C# Для  Проффи"  , Experience=1000 , Price = 5000 , ImagePath= @"/Image\NoImage.png" },

                       new Book {  BookId=7, Name="C# Для  Проффи"  , Experience=1000 , Price = 5000 , ImagePath= @"/Image\NoImage.png" },


                          new Book {  BookId=4, Name="C# Для  Проффи"  , Experience=1000 , Price = 5000 , ImagePath= @"/Image\NoImage.png" },


                             new Book {  BookId=5, Name="C# Для  Проффи"  , Experience=1000 , Price = 5000 , ImagePath= @"/Image\NoImage.png" },


                                new Book {  BookId=6, Name="C# Для  Проффи"  , Experience=1000 , Price = 5000 , ImagePath= @"/Image\NoImage.png" },
                });
        }
    }
}
