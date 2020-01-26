using PeopleDir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleDir.BusinessLayer;
using PeopleDir.BusinessLayer.Models;

namespace PeopleDir.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleDirRepository<PeopleModel> _peopleDirRepository = null;

        public PeopleController()
        {
            this._peopleDirRepository = new PeopleDirRepository();
        }

        /// <summary>
        /// Gets all people.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllPeople()
        {
            var people = _peopleDirRepository.GetAllPeople();
            return View(people);
        }

        /// <summary>
        /// Creates the person detail.
        /// </summary>
        /// <param name="people">The people.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PeopleModel people)
        {
            if (ModelState.IsValid)
            {
                _peopleDirRepository.Insert(people);
                _peopleDirRepository.Save();
                return RedirectToAction("GetAllPeople");
            }

            return View(people);
        }

        /// <summary>
        /// Edits the specified people.
        /// </summary>
        /// <param name="people">The people.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPeople(PeopleModel people)
        {
            if (ModelState.IsValid)
            {
                _peopleDirRepository.UpdatePeople(people);
                _peopleDirRepository.Save();
                return RedirectToAction("GetAllPeople");
            }

            return View(people);
        }

        /// <summary>
        /// Edits the person.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ActionResult EditPerson(Guid Id)
        {
            var person = _peopleDirRepository.GetPersonById(Id);
            return View(person);
        }

        /// <summary>
        /// Gets the person detail.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ActionResult GetPersonDetail(Guid Id)
        {
            var person = _peopleDirRepository.GetPersonById(Id);
            return View(person);
        }

        /// <summary>
        /// Deletes the person.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ActionResult DeletePerson(Guid Id)
        {
            _peopleDirRepository.DeletePerson(Id);
            _peopleDirRepository.Save();
            return RedirectToAction("GetAllPeople");

        }

        //TODO:
        //https://www.c-sharpcorner.com/UploadFile/8a67c0/Asp-Net-mvc-code-first-approach-with-repository-pattern/

    }
}