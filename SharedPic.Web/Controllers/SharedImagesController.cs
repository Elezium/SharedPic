using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SharedPic.DataAccess;
using SharedPic.Domain;

namespace SharedPic.Web.Controllers
{
    public class SharedImagesController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository _repository;

		public SharedImagesController(IUnitOfWork unitOfWork, IRepository repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		// GET: SharedImages
		public ActionResult Index()
        {
			var model = _repository.GetAll<SharedImage>();
			return View(model);
        }

        // GET: SharedImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var model = _repository.FindOne<SharedImage>(criteria: i => i.Id == id);
			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: SharedImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SharedImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Description,ImageUrl")] SharedImage sharedImage)
        {
            if (ModelState.IsValid)
            {
				_repository.Add<SharedImage>(sharedImage);
				_unitOfWork.Commit();
				return RedirectToAction("Index");
            }

            return View(sharedImage);
        }

        // GET: SharedImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var model = _repository.FindOne<SharedImage>(criteria: i => i.Id == id);
			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: SharedImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Description,ImageUrl")] SharedImage sharedImage)
        {
            if (ModelState.IsValid)
            {
				_repository.Update<SharedImage>(sharedImage);
				_unitOfWork.Commit();
				return RedirectToAction("Index");
            }
            return View(sharedImage);
        }

        // GET: SharedImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var model = _repository.FindOne<SharedImage>(criteria: i => i.Id == id);
			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: SharedImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			var model = _repository.FindOne<SharedImage>(criteria: i => i.Id == id);
			_repository.Delete<SharedImage>(model);
			_unitOfWork.Commit();
			return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
