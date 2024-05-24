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
    public interface IMusicianService
    {
        IQueryable<MusicianModel> Query();
        Result Add(MusicianModel model);
        Result Update(MusicianModel model);
        Result Delete(int id);


    }
    public class MusicianService : ServiceBase, IMusicianService
    {
        public MusicianService(Db db) : base(db)
        {
        }

        public Result Delete(int id)
        {
            Musician entity = _db.Musician.Include(s =>s.Music).SingleOrDefault(s => s.Id == id);
            
            if (entity is null)
                return new ErrorResults("Musician not found!");
            if (entity.Music is not null && entity.Music.Any())
                return new ErrorResults("Musician can not be deleted because it has relational music!");
            _db.Musician.Remove(entity);    
            _db.SaveChanges();
            return new SuccessResult("Musician deleted successfully!");
            
        }

        public IQueryable<MusicianModel> Query()
        {
            return _db.Musician.Include(s => s.Music).OrderBy(s => s.Name).Select(s => new MusicianModel()
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                IsRetired = s.IsRetired,

                MusicianCountOutput = s.Music.Count,
                MusicNamesOutput = string.Join("<br />", s.Music.OrderByDescending(p => p.PublishedYear).ThenBy(p => p.Title).Select(p => p.Title)),
            });

        }

        public Result Add(MusicianModel model)
        {
            if (_db.Musician.Any(s => s.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResults("Musicians with the same name exist");
            Musician entity = new Musician()
            {
                Name = model.Name.Trim(),
                Surname = model.Surname.Trim(),
                IsRetired = model.IsRetired,
             
               
            };

            _db.Musician.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Musician added successfully");
        }

        public Result Update(MusicianModel model)
        {
            if (_db.Musician.Any(s => s.Id != model.Id && s.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResults("Musician with same name exists!");
            Musician entity = _db.Musician.Find(model.Id);
            if (entity is null)
                return new ErrorResults("Species not found!");
            entity.Name = model.Name.Trim();
            entity.Surname = model.Surname.Trim();
            entity.IsRetired = model.IsRetired;
            _db.Musician.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Species updated successfully");
        }
    }
}
