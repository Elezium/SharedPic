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
	public class CommentsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository _repository;

		public CommentsController(IUnitOfWork unitOfWork, IRepository repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		// GET: Comments
		public ActionResult Index()
        {

			var model = _repository.GetAll<Comment>();
			return View(model);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var model = _repository.FindOne<Comment>(criteria: i => i.Id == id);
			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {
				_repository.Add<Comment>(comment);
				_unitOfWork.Commit();
				return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			var model = _repository.FindOne<Comment>(criteria: i => i.Id == id);

			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {
				//db.Entry(comment).State = EntityState.Modified;
				//db.SaveChanges();
				_repository.Update<Comment>(comment);
				_unitOfWork.Commit();
				return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var model = _repository.FindOne<Comment>(criteria: i => i.Id == id);
			if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			//Comment comment = db.Comments.Find(id);
			//db.Comments.Remove(comment);
			//db.SaveChanges();
			var model = _repository.FindOne<Comment>(criteria: i => i.Id == id);
			_repository.Delete<Comment>(model);
			_unitOfWork.Commit();
			return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
