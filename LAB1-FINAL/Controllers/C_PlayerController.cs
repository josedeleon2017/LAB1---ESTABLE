using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Diagnostics;
using LAB1_FINAL.Models;
using LAB1_FINAL.Helpers;

namespace LAB1_FINAL.Controllers
{
    public class C_PlayerController : Controller
    {
        Stopwatch ST = new Stopwatch();
        // GET: C_Player
        public ActionResult Index()
        {
            ST.Restart();
           
            PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Consulta de Lista Artesanal.");
            return View(Storage.Instance.C_playerList);
        }

        // GET: C_Player/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult C_CSV()
        {
            return View();
        }

        // GET: C_Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_Player/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            // TODO: Add insert logic here
            ST.Restart();
                try
                {
                    var player = new PlayerModel
                    {
                        Name = collection["Name"],
                        LastName = collection["LastName"],
                        Club = collection["Club"],
                        Position = collection["Position"],
                        Salary = int.Parse(collection["Salary"]),
                    };

                    PlayerModel.C_Save(player);
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Creación manual de jugador.");
                return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }    
                
                
        }

        // GET: C_Player/Edit/5
        public ActionResult Edit(string id)
        {
            var player = new PlayerModel();

            foreach (var item in Storage.Instance.C_playerList)
                if (item.Name == id)
                {
                    player = item;
                }
            return View(player);

        }

        // POST: C_Player/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var player = new PlayerModel();

                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Name == id)
                    {
                        player = item;
                    }
                }

                Storage.Instance.C_playerList.Find(player).Club = collection["Club"];
                Storage.Instance.C_playerList.Find(player).Salary = int.Parse(collection["Salary"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C_Player/Delete/5
        public ActionResult Delete(string id)
        {
            ST.Restart();
            try
            {
                var player = new PlayerModel();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Name+item.LastName+item.Club == id)
                    {
                        player = item;
                    }
                }
                PlayerModel.C_Delete(player);
                //AGREGAR DELETE
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Eliminación de jugador de lista artesanal.");
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Index");
            }
        }

        // POST: C_Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Search on LinkedList of C# players with espcific name 
        public ActionResult SearchByName()
        {
            return View();
        }
        public ActionResult Index_player(FormCollection collection)
        {
            ST.Restart();
            try
            {
                string idName = collection["Name"];
                PlayerModel player = new PlayerModel();

                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Name == idName || item.LastName == idName)
                    {
                        player = item;
                    }
                }
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Búsqueda de jugador en lista artesanal.");
                return View(player);

            }
            catch
            {
                return View();
            }
        }

        //Search on LinkedList of C# players with the same position
        public ActionResult Index_positions()
        {
            return View(Storage.Instance.C_CurrentplayerList);
        }
        // GET: S_Player/SearchByPosition/5
        public ActionResult SearchByPosition()
        {
            return View();
        }
        // POST: S_Player/SearchByPosition
        [HttpPost]
        public ActionResult SearchByPosition(FormCollection collection)
        {
            ST.Restart();
            // TODO: Add insert logic here
            try
            {
                string idPosition = collection["Position"];
                Storage.Instance.S_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Position == idPosition)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Búsqueda por posición lista artesanal.");
                return RedirectToAction("Index_positions");
            }
            catch
            {
                return View();
            }
        }


        //Search on Custom LinkedList players with the same club
        public ActionResult Index_club()
        {
            return View(Storage.Instance.C_CurrentplayerList);
        }
        // GET: C_Player/SearchByClub/5
        public ActionResult SearchByClub()
        {
            return View();
        }
        // POST: C_Player/SearchByClub
        [HttpPost]
        public ActionResult SearchByClub(FormCollection collection)
        {
            // TODO: Add insert logic here
            try
            {
                ST.Restart();
                string idClub = collection["Club"];
                Storage.Instance.C_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Club == idClub)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Búsqueda por club lista artesanal.");
                return RedirectToAction("Index_club");
            }
            catch
            {
                return View();
            }
        }

        //Search on Custom LinkedList players with a salary above at espcific
        public ActionResult Index_salaries()
        {
            return View(Storage.Instance.C_CurrentplayerList);
        }
        // GET: C_Player/SearchBySalary/5
        public ActionResult SearchBySalary_Above()
        {
            return View();
        }
        // POST: C_Player/SearchBySalary
        [HttpPost]
        public ActionResult SearchBySalary_Above(FormCollection collection)
        {
            // TODO: Add insert logic here
            try
            {
                ST.Restart();
                int idSalary = int.Parse(collection["Salary"]);
                Storage.Instance.C_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Salary > idSalary)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Búsqueda por salarios por arriba lista artesanal.");
                return RedirectToAction("Index_salaries");
            }
            catch
            {
                return View();
            }
        }

        // GET: C_Player/SearchBySalary/5
        public ActionResult SearchBySalary_Under()
        {
            return View();
        }
        // POST: C_Player/SearchBySalary
        [HttpPost]
        public ActionResult SearchBySalary_Under(FormCollection collection)
        {
            // TODO: Add insert logic here
            try
            {
                ST.Restart();
                int idSalary = int.Parse(collection["Salary"]);
                Storage.Instance.C_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Salary <= idSalary)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Búsqueda por salario por debajo lista artesanal.");
                return RedirectToAction("Index_salaries");
            }
            catch
            {
                return View();
            }
        }

        //CSV reader on Custom List
        [HttpPost]
        public ActionResult CSV(HttpPostedFileBase postedfile)
        {
            ST.Restart();
            string FilePath;
            if (postedfile != null)
            {
                string Path = Server.MapPath("~/Subidas/");
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                FilePath = Path + System.IO.Path.GetFileName(postedfile.FileName);
                postedfile.SaveAs(FilePath);
                string csvData = System.IO.File.ReadAllText(FilePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        try
                        {

                            var player = new PlayerModel
                            {
                                Name = row.Split(',')[2],
                                LastName = row.Split(',')[1],
                                Club = row.Split(',')[0],
                                Position = row.Split(',')[3],
                                Salary = Convert.ToInt32(Convert.ToDouble(row.Split(',')[4])),

                            };
                            PlayerModel.C_Save(player);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            PlayerModel.Log(Convert.ToString(ST.ElapsedTicks), "Importación de datos a lista artesanal desde un CSV.");
            return RedirectToAction("Index");
        }

    }
}
