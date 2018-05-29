using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace viviPlanMVC.Models
{
    public class Boards
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        
    }
    public class BoardContext : DbContext
    {
        /*public viviDataBase() : base("DefaultConnection")
        { }*/
        public DbSet<Boards> Boards { get; set; }
        /*public Boards findUser(Boards user_in)
        {
            foreach (Boards u in Boards)
            {
                if (u.Login.Equals(user_in.Login))
                    return u;
            }
            return null;
        }*/

    }
    public class contextBoard
    {
        public List<Boards> listBoard { get; set; }

        public contextBoard()
        {
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TyulenevaKV\Documents\viviPlanDB.mdf;");
            SqlCommand SQL_Cmm;
            SqlDataAdapter SQL_DA;
            DataTable DT = new DataTable();
            listBoard = new List<Boards>();
            try
            {
                SQL_Con.Open();
                SQL_Cmm = new SqlCommand("select * from Boards", SQL_Con);
                SQL_DA = new SqlDataAdapter(SQL_Cmm);
                SQL_DA.Fill(DT);
                SQL_Con.Close();

                foreach (DataRow dr in DT.Rows)
                {
                    Boards bo = new Boards();
                    bo.Title = dr["Title"].ToString();
                    bo.Id = Convert.ToInt32(dr["Id"]);
                    if (dr["Description"] != null)
                        bo.Description = dr["Description"].ToString();
                    listBoard.Add(bo);
                }
            }
            catch
            {
            }
        }

       
        public List<Boards> findBoard(int user_id)
        {
            // listBoard
            List<Boards> findBoards = new List<Boards>();
            try
            {
                SqlConnection SQL_Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TyulenevaKV\Documents\viviPlanDB.mdf;");
                SqlCommand SQL_Cmm;
                SqlDataAdapter SQL_DA;
                DataTable DT = new DataTable();
                SQL_Con.Open();
                SQL_Cmm = new SqlCommand("select * from Con_User_Board", SQL_Con);
                SQL_DA = new SqlDataAdapter(SQL_Cmm);
                SQL_DA.Fill(DT);
                SQL_Con.Close();

                List<int> numberBoard = new List<int>();

                foreach (DataRow dr in DT.Rows)
                {
                    if (dr["ID_User"].ToString().Equals(user_id.ToString()))
                    {
                        // numberBoard.Add(Convert.ToInt32(dr["ID_Board"]));
                        int find = Convert.ToInt32(dr["ID_Board"]);
                        findBoards.AddRange(listBoard.Where(bo => bo.Id == find));
                    }
                }
                
            }
            catch
            {
                return null;
            }
                return findBoards;
        }
    }

    
}