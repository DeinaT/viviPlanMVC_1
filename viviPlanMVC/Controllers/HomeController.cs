using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using viviPlanMVC.Models;

namespace WebRoleLab.Controllers
{
    public class HomeController : Controller
    {
        viviDataBase Context_db = new viviDataBase();
        // GET: Home
        public ActionResult Index()
        {
            // User u = new User();
            //  var dkf = DataDirectory;
            //var fu = viviDB.Users.ToList();
            var dfu = Context_db.Users.ToList();
            var df2u = Context_db.Boards.ToList();
            var df3u = Context_db.Stickers.ToList();
            return View();
        }
        public ActionResult Board(int? id)
        {
            List<Stickers>[] findStickers = new List<Stickers>[3];
            for (int i = 0; i < 3; i++)
            {
                findStickers[i] = new List<Stickers>();
            }
            var listSticker = Context_db.Stickers.Where(s => s.id_board == id).ToList();
            foreach (Stickers st in listSticker)
            {
                foreach (Con_Sti_Mark cSM in Context_db.Con_Sti_Mark.ToList())
                {
                    if (st.Id == cSM.id_Stickers)
                    {
                        st.liMark.AddRange(Context_db.Marks.Where(m => m.Id == cSM.id_Mark));
                    }
                }
                if (st.Status == 1)
                    findStickers[0].Add(st);
                if (st.Status == 2)
                    findStickers[1].Add(st);
                if (st.Status == 3)
                    findStickers[2].Add(st);
            }            
            ViewData["Title"] = Context_db.Boards.Where((o => o.Id == id)).First().Title;
            return View(findStickers);
        }
        public ActionResult newTable(int? id)
        {
            List<Table> tt = Context_db.Table.Where((o => o.Board == id)).ToList();
            ViewData["Title"] = Context_db.Boards.Where((o => o.Id == id)).First().Title;
            return View(tt);
        }
        public ActionResult Authorization(User us)
        {
            //var userFind = Context_db.findUser(us);
            var userFind = Context_db.Users.Where(u => (u.Login == us.Login)&&(u.Password == us.Password)).ToList();
            if (userFind != null)
                return RedirectToAction("MainDesk/" + userFind.First().Id.ToString() );
            else return PartialView("Index");
        }
        public ActionResult MainDesk(int id)
        {
            /*listBoard = new contextBoard();
            var jy = listBoard.findBoard(id);

            return View(listBoard.findBoard(id));*/
            List<Boards> bo = new List<Boards>();
            List<Con_Board_User> needBoard = Context_db.Con_Board_User.Where(u => u.id_User==id).ToList();
            foreach (Con_Board_User bu in needBoard)
                 bo.AddRange(Context_db.Boards.Where(b => b.Id== bu.id_Board));

            return View(bo);
        }
        public ActionResult Broard()
        {
            int fogi = 9;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User us)
        {
            /*Заполнение БД новым юзером*/
            //return View("Broard");
            //return "Регистрация прошла успешно";
            if (Context_db.Users.Where(u => u.Login == us.Login).ToList().Count == 0)
            {
                Context_db.Users.Add(us);
                Context_db.SaveChanges();
                return View("Index");
            }
            else
                return View("Index");
        }
        [HttpPost]
        public ActionResult Task(string stt)
        {
            var jj = Request.UrlReferrer;
            var jh = Request.UrlReferrer.ToString().LastIndexOf("/");
            var idBoard = Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().LastIndexOf("/"));
            int firt = stt.IndexOf("<td>")+4;
            int duy = stt.IndexOf("</td>");
            int firt2 = stt.LastIndexOf("<td>")+4;
            int duy2 = stt.LastIndexOf("</td>");

            var diui = stt.Substring(firt, duy-firt-1);
            var diui2 = stt.Substring(firt2, duy2-firt2-1);
            //var fgiu = stt.Split("td");
            ViewData["Title"] = Context_db.Table.Where((o => o.Board == 1)).First().Title;
            List<Table> tt = Context_db.Table.Where((o => o.Board == 1)).ToList();
            return RedirectToAction("newTableSprint", tt);
        }
        public ActionResult Sprint(int id)
        {
            var jh = Request.UrlReferrer.ToString().LastIndexOf("/")+1;
            int idBoard = Convert.ToInt32(Request.UrlReferrer.ToString().Substring(jh));
         //   List <Table> tt2 = Context_db.Table.Where((o => o.Id == id)).First();
            ViewData["Title"] = Context_db.Table.Where((o => o.Id == id)).First().Title;
            List<Stickers> tt2 = Context_db.Stickers.Where((o => o.id_board == id)).ToList();
            return View("newTableSprint", tt2);
        }
        [HttpPost]
        public ActionResult CreateBroard(string namebroard, string descr, string kkk)
        {
            int dofu = 34;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult markAdd(string Title, string Back, string Letter)
        {
            Marks mark = new Marks();
            mark.Title = Title;
            mark.Color_Background = Back;
            mark.Color_Letter = Letter;
            //this.Response.
            //this.re
            return PartialView("~/Views/Home/Partical/addMarks.cshtml", mark);
        }
        [HttpPost]
        public ActionResult AddStiker(string TitleSt, string DescrSt, string kkk)
        {
            /*Заполнение БД новым стикером*/
            Stickers newST = new Stickers();
            newST.Title = TitleSt;
            newST.Status = 1;
            newST.Description = DescrSt;
            newST.id_board = Convert.ToInt32(Request.UrlReferrer.AbsolutePath.Substring(Request.UrlReferrer.AbsolutePath.LastIndexOf('/') + 1));
            try
            {
                Context_db.Stickers.Add(newST);
                Context_db.SaveChanges();
            }
            catch
            { }
            return PartialView("formadd",newST);
        }
        protected override void Dispose(bool disposing)
        {
            Context_db.Dispose();
            base.Dispose(disposing);
        }
    }
}