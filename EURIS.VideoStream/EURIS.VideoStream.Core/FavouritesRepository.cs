using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;
using EURIS.VideoStream.Interfaces;

namespace EURIS.VideoStream.Core
{
    public class FavouritesRepository : IRepository<Favourites>
    {
        private VideoStreamContext db;
        private DbSet<Favourites> dbSet;

        public FavouritesRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<Favourites>();
        }

        public IEnumerable<Favourites> GetAll()
        {
            return dbSet.ToList();
        }

        public Favourites GetById(Guid FavouriteId)
        {
            return dbSet.Find(FavouriteId);
        }

        public void Insert(Favourites FavouriteMedia)
        {
            dbSet.Add(FavouriteMedia);
        }

        public void Update(Favourites FavouriteMedia)
        {
            db.Entry(FavouriteMedia).State = EntityState.Modified;
        }

        public void Delete(Guid FavouriteId)
        {
            Favourites FMedia = dbSet.Find(FavouriteId);
            dbSet.Remove(FMedia);
        }

        public void SaveFavourite()
        {
            db.SaveChanges();
        }
    }
}
