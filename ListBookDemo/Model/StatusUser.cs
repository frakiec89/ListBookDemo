using System.ComponentModel.DataAnnotations;

namespace ListBookDemo.DB.Model
{
    public  class StatusUser : ObjectBase
    {
        [Key]
        public int StatusUserId {  get; set; }
        public double MinExperience { get; set; } = 0;
        public double SalaryCoefficient { get; set; } = 0.1;
        public virtual bool Available(User user)
        {
            if (user.Experience < MinExperience)
                return false;
            return true;
        }
    }

    public class Junior : StatusUser
    {
        public Junior () {
            MinExperience = 100;
            SalaryCoefficient = 0.2;
            base.Name = "Джун";
        }

        public override bool Available(User user)
        {
            // todo - добавить  доп проверки для джуна 
           return base.Available(user);
        }
    }

    public class Middle : StatusUser
    {
       public  Middle ()
        {
            MinExperience = 500;
            SalaryCoefficient = 0.5;
            base.Name = "Мидл";
        }
    }
}