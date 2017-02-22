using DevTest.DAL;
using DevTestApp.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevTestApp.Controllers
{
    public class RealTimeVoteController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


       
        public ActionResult Index()
        {
            var votes = unitOfWork.VoteRepository.Get();
            return View(votes);
        }


        public ActionResult LiveData()
        {
            var votes = unitOfWork.VoteRepository.Get();
            return View(votes);
        }

        public ActionResult RealTimeData()
        {
            return View();
        }


        // GET: RealTime/Details/5
        public ActionResult Details(int id)
        {
            var vote = unitOfWork.VoteRepository.GetByID(id);
            return View(vote);
        }

        // GET: RealTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealTime/Create
        [HttpPost]
        public ActionResult Create(DevTest vote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //using unit of work pattern for insert operation to maintain ATOMIC transactions
                    unitOfWork.VoteRepository.Insert(vote);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(vote);
        }

        // GET: RealTime/Edit/5
        public ActionResult Edit(int id)
        {
            var vote = unitOfWork.VoteRepository.GetByID(id);
            return View(vote);
        }

        // POST: RealTime/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DevTest vote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //using unit of work pattern for update operation to maintain ATOMIC transactions
                    unitOfWork.VoteRepository.Update(vote);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(vote);
        }

        // GET: RealTime/Delete/5
        public ActionResult Delete(int id)
        {
            var vote = unitOfWork.VoteRepository.GetByID(id);
            return View(vote);
        }

        // POST: RealTime/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,DevTest vote)
        {
            try
            {
                //using unit of work pattern for delete operation to maintain ATOMIC transactions
                var student = unitOfWork.VoteRepository.GetByID(id);
                unitOfWork.VoteRepository.Delete(vote);
                unitOfWork.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("Index");
        }
    }
}
