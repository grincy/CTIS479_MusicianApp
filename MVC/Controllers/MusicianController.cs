#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Businness.Services;
using Businness.Models;
using DataAccess.Results.Bases;
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class MusicianController : MvcController
    {
        // TODO: Add service injections here
        private readonly IMusicianService _musicianService;
        private readonly IMusicService _musicService;

        public MusicianController(IMusicianService musicianService, IMusicService musicService)
        {
            _musicianService = musicianService;
            _musicService = musicService;
        }

        // GET: Musicians
        public IActionResult Index()
        {
            List<MusicianModel> musicianList = _musicianService.Query().ToList(); // TODO: Add get collection service logic here
            return View(musicianList);
        }

        // GET: Musicians/Details/5
        public IActionResult Details(int id)
        {
            MusicianModel musician = _musicianService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (musician == null)
            {
                return NotFound();
            }
            ViewBag.Music = new MultiSelectList(_musicService.Query(), "Id", "Title");
            return View(musician);
        }

        // GET: Musicians/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Music = new MultiSelectList(_musicService.Query(), "Id", "Title");
            return View();
        }

        // POST: Musicians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MusicianModel musician)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here

                Result result = _musicianService.Add(musician);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                //ModelState.AddModelError("", result.Message);
                ViewBag.ViewMessage = result.Message;
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(musician);
        }

        // GET: Musicians/Edit/5
        public IActionResult Edit(int id)
        {
            MusicianModel musician = _musicianService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (musician == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Music = new MultiSelectList(_musicService.Query(), "Id", "Title");
            return View(musician);
        }

        // POST: Musicians/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MusicianModel musician)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result = _musicianService.Update(musician);
                if(result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = musician.Id});
                }
                ModelState.AddModelError("", result.Message);
                ViewBag.Music = new MultiSelectList(_musicService.Query(), "Id", "Title");
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(musician);
        }

        // GET: Musicians/Delete/5
        public IActionResult Delete(int id)
        {
            MusicianModel musician = _musicianService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (musician == null)
            {
                return NotFound();
            }
            return View(musician);
        }

        // POST: Musicians/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            Result result = _musicianService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
