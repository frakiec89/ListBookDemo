
using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB.Model
{

    public class User : ObjectBase
    {
        [Key]
        public int UserId { get; set; }
        public double Experience { get; set; }
        public double Wallet {  get; internal set; }

        public StatusUser? Status {  get; set; } 


        public void Bay (double price)
        {
            if (Wallet - price >= 0)
                Wallet -= price;
            else
                throw new Exception("Не достаточно денег");
        }   
      
    }
}
