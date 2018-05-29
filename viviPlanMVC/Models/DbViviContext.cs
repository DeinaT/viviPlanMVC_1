using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace viviPlanMVC.Models
{
    public class viviDataBase : DbContext
    {
        /*public viviDataBase() : base("DefaultConnection")
        { }*/
        public DbSet<User> Users { get; set; }
        public DbSet<Boards> Boards { get; set; }
        public DbSet<Stickers> Stickers { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Con_Board_User> Con_Board_User { get; set; }
        public DbSet<Con_Sti_User> Con_Sti_User { get; set; }
        public DbSet<Con_Sti_Mark> Con_Sti_Mark { get; set; }
        public User findUser(User user_in)
        {
            foreach (User u in Users)
            {
                if (u.Login.Equals(user_in.Login))
                    return u;
            }
            return null;
        }

    }

}