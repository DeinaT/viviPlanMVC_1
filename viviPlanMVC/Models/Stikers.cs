using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace viviPlanMVC.Models
{
    public class Stickers
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int id_board { get; set; }
        public int Status { get; set; }
       // public DateTime DateCreate { get; set; }
        public List<Marks> liMark { get; set; }
    }
    public class StickerContext : DbContext
    {
        /*public viviDataBase() : base("DefaultConnection")
        { }*/
       /* public DbSet<Users> Users { get; set; }
        public Users findUser(Users user_in)
        {
            foreach (Users u in Users)
            {
                if (u.Login.Equals(user_in.Login))
                    return u;
            }
            return null;
        }*/

    }
    public class contextSticker
    {
        public List<Stickers> listSticker { get; set; }
        public List<Stickers> listSticker_out { get; set; }

        public contextSticker()
        {
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TyulenevaKV\Documents\viviPlanDB.mdf;");
            SqlCommand SQL_Cmm;
            SqlDataAdapter SQL_DA;
            DataTable DT = new DataTable();
            listSticker = new List<Stickers>();
            try
            {
                SQL_Con.Open();
                SQL_Cmm = new SqlCommand("select * from Stickers", SQL_Con);
                SQL_DA = new SqlDataAdapter(SQL_Cmm);
                SQL_DA.Fill(DT);
                SQL_Con.Close();

                foreach (DataRow dr in DT.Rows)
                {
                    Stickers st = new Stickers();
                    st.Title = dr["Title"].ToString();
                    st.Id = Convert.ToInt32(dr["Id"]);
                    st.id_board = Convert.ToInt32(dr["id_board"]);
                    if (dr["Description"] != null)
                        st.Description = dr["Description"].ToString();
                    if (dr["Status"] != null)
                        st.Status = Convert.ToInt32(dr["Status"]);
                  /*  if (dr["DateCreate"] != null)
                        st.DateCreate = Convert.ToDateTime(dr["DateCreate"]).Date;*/
                    st.liMark = new List<Marks>();
                    listSticker.Add(st);
                }
            }
            catch
            {
            }
        }       
        public List<Stickers>[] fff(int board_id, List<Marks> marksHav)
        {
            List<Stickers> result = new List<Stickers>();
            List<Stickers>[] findStickers = new List<Stickers>[3];
            for (int i = 0; i < 3; i++)
            {
                findStickers[i] = new List<Stickers>();
            }
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TyulenevaKV\Documents\viviPlanDB.mdf;");
            SqlCommand SQL_Cmm;
            SqlDataAdapter SQL_DA;
            DataTable DT = new DataTable();

            SQL_Con.Open();
            SQL_Cmm = new SqlCommand("select * from Con_Mark_sti", SQL_Con);
            SQL_DA = new SqlDataAdapter(SQL_Cmm);
            SQL_DA.Fill(DT);
            SQL_Con.Close();

            var listSticker2 = listSticker.Where(s => s.id_board == board_id);

            foreach (Stickers st in listSticker2)
            {
                foreach (DataRow dr in DT.Rows)
                {
                    if (st.Id == Convert.ToInt32(dr["id_stiker"]))
                    {                        
                        st.liMark.AddRange(marksHav.Where(m => m.Id == Convert.ToInt32(dr["id_mark"])));
                    }
                }

                if (st.Status == 1)
                    findStickers[0].Add(st);
                if (st.Status == 2)
                    findStickers[1].Add(st);
                if (st.Status == 3)
                    findStickers[2].Add(st);
            }
            return findStickers;
        }
    }
}