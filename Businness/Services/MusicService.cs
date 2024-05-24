using Businness.Models;
using Businness.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{

    public interface IMusicService
    {
        IQueryable<MusicModel> Query();

        Result Add(MusicModel model);


        Result Update(MusicModel model);
        Result Delete(int id);
    }

    public class MusicService : ServiceBase, IMusicService
    {
        public MusicService(Db db) : base(db)
        {
        }

        public Result Add(MusicModel model)
        {
            if (_db.Music.Any(s => s.Title.ToLower() == model.Title.ToLower().Trim()))
            {
                return new ErrorResult("music with the same name exists!");
            }
            Music music = new Music()
            {
                Title = model.Title.Trim(),
                PublishedYear = model.PublishedYear,
                Price = model.Price,
                MusicianId = model.MusicianId,
            };
            _db.Music.Add(music);
            _db.SaveChanges();
            return new SuccessResult("Music added successfully.");
        }

        public Result Delete(int id)
        {
            Music music = _db.Music.Include(s => s.Musician).SingleOrDefault(s => s.Id == id);

            if (music == null)
            {
                return new ErrorResult("Music not found!");
            }

            _db.Music.Remove(music);
            _db.SaveChanges();
            return new SuccessResult("Music deleted successfully");
        }

        public IQueryable<MusicModel> Query()
        {
            return _db.Music.Include(p => p.AlbumsMusics).Include(p => p.Musician).OrderBy(p => p.Title).Select(p => new MusicModel()
            {
                Price = p.Price,
                PublishedYear = (DateTime)p.PublishedYear,
                Title = p.Title,
                MusicianId = p.MusicianId,
                Guid = p.Guid,
                Id = p.Id,
                
                
            });
        }

        public Result Update(MusicModel model)
        {
            if (_db.Music.Any(s => s.Id != model.Id && s.Title.ToLower().Trim() == model.Title.ToLower().Trim()))
            {
                return new ErrorResult("Music with the same name exists!");

            }
            Music music = _db.Music.Find(model.Id);
            if (music == null)
            {
                return new ErrorResult("Musician not found!");
            }
            music.Title = model.Title.Trim();
            music.PublishedYear = model.PublishedYear;
            music.Price = model.Price;
            music.MusicianId = model.MusicianId;
            _db.Music.Update(music);
            _db.SaveChanges();
            return new SuccessResult("Music updated successfully.");
        }
    }
}
