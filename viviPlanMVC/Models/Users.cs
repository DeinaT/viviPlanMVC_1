using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace viviPlanMVC.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Soname { get; set; }
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo_path { get; set; }
        public string portfolio { get; set; }

        /*public User findUser(User user_in)
        {
            foreach (User u in Users)
            {
                if (u.Login.Equals(user_in.Login))
                    return u;
            }
            return null;
        }*/
    }
    

}