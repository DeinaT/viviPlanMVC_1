using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace viviPlanMVC.Models
{
    public class Marks
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Color_Background { get; set; }
        public string Color_Letter { get; set; }
    }

    public class contextMark
    {
        public List<Marks> listMark { get; set; }

        public contextMark()
            {
            SqlConnection SQL_Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TyulenevaKV\Documents\viviPlanDB.mdf;");
            SqlCommand SQL_Cmm;
            SqlDataAdapter SQL_DA;
            DataTable DT = new DataTable();
            listMark = new List<Marks>();
            try
            {
                SQL_Con.Open();
                SQL_Cmm = new SqlCommand("select * from Marks", SQL_Con);
                SQL_DA = new SqlDataAdapter(SQL_Cmm);
                SQL_DA.Fill(DT);
                SQL_Con.Close();

                foreach (DataRow dr in DT.Rows)
                {
                    Marks m = new Marks();
                    m.Title = dr["Title"].ToString();
                    m.Id = Convert.ToInt32(dr["Id"]);
                    m.Color_Background = dr["Color_Background"].ToString();
                    m.Color_Letter = dr["Color_Letter"].ToString();
                    listMark.Add(m);
                }
            }
            catch
            {
            }
        }
        
    }
}