

using ListBookDemo.DB.Model;
using ListBookDemo.DB.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListBookDemo.BL
{

    public class JobService
    {
        public List<string> jobs 
        {
          get
            {
                return  Enum.GetValues(typeof(JobType))
                .Cast<JobType>()
                .Select(v => v.ToString())
    .            ToList();
            }
        }

        /// <summary>
        /// устроится на  работу 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="type"></param>
        /// <returns>ДА если вы прошли собеседование</returns>
        public bool Get_a_job (User user , JobType type , Action<string> message)
        {
            var job = new JobBase();

            switch (type)
            {
                case JobType.No:
                    job = new JobBase();
                    if (job.IsMeetRequirements(user))
                    {
                        user.Job = job; 
                        message("Вы встали на  биржу труда");
                        return true; 
                    }
                    else
                    {
                        message("Вы не приняты на биржу труда, нам очень жаль");
                        return false;
                    } 
                        
                         
                case JobType.Courier:
                    job = new Courier ();    
                    if (job.IsMeetRequirements(user))
                    {
                        user.Job = job; 
                        message("Вы приняты на работу в должности Курьера");
                        return true;
                    }
                    else
                    {
                        message("Вы не приняты на дольжность Курьера, нам очень жаль");
                        return false;
                    }
                 
                case JobType.Janitor:
                    job = new Janitor();
                    if (job.IsMeetRequirements(user))
                    {
                        user.Job = job;
                        message("Вы приняты на работу на должность Дворник");
                        return true;
                    }
                    else
                    {
                        message("Вы не приняты на дольжность Дворника, нам очень жаль");
                        return false;
                    }
                    default : return false;
                    
                    UserService service = new UserService();    
                    service.SaveUser(user);
            }
        }
    }

    public enum JobType 
    {
        No , Janitor , Courier
    }
}
