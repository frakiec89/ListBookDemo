using ListBookDemo.DB.Model;
using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB
{
    public class Book : ObjectBase
    {
        [Key]
        public int BookId { get; set; }
        public double Experience { get; set; }
        public double Price { get; set; }
    }
}
