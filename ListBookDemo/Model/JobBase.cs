using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBookDemo.DB.Model
{
    /// <summary>
    /// По  умолчанию  человек  может  стать  на  биржу труда  и  получать минимальное пособие
    /// </summary>
    public class JobBase : ObjectBase
    {
        [Key]
        public int JobId { get; set; }

        private double _salary;

        public double Salary { get =>_salary; set=>_salary=value; }  
        public JobBase() {Salary = 1;  Name = "Биржа труда"; }
        

        /// <summary>
        /// Соответствие требованиям 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual bool IsMeetRequirements (User user)
        {
            return true;
        }
    }

    public class Janitor : JobBase
    {
        public Janitor() { Salary = 10; Name = "Дворник";  }

        public override bool IsMeetRequirements(User user)
        {
            if (user.Experience < 100) 
                return false;
            return true;    
        }
    }

    public class Courier : JobBase
    {
        public Courier() { Salary = 10; Name = "Курьер"; }

        public override bool IsMeetRequirements(User user)
        {
            if (user.Experience < 500)
                return false;
            return true;
        }
    }



}
