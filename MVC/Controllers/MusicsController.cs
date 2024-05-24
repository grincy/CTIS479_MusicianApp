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

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class MusicsController : Controller
    {
        // TODO: Add service injections here
        private readonly IMusicService _musicService;
        private readonly IMusicianService _musicianService;

        public MusicsController(IMusicService musicService, IMusicianService musicianService)
        {
            _musicService = musicService;
            _musicianService = musicianService;
        }

        // GET: Musics
        public IActionResult Index()
        {
            List<MusicModel> musicList = _musicService.Query().ToList(); // TODO: Add get collection service logic here
            return View(musicList);
        }

        // GET: Musics/Details/5
        public IActionResult Details(int id)
        {
            MusicModel music = _musicService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (music == null)
            {
                return NotFound();
            }
            ViewBag.MusicianId = new SelectList(_musicianService.Query(), "Id", "Name");
            return View(music);
        }

        // GET: Musics/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.MusicianId = new SelectList(_musicianService.Query(), "Id", "Name");
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MusicModel music)
        {
            if (ModelState.IsValid)
            {
                Result result = _musicService.Add(music);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;

                    return RedirectToAction(nameof(Index));
                }
                ViewBag.ViewMessage = result.Message;
                // TODO: Add insert service logic here
                //return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.MusicianId = new SelectList(_musicianService.Query(), "Id", "Name");
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(music);
        }

        // GET: Musics/Edit/5
        public IActionResult Edit(int id)
        {
            MusicModel music = _musicService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (music == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            ViewBag.Musician = new SelectList(_musicianService.Query(), "Id", "Name");
            return View(music);
        }

        // POST: Musics/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MusicModel music)
        {

            if (ModelState.IsValid)
            {
                Result result = _musicService.Update(music);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = music.Id });
                }
                TempData["Message"] = result.Message;
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Details), new { id = music.Id });
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            ViewBag.Musician = new SelectList(_musicianService.Query(), "Id", "Name");
            return View(music);
        }

        // GET: Musics/Delete/5
        public IActionResult Delete(int id)
        {
            MusicModel music = _musicService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (music == null)
            {
                return NotFound();
            }
            ViewBag.MusicianId = new SelectList(_musicianService.Query(), "Id", "Name");
            return View(music);
        }

        // POST: Musics/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _musicService.Delete(id);
            TempData["Message"] = result.Message;
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
