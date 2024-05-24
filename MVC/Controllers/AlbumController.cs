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
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class AlbumController : MvcController
    {
        // TODO: Add service injections here
        private readonly IAlbumService _albumService;
        private readonly IMusicService _musicService;

        public AlbumController(IAlbumService albumService, IMusicService musicService)
        {
            _albumService = albumService;
            _musicService = musicService;
        }

        // GET: Albums
        public IActionResult Index()
        {
            List<AlbumModel> albumList = _albumService.GetList(); // TODO: Add get collection service logic here
            return View(albumList);
        }

        // GET: Albums/Details/5
        public IActionResult Details(int id)
        {
            AlbumModel album = _albumService.GetItem(id); // TODO: Add get item service logic here
            if (album == null)
            {
                return View("Error", "Album not found!");
            }
            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Music = new MultiSelectList(_musicService.Query().ToList(), "Id", "Title");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlbumModel album)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _albumService.Add(album);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new {id = album.Id});
                }
                ModelState.AddModelError("", result.Message);
                    
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Music = new MultiSelectList(_musicService.Query().ToList(), "Id", "Title");
			return View(album);
        }

        // GET: Albums/Edit/5
        public IActionResult Edit(int id)
        {
            AlbumModel album = _albumService.GetItem(id); // TODO: Add get item service logic here
            if (album == null)
            {
                return View("Error", "Album not found!");
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Music = new MultiSelectList(_musicService.Query().ToList(), "Id", "Title");
            return View(album);
        }

        // POST: Albums/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AlbumModel album)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _albumService.Update(album);
                if(result.IsSuccessful)
                {
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = album.Id });
				}
                ModelState.AddModelError("", result.Message);
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Music = new MultiSelectList(_musicService.Query().ToList(), "Id", "Title");
			return View(album);
        }

        // GET: Albums/Delete/5
        public IActionResult Delete(int id)
        {
            AlbumModel album = _albumService.GetItem(id); // TODO: Add get item service logic here
            if (album == null)
            {
                return View("Error", "Album not found!");
            }
            return View(album);
        }

        // POST: Albums/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            var result = _albumService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
