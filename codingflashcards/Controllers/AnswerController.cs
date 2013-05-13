using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codingflashcards.Repository;

namespace codingflashcards.Controllers
{
    public class AnswerController : Controller
    {
        //
        // GET: /Answer/

        public ActionResult Index(int id = 1)
        {
            return View(InMemorydb.Get(id));
        }

        //
        // GET: /Answer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Answer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Answer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Answer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Answer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Delete/5

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
    }
}
