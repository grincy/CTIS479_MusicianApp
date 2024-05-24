using Businness.Models;
using Businness.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Businness.Services { 

    public interface IAlbumService
    {
        IQueryable<AlbumModel> Query();
        Result Add(AlbumModel model);
        Result Update(AlbumModel model);
        Result Delete(int id);

        List<AlbumModel> GetList();
        AlbumModel GetItem(int id);
    }

    public class AlbumService : ServiceBase, IAlbumService
    {
        public AlbumService(Db db) : base(db)
        {
        }

        public IQueryable<AlbumModel> Query()
        {
            return _db.Albums.Include(o => o.AlbumsMusics).ThenInclude(po => po.Music).OrderByDescending(o => o.IsAvailable).ThenBy(o => o.Price).ThenBy(o => o.Name)
                .Select(o => new AlbumModel()
                {
                    Name = o.Name,
                    Id = o.Id,
                    Price = o.Price,
                    IsAvailable = o.IsAvailable,
                    PublishedYear = o.PublishedYear,


                    PublishedYearOutput = o.PublishedYear.HasValue ? o.PublishedYear.Value.ToString("MM/dd/yyyy HH:mm:ss") : string.Empty,
                    IsAvailableOutput = o.IsAvailable ? "Available" : "Not Available",
                    PriceOutput = o.Price.ToString("N1"),

                    MusicIdInput = o.AlbumsMusics.Select(po => po.MusicId).ToList(),
                    MusicNameOutput = string.Join("<br />", o.AlbumsMusics.Select(po => po.Music.Title).ToList())
               

                });
        }

        public Result Add(AlbumModel model)
        {
            if (_db.Albums.Any(o => o.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResults("Album with the same name exist!");

            var entity = new Album()
            {
                PublishedYear = model.PublishedYear,
                IsAvailable = model.IsAvailable,
                Name = model.Name.Trim(),
                Price = model.Price ?? 0,

                AlbumsMusics = model.MusicIdInput?.Select(musicId => new AlbumsMusic()
                {
                    MusicId = musicId,
                }).ToList()
            };
            _db.Albums.Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
            return new SuccessResult("Album added successfuly.");
        }


        public Result Update(AlbumModel model)
        {
            if(_db.Albums.Any(o => o.Id != model.Id &&  o.Name.ToLower() == model.Name.ToLower().Trim()))
				return new ErrorResults("Album with the same name exist!");
            var entity = _db.Albums.Include(o => o.AlbumsMusics).SingleOrDefault(o => o.Id == model.Id);
            if(entity == null)
				return new ErrorResults("Album not found!");
            _db.AlbumsMusics.RemoveRange(entity.AlbumsMusics);

            entity.PublishedYear = model.PublishedYear;
            entity.IsAvailable = model.IsAvailable;
            entity.Name = model.Name.Trim();
            entity.Price = model.Price ?? 0;
            entity.AlbumsMusics = model.MusicIdInput?.Select(musicId => new AlbumsMusic()
            {
                MusicId = musicId,
            }).ToList();

            _db.Albums.Update(entity);
            _db.SaveChanges();
			return new SuccessResult("Album updated successfuly.");
		}

        public Result Delete(int id)
        {
            var entity = _db.Albums.Include(o => o.AlbumsMusics).SingleOrDefault(o => o.Id == id);
            if (entity == null)
                return new ErrorResults("Album not found!");

            _db.AlbumsMusics.RemoveRange(entity.AlbumsMusics);
            _db.Albums.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Album deleted successfuly.");
        }

        public List<AlbumModel> GetList() => Query().ToList();
        

        public AlbumModel GetItem(int id)
        {
            return Query().SingleOrDefault(o => o.Id == id);
        }
    }
}
