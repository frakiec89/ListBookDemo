using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public double Experience { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; } 

    }
}
