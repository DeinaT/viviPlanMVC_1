using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace viviPlanMVC.Models
{
    public class Con_Board_User
    {
        [Key]
        [Column(Order = 0)]
        public int id_Board { get; set; }
        [Key]
        [Column(Order = 1)]
        public int id_User { get; set; }
    }
    public class Con_Sti_User
    {
        [Key]
        [Column(Order = 0)]
        public int id_Stickers { get; set; }
        [Key]
        [Column(Order = 1)]
        public int id_User { get; set; }
    }
    public class Con_Sti_Mark
    {
        [Key]
        [Column(Order = 0)]
        public int id_Stickers { get; set; }
        [Key]
        [Column(Order = 1)]
        public int id_Mark { get; set; }
    }
}