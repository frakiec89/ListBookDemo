using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB
{
    public class BookHistory
    {
        [Key]
        public int BookHistoryId { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime DateTime { get; set; }  
    }
}
