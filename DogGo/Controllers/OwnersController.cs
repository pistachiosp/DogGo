using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        // GET: OwnersController
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();
            return View(owners);
        }

        // GET: OwnersController/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // GET: OwnersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);
                return RedirectToAction(("Index"));
            }
            catch(Exception ex)
            {
                return View(owner);
            }
            /*A couple things to note here. First, if everthing goes as expected and the new user gets entered into the database, we redirect the user back to / owners / index.Second, if some exception gets thrown, we want to return the same view the user on so they can try again.*/
        }

        // GET: OwnersController/Edit/5
        public ActionResult Edit(int id)
            {
            Owner owner = _ownerRepo.GetOwnerById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
            }

            // POST: OwnersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(owner);
            }
        }

        // GET: OwnersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private readonly IOwnerRepository _ownerRepo;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }
    }
}
