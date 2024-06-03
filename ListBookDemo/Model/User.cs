
using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB.Model
{

    public class User : ObjectBase
    {
        [Key]
        public int UserId { get; set; }
        public double Experience { get; set; }
        
        public StatusUser? Status {  get; set; } 
      
    }
}
